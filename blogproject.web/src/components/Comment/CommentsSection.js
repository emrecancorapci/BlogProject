import React, {useEffect, useState} from 'react';
import axios from 'axios';
import {Container, Row, Col, Stack, Spinner} from 'react-bootstrap';
import CommentCard from './CommentCard';

function CommentsSection({postId}) {
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
      {isLoading &&
        (<Spinner animation="border" role="status" />)}

      {<Container fluid>
        <Stack gap={3}>{
          comments.map((comment, index) => (
            <Row key={index}>
              <Col lg={8}><CommentCard comment={comment} /></Col>
              <Col></Col>
            </Row>))}
        </Stack>
      </Container>}
    </>
  );
}

export default CommentsSection;
