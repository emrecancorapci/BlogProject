import axios from 'axios';
import React from 'react';
import {Card, Row, Col} from 'react-bootstrap';

import GetUserName from '../Users/GetUserName';

// TODO Implement comment delete

function CommentCard({comment}) {
  const onClickDelete = (id) => {
    const data = JSON.parse(sessionStorage.getItem('login'));

    if (data == null) {
      console.log('Please Login!');
      return;
    }

    const api = `https://localhost:7169/api/Comments/${id}`;
    const headers = {headers: {'Authorization': `Bearer ${data.token}`}};

    axios.delete(api, headers)
        .then((request) => console.log(request))
        .catch((event) => console.log(event));
  };

  return (
    <Card>
      <Card.Header>
        <Row>
          <Col>
            <strong className="me-auto">
              <GetUserName id={comment.authorId} />
            </strong>
          </Col>

          <Col md="auto">
            <small className="text-muted">
              {comment.created.substr(0, 10)} - {comment.created.substr(11, 8)}
            </small>
          </Col>

        </Row>
      </Card.Header>
      <Card.Body>
        <Card.Text>
          <Col>{comment.content}</Col>
          <Col md="auto">
            <button onClick={ () => onClickDelete(comment.id)}>Delete</button>
          </Col>
        </Card.Text>
        {/* <Button variant="primary">Go somewhere</Button> */}
      </Card.Body>
      <Card.Footer className="text-muted text-center"></Card.Footer>
    </Card>
  );
}

export default CommentCard;