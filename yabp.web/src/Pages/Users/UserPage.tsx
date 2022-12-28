import {useEffect, useState} from 'react';
import {useParams} from 'react-router-dom';
import axios from 'axios';

import getApi from '../../Functions/Common/getApi';
import PostCard from '../../Components/Post/PostCard';

/**
 * @description Displays user's profile page
 *
 * @returns {JSX.Element} User's profile page
 */

type User = {
  id: number;
  username: string;
  name: string;
  lastName: string;
  about: string;
  profilePictureUrl: string;
};

function UserPage(): JSX.Element {
  const [isLoading, setIsLoading] = useState(true);

  const [user, setUser] = useState<User>({} as User);
  const [posts, setPosts] = useState([]);
  const {id} = useParams();

  useEffect(() => {
    const userApi = getApi(`Users/${id}`);
    const userPostsApi = getApi(`Users/${id}/Posts`);

    const fetchUser = async () => await axios(userApi);
    const fetchPosts = async () => await axios(userPostsApi);

    fetchUser()
        .then((response) => setUser(response.data))
        .catch((event) => console.log(event))
        .finally(() => setIsLoading(false));

    fetchPosts()
        .then((response) => setPosts(response.data))
        .catch((event) => console.log(event));
  }, [id]);

  return (<>
    {isLoading && <div>Loading...</div>}
    {<div>
      <div
        className='row rounded rounded-3 border p-3
      align-items-center justify-content-evenly'
        style={{minHeight: '200px'}}>
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
        <h1 className='fw-bold'>Posts</h1>
        {posts.map((post, index) =>
          <PostCard post={post} key={index} />,
        )}
      </div>
    </div>}
  </>);
}

export default UserPage;
