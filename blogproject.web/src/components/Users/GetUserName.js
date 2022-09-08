import axios from "axios";
import { useEffect, useState } from "react";
import { LinkContainer } from 'react-router-bootstrap';

import { Col, Row, Popover, OverlayTrigger, Button } from "react-bootstrap";

function GetUserName({ id }) {
  const [user, setUser] = useState([]);

  const popover = (
    <Popover id="popover-basic">
      <Popover.Header>
        <Row className="align-content-md-center">
          <Col sm={2}>
            <img
              style={{
                height: "22px",
                width: "22px",
              }}
              src={user.profilePictureUrl}
              className="rounded me-2 popover-img"
              alt=""
            />
          </Col>
          <Col md="auto">
            <strong className="me-auto">
              <h6>
                {user.name} {user.lastName}
              </h6>
            </strong>
          </Col>
        </Row>
      </Popover.Header>
      <Popover.Body>
        <Row sm="auto">
          {user.about}
        </Row>
        <Row sm="auto">
        <Col></Col>
          <Col sm="auto">
            <LinkContainer to={`/Users/${id}`} style={{ cursor: 'pointer' }}>
              <Button variant="primary" size="sm">
                Show Profile
              </Button>
            </LinkContainer>
          </Col>
          <Col></Col>
        </Row>
      </Popover.Body>
    </Popover>
  );

  useEffect(() => {
    axios(`https://localhost:7169/api/Users/${id}`)
      .then((response) => setUser(response.data))
      .catch((event) => console.log(event));
  }, [id]);

  return (
    <Row>
      <Col md="auto">
        <OverlayTrigger trigger="click" placement="right" overlay={popover}>
          <h6>
            <strong>
              {user.username}
            </strong>
          </h6>
        </OverlayTrigger>
      </Col>
      <Col></Col>
    </Row>
  )
}

export default GetUserName;
