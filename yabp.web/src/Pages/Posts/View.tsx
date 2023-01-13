import { useEffect, useState } from 'react';
import axios, { AxiosResponse } from 'axios';
import { useParams } from 'react-router-dom';

import CommentsSection from '../../Components/Comment/CommentsSection';
import UserHover from '../../Components/User/UserHover';
import getApi from '../../Functions/Common/getApi';
import { PostResponse } from '../../Interfaces/PostResponse';

const postInitial: PostResponse = {
  id: 0,
  title: '',
  content: '',
  postSummary: '',
  authorId: 0,
  isCommentsVisible: false,
  addCommentsEnabled: false
};

/**
 * @description - Displays a single post and its comments
 * @return {JSX.Element} - Single post and its comments
 */

function SinglePost (): JSX.Element {
  const { id } = useParams();
  const [isLoading, setIsLoading] = useState(true);
  const [post, setPost] = useState<PostResponse>(postInitial);

  if (id === undefined) return (<h1>No ID</h1>)

  useEffect(() => {
    const api = getApi(`Posts/${id}`);
    const fetchPost: () => Promise<AxiosResponse> =
      async () => await axios(api);

    fetchPost()
      .then((response) => {
        if (response.status !== 200) {
          throw new Error('Error' +
          ` ${response.status}: ${response.statusText}`);
        }
        setPost(response.data)
      })
      .catch((event) => { console.log(event); })
      .finally(() => { setIsLoading(false); });
  }, [id]);

  return (<>
    {isLoading && <div className='spinner-border' role='status' />}
    {<div className='container'>
      <article>
        {/* Title Section */}
        <title className='row'>
          <h1 className='fw-bold'>{post.title}</h1>
        </title>
        <div className='row'>
          <div className='col-auto'>
            <h5 className="text-muted fw-bold">
              <UserHover id={post.authorId} />
            </h5>
          </div>
        </div>
        {/* Content Section */}
        <div className='row p-2 pb-1 mt-2 mb-3 rounded
          border border-opacity-75'>
          <pre className='content-pre'>
            {post.content}
          </pre>
        </div>
      </article>
      <CommentsSection
        postId={Number(id)}
        addPermission={post.addCommentsEnabled}/>
    </div>}
  </>);
}

export default SinglePost;
