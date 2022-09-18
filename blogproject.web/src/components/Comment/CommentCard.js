import React from 'react';
import {Card, Row, Col, Button} from 'react-bootstrap';

import UserHover from '../User/UserHover';
import onDeleteComment from './onDeleteComment';

// DONE Implement comment delete
// TODO Implement comment edit

function CommentCard({comment}) {
  return (
    <Card>
      <Card.Header>
        <Row>
          <Col md="auto">
            <UserHover id={comment.authorId} />
          </Col>
          <Col></Col>
          <Col md="auto">
            <small className="text-muted">
              {comment.created.substr(0, 10)} - {comment.created.substr(11, 8)}
            </small>
          </Col>

        </Row>
      </Card.Header>
      <Card.Body>
        <Card.Text>
          <Row>
            <Col>{comment.content}</Col>
            <Col md="auto">
              <Button
                variant="primary"
                onClick={() => onDeleteComment(comment.id)}>
                Delete
              </Button>
            </Col>
          </Row>

        </Card.Text>
        {/* <Button variant="primary">Go somewhere</Button> */}
      </Card.Body>
      <Card.Footer className="text-muted text-center"></Card.Footer>
    </Card>
  );
}

export default CommentCard;
