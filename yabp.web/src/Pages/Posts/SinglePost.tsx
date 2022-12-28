import {useEffect, useState} from 'react';
import axios from 'axios';
import {useParams} from 'react-router-dom';

import CommentsSection from '../../Components/Comment/CommentsSection';
import UserHover from '../../Components/User/UserHover';
import AddComment from '../../Components/Comment/AddComment';
import getApi from '../../Functions/Common/getApi';
import {getToken} from '../../Functions/User';


/**
 * @description - Displays a single post and its comments
 *
 * @return {JSX.Element} - Single post and its comments
 */

type Post = {
  id: number;
  title: string;
  content: string;
  authorId: number;
  isCommentsVisible: boolean;
  addCommentsEnabled: boolean;
}

function SinglePost() {
  const [isLoading, setIsLoading] = useState(true);
  const [post, setPost] = useState<Post>({} as Post);
  const {id} = useParams();
  const user = getToken();

  useEffect(() => {
    console.log(`Post ID: ${id}`);

    const api = getApi(`Posts/${id}`);
    const fetchPost = async () => await axios(api);

    fetchPost()
        .then((response) => setPost(response.data))
        .catch((event) => console.log(event))
        .finally(() => setIsLoading(false));
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
          <p>
            {post.content}
          </p>
        </div>
      </article>
      {/* Add Comment Section */}
      {post.addCommentsEnabled &&
        <div className='row px-3 pt-3 pb-2 shadow-sm rounded
          border c-bg-lighter'>
          <h3 className='fw-bold c-tx-dark'>
              Add Comment
          </h3>
          {user &&
            <div className='pt-2'>
              <AddComment postId={Number(id)}/>
            </div>}
          {!user &&
            <div className='alert alert-warning'>
              You must be logged in to post a comment.
            </div>}
        </div>}
      {/* Comments Section */}
      {post.isCommentsVisible &&
        <div className='row p-2'>
          <h2 className='fw-bold c-tx-dark'>
                Comments
          </h2>
          <CommentsSection id={Number(id)} />
        </div>}
    </div>}
  </>);
}

export default SinglePost;
