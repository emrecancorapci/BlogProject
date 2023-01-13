import { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import axios, { AxiosResponse } from 'axios';

import getApi from '../../Functions/Common/getApi';
import { UserResponse } from '../../Interfaces/UserResponse';
import Posts from '../Posts/All';

const userInitial: UserResponse = {
  id: 0,
  username: '',
  name: '',
  lastName: '',
  about: '',
  profilePictureUrl: ''
};

/**
 * @description Displays user's profile page
 *
 * @returns {JSX.Element} User's profile page
 */

function ViewUser (): JSX.Element {
  const [isLoading, setIsLoading] = useState(true);
  const [user, setUser] = useState<UserResponse>(userInitial);
  const { id } = useParams();

  if (id === undefined) return (<h1>No ID</h1>);

  useEffect(() => {
    const userApi = getApi(`Users/${id}`);

    const fetchUser: () => Promise<AxiosResponse> =
      async () => await axios(userApi);

    fetchUser()
      .then((response) => { setUser(response.data); })
      .catch((event) => { console.log(event); })
      .finally(() => { setIsLoading(false); });
  }, [id]);

  return (<>
    {isLoading
      ? (<div>Loading...</div>)
      : (
        <div>
          <div
            className='row rounded rounded-3 border p-3
              align-items-center justify-content-evenly'
            style={{ minHeight: '200px' }}>
            <div className='col-auto'>
              <img alt={user.username} src={user.profilePictureUrl} />
            </div>
            <div className='col-8'>
              <div className='h1 fw-bold'>{user.username}</div>
              <h2>{user.name} {user.lastName}</h2>
              <p>{user.about}</p>
            </div>
          </div>
          <div>
            <h1 className='fw-bold'>{`${user.username}'s Posts`}</h1>
            <Posts userId={Number(id)} />
          </div>
        </div>
        )}
  </>);
}

export default ViewUser;
