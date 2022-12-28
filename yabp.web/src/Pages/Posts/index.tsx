import { useEffect, useState } from 'react';
import axios, { AxiosResponse } from 'axios';

import PostCard from '../../Components/Post/PostCard';
import getApi from '../../Functions/Common/getApi';

/**
 * @description Displays all posts in the database
 *
 * @returns {JSX.Element} All posts in the database
 */

interface Post {
  id: number
  title: string
  content: string
  authorId: number
  postSummary: string
  isCommentsVisible: boolean
  addCommentsEnabled: boolean
}

function Posts (): JSX.Element {
  // TODO Add pagination
  const [posts, setPosts] = useState([] as Post[]);
  const [isLoading, setIsLoading] = useState(true);

  useEffect(() => {
    const api = getApi('Posts');

    const fetchPosts: () => Promise<AxiosResponse> =
      async () => await axios(api);

    fetchPosts()
      .then((response) => setPosts(response.data))
      .catch((event) => console.log(event))
      .finally(() => setIsLoading(false));
  }, []);

  return (<>
    {isLoading && (<div className='spinner-border' role='status'/>)}
    {posts.map((post, index) =>
      <PostCard post={post} key={index}/>
    )}
  </>);
}

export default Posts;
