import React, {useEffect, useState} from 'react';
import axios from 'axios';
import {useParams} from 'react-router-dom';
import {getToken} from '../../Functions/User';
import {Row, Col, Spinner, Container,
  Card, Alert} from 'react-bootstrap';

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
    {isLoading &&
        (<Spinner animation="border" role="status" />)}
    {<>
      <Row>
        <h1><strong>{post.title}</strong></h1>
      </Row>
      <Row>
        <Col lg="auto">
          <h5 className="text-muted">
            <UserHover id={post.authorId} />
          </h5>
        </Col>
        <Col></Col>
      </Row>
      <Row style={{padding: '1rem 1rem'}}>
        <Card>
          <Card.Body>
            <Card.Text>{post.content}</Card.Text>
          </Card.Body>
        </Card>
      </Row>
      <Row>
        <h2 style={{fontWeight: 'bold'}}>
          Comments
        </h2>
        <Container fluid>
          <CommentsSection id={id} />
        </Container>
      </Row>
      {post.commentsEnabled &&
      <Row style={{padding: '1rem 0rem'}}>
        {user &&
        <div>
          <h3 style={{fontWeight: 'bold'}}>
            Add Comment
          </h3>
          <AddComment postId={id} />
        </div>}
        {!user &&
        <div style={{padding: '1rem'}}>
          <Alert variant='warning'>
            You must be logged in to post a comment
          </Alert>
        </div>}
      </Row>}
    </>}
  </>);
}

export default SinglePost;
