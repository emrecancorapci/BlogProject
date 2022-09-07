import { useEffect, useState } from "react";
import { Link, useParams } from "react-router-dom";
import axios from "axios";
import Comments from "../Comments/Comments";

import Card from 'react-bootstrap/Card';
import Spinner from 'react-bootstrap/Spinner';

function PostDetailed() {
  const [isLoading, setIsLoading] = useState(true);

  const [post, setPost] = useState([]);
  const [user, setUser] = useState([]);

  let { id } = useParams();

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

  return (
    <>
      {isLoading &&
        (<Spinner animation="border" role="status">
          <span className="visually-hidden">Loading...</span>
        </Spinner>)}
      {
        <>
          <h1><strong>{post.title}</strong></h1>
          <h5 className="text-muted">{user.username}</h5>
          <Card>
            <Card.Body>
              <Card.Text>{post.content}</Card.Text>
              {/* <Card.Link href="#">Card Link</Card.Link>
              <Card.Link href="#">Another Link</Card.Link> */}
            </Card.Body>
          </Card>
          <div>
            <p>
              <Link to={`/Posts/${parseInt(id) - 1}`}>Previous Post</Link>
            </p>
          </div>
          {post.commentsEnabled && <></>}
          {<Comments postId={id} />}
        </>
      }
    </>
  );
}

export default PostDetailed;
