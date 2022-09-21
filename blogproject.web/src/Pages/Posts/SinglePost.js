import React, {useEffect, useState} from 'react';
import axios from 'axios';
import {useParams} from 'react-router-dom';
import {Row, Col, Spinner, Container, Card, Alert} from 'react-bootstrap';

import CommentsSection from '../../Components/Comment/CommentsSection';
import UserHover from '../../Components/User/UserHover';
import AddComment from '../../Components/Comment/AddComment';
import {getUser} from '../../Functions/User';

function SinglePost() {
  const [isLoading, setIsLoading] = useState(true);
  const [post, setPost] = useState([]);
  const {id} = useParams();
  const user = getUser();

  useEffect(() => {
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
          <h5 className="text-muted"><UserHover id={post.authorId} /></h5>
        </Col>
        <Col></Col>
      </Row>
      <Card>
        <Card.Body>
          <Card.Text>{post.content}</Card.Text>
        </Card.Body>
      </Card>
      <h2><strong>
        Comments
      </strong></h2>
      <Container fluid>
        <CommentsSection postId={id} />
      </Container>
      {user !== null && post.commentsEnabled &&
      <div>
        <h3><strong>Add Comment</strong></h3>
        <AddComment postId={id} />
      </div>}
      {user === null &&
      <div style={{padding: '1rem'}}>
        <Alert variant='warning'>
          You must be logged in to post a comment
        </Alert>
      </div>}
    </>}
  </>);
}

export default SinglePost;
