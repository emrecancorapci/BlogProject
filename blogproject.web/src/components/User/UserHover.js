import React, {useEffect, useState} from 'react';
import axios from 'axios';
import {LinkContainer} from 'react-router-bootstrap';
import {Col, Row, Popover, OverlayTrigger, Button} from 'react-bootstrap';
import {Container, Stack} from 'react-bootstrap';


function UserHover({id}) {
  const [user, setUser] = useState([]);

  const popover = (
    <Popover id="popover-basic">
      <Popover.Header>
        <Row className="align-items-center">
          <Col lg="auto">
            <img
              style={{
                height: '32px',
                width: '32px',
              }}
              src={user.profilePictureUrl}
              className="rounded me-2 popover-img"
              alt=""
            />
            <strong className="me-auto">{user.name} {user.lastName}</strong>
          </Col>
        </Row>
      </Popover.Header>
      <Popover.Body>
        <Container>
          <Stack gap={2}>
            <Row sm="auto">
              {user.about}
            </Row>
            <Row>
              <Col></Col>
              <Col sm="auto">
                <LinkContainer to={`/Users/${id}`} style={{cursor: 'pointer'}}>
                  <Button variant="primary" size="sm">
                    Show Profile
                  </Button>
                </LinkContainer>
              </Col>
              <Col></Col>
            </Row>
          </Stack>
        </Container>
      </Popover.Body>
    </Popover>
  );

  useEffect(() => {
    axios(`https://localhost:7169/api/Users/${id}`)
        .then((response) => setUser(response.data))
        .catch((event) => console.log(event));
  }, [id]);

  return (
    <OverlayTrigger trigger="click" placement="right" overlay={popover}>
      <strong>
        {user.username}
      </strong>
    </OverlayTrigger>
  );
}

export default UserHover;
