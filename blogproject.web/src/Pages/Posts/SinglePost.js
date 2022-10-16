import {useEffect, useState} from 'react';
import axios from 'axios';
import {useParams} from 'react-router-dom';
import {getToken} from '../../Functions/User';

import CommentsSection from '../../Components/Comment/CommentsSection';
import UserHover from '../../Components/User/UserHover';
import AddComment from '../../Components/Comment/AddComment';

function SinglePost() {
  const [isLoading, setIsLoading] = useState(true);
  const [user, setUser] = useState([]);
  const [post, setPost] = useState([]);
  const {id} = useParams();

  useEffect(() => {
    setUser(getToken());
    console.log(`Post ID: ${id}`);

    axios(`https://localhost:7169/api/Posts/${id}`)
        .then((response) => setPost(response.data))
        .catch((event) => console.log(event))
        .finally(() => setIsLoading(false));
  }, [id]);

  return (<>
    {isLoading && <div className='spinner-border' role='status' />}
    {<div className='container'>
      <article>
        {/* Title Section */}
        <section>
          <title className='row'>
            <h1 className='fw-bold'>{post.title}</h1>
          </title>
          <author className='row'>
            <div className='col-auto'>
              <h5 className="text-muted fw-bold">
                <UserHover id={post.authorId} />
              </h5>
            </div>
          </author>
        </section>
        {/* Content Section */}
        <section className='row p-2 pb-3'>
          <div className='card'>
            <div className='card-body'>
              <content className='card-text'>
                {post.content}
              </content>
            </div>
          </div>
        </section>
        {/* Comments Section */}
        <section className='row'>
          <h2 className='fw-bold'>
                Comments
          </h2>
          <CommentsSection id={id} />
        </section>
      </article>
      {/* Add Comment Section */}
      {post.commentsEnabled &&
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
    </div>}
  </>);
}

export default SinglePost;
