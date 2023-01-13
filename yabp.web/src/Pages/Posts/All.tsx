import { useEffect, useState } from 'react';
import axios, { AxiosResponse } from 'axios';

import PostCard from '../../Components/Post/PostCard';
import getApi from '../../Functions/Common/getApi';
import { PostResponse } from '../../Interfaces/PostResponse';

/**
 * @description Displays all posts in the database
 * @param {number} userId - The id of the user to display posts for (optional)
 *
 * @returns {JSX.Element} All posts in the database
 */

function ViewPosts ({ userId }: { userId?: number }): JSX.Element {
  // TODO Add pagination
  const [posts, setPosts] = useState([] as PostResponse[]);
  const [isLoading, setIsLoading] = useState(true);

  useEffect(() => {
    const api = userId !== undefined
      ? getApi(`Posts?authorId=${userId}`)
      : getApi('Posts');

    const fetchPosts: () => Promise<AxiosResponse> =
      async () => await axios(api);

    fetchPosts()
      .then((response) => {
        if (response.status !== 200) {
          throw new Error('Error' +
          ` ${response.status}: ${response.statusText}`);
        }
        setPosts(response.data)
        console.log(response.data)
      })
      .catch((event) => { console.log(event); })
      .finally(() => { setIsLoading(false); });
  }, []);

  return (<>
    {isLoading && (<div className='spinner-border' role='status'/>)}
    {posts.map((post, index) =>
      <PostCard post={post} key={index}/>
    )}
  </>);
}

export default ViewPosts;
