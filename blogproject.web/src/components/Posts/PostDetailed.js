import React, {useEffect, useState} from 'react';
import {useParams} from 'react-router-dom';
import {Spinner, Card} from 'react-bootstrap';
import axios from 'axios';
import PropTypes from 'prop-types';

import Comments from '../Comments/Comments';
import GetUserName from '../Users/GetUserName';

function PostDetailed() {
  const [isLoading, setIsLoading] = useState(true);

  const [post, setPost] = useState([]);
  const [, setUser] = useState([]);

  const {id} = useParams();

  useEffect(() => {
    axios(`https://localhost:7169/api/Posts/${id}`)
        .then((response) => setPost(response.data))
        .catch((event) => console.log(event));
  }, [id]);

  useEffect(() => {
    axios(`https://localhost:7169/api/Users/${post.authorId}`)
        .then((response) => setUser(response.data))
        .catch((event) => console.log(event))
        .finally(() => setIsLoading(false)); // Set loading false
  }, [post]);

  return (<>
    {isLoading &&
        (<Spinner animation="border" role="status" />)}
    {<>
      <h1><strong>{post.title}</strong></h1>
      <h5 className="text-muted"><GetUserName id={post.authorId} /></h5>
      <Card>
        <Card.Body>
          <Card.Text>{post.content}</Card.Text>
          {/* <Card.Link href="#">Card Link</Card.Link>
              <Card.Link href="#">Another Link</Card.Link> */}
        </Card.Body>
      </Card>
      {/* <div>
            <p>
              <Link to={`/Posts/${parseInt(id) - 1}`}>Previous Post</Link>
            </p>
          </div> */}
      {post.commentsEnabled && <></>}
      {<Comments postId={id} />}
    </>}
  </>);
}

export default PostDetailed;
