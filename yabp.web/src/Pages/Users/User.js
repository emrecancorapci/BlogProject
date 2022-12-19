import {useEffect, useState} from 'react';
import {useParams} from 'react-router-dom';
import axios from 'axios';

import getApi from '../../Functions/Common/getApi';

function User() {
  const [isLoading, setIsLoading] = useState(true);

  const [user, setUser] = useState([]);
  const {id} = useParams();

  useEffect(() => {
    const api = getApi(`Users/${id}`);

    const fetchData = async () => await axios(api);

    fetchData()
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
