import React, {useEffect, useState} from 'react';
import axios from 'axios';
import {Row, Col, Stack, Spinner, Button} from 'react-bootstrap';
import {getToken} from '../../Functions/User';

import CommentCard from './CommentCard';
import onDeleteComment from '../../Functions/Comment/onDeleteComment';

function CommentsSection({id}) {
  const [isLoading, setIsLoading] = useState(true);
  const [comments, setComments] = useState([]);
  const [token, setToken] = useState([]);

  useEffect(() => {
    setToken(getToken());
    console.log(`ComSec ID: ${id}`);

    axios(`https://localhost:7169/api/Posts/${id}/Comments`)
        .then((response) => setComments(response.data))
        .catch((event) => console.log(event)) // Error logging
        .finally(() => setIsLoading(false)); // Set loading false
  }, []);

  return (<>
    {isLoading &&
      (<Spinner animation="border" role="status" />)}

    {<Stack gap={3}>
      { comments.map((comment, index) => (
        <Row key={index}>
          <Col/>
          <Col lg={9}>
            <CommentCard comment={comment}/>
          </Col>
          <Col lg={2}>
            {token &&
            (token.id === comment.authorId || token.Role === 'Admin') &&
            <>
              <Stack gap={2}>
                <Row>
                  <Button
                    variant="primary"
                    disabled>
                      Edit
                  </Button>
                </Row>
                <Row>
                  <Button
                    variant="danger"
                    onClick={() => onDeleteComment(comment.id)}>
                      Delete
                  </Button>
                </Row>
              </Stack>
            </>}
          </Col>
          <Col/>
        </Row>))}
    </Stack>}
  </>);
}

export default CommentsSection;
