import React, {useEffect, useState} from 'react';
import {Container, Row, Col, Stack, Spinner} from 'react-bootstrap';
import axios from 'axios';
import AddComment from './AddComment';
import CommentCard from './CommentCard';

function Comments({postId}) {
  const [isLoading, setIsLoading] = useState(true);
  const [id] = useState(postId);

  const [comments, setComments] = useState([]);

  // FETCHING
  useEffect(() => {
    axios(`https://localhost:7169/api/Posts/${id}/Comments`)
        .then((response) => setComments(response.data))
        .catch((event) => console.log(event)) // Error logging
        .finally(() => setIsLoading(false)); // Set loading false
  }, [id]);

  return (
    <>
      <h2><strong>Comments</strong></h2>
      {isLoading &&
        (<Spinner animation="border" role="status">
          <span className="visually-hidden">Loading...</span>
        </Spinner>)}

      {<Container fluid>
        <Stack gap={3}>{
          comments.map((comment, index) => (
            <Row key={index}>
              <Col lg={8}><CommentCard comment={comment} /></Col>
              <Col></Col>
            </Row>))}
        </Stack>
      </Container>}
      <h3>Add Comment</h3>
      <AddComment postId={id} />
    </>
  );
}

export default Comments;
