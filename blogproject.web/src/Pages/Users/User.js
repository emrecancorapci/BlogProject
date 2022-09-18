import React, {useEffect, useState} from 'react';
import {useParams} from 'react-router-dom';
import axios from 'axios';

function User() {
  const [isLoading, setIsLoading] = useState(true);

  const [user, setUser] = useState([]);
  const {id} = useParams();

  useEffect(() => {
    axios(`https://localhost:7169/api/Users/${id}`)
        .then((response) => setUser(response.data))
        .catch((event) => console.log(event))
        .finally(() => setIsLoading(false)); // Set loading false
  }, [id]);

  return (<>
    {isLoading && <div>Loading...</div>}
    {<>
      <div><img alt={user.username} src={user.profilePictureUrl} /></div>
      <h1>{user.username}</h1>
      <h2>{user.name} {user.lastName}</h2>
      <p>{user.about}</p>
    </>}
  </>);
}

export default User;
