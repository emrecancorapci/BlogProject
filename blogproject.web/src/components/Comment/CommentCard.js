import React from 'react';
import PropTypes from 'prop-types';
import {Card, Row, Col} from 'react-bootstrap';

import UserHover from '../User/UserHover';
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
          </Row>
        </Card.Text>
      </Card.Body>
      {/* <Card.Footer className="text-muted text-center"></Card.Footer> */}
    </Card>
  );
}

CommentCard.propType = {
  comment: PropTypes.object,
  id: PropTypes.number,
  authorId: PropTypes.number,
  content: PropTypes.string,

};

export default CommentCard;
