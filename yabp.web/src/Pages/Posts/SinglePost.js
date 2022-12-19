import {useEffect, useState} from 'react';
import axios from 'axios';
import {useParams} from 'react-router-dom';

import CommentsSection from '../../Components/Comment/CommentsSection';
import UserHover from '../../Components/User/UserHover';
import AddComment from '../../Components/Comment/AddComment';
import getApi from '../../Functions/Common/getApi';
import {getToken} from '../../Functions/User';

function SinglePost() {
  const [isLoading, setIsLoading] = useState(true);
  const [user, setUser] = useState([]);
  const [post, setPost] = useState([]);
  const {id} = useParams();

  useEffect(() => {
    setUser(getToken());
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
        <div className='row p-2 pb-3'>
          <div className='card'>
            <div className='card-body'>
              <p className='card-text'>
                {post.content}
              </p>
            </div>
          </div>
        </div>
      </article>
      {/* Add Comment Section */}
      {post.addCommentsEnabled &&
        <div className='pt-3'>
          {user &&
          <div>
            <h3 className='fw-bold'>
              Add Comment
            </h3>
            <AddComment postId={id}/>
          </div>}
          {!user &&
            <div className='alert alert-warning'>
              You must be logged in to post a comment.
            </div>}
        </div>}
      {/* Comments Section */}
      {post.isCommentsVisible &&
      <section className='row'>
        <h2 className='fw-bold'>
              Comments
        </h2>
        <CommentsSection id={id} />
      </section>}
    </div>}
  </>);
}

export default SinglePost;
