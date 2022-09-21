import React, {useEffect} from 'react';
import {LinkContainer} from 'react-router-bootstrap';
import {Container, Nav, Navbar, Button} from 'react-bootstrap';

// import NavDropdown from 'react-bootstrap/NavDropdown';

function Navigation({title, auth, setAuth}) {
  const onClickLogout = () => {
    sessionStorage.removeItem('user');
    setAuth(false);
  };

  useEffect(() => {
    setAuth(auth);
  }, [auth]);

  return (
    <Navbar bg="dark" variant="dark" expand="lg">
      <Container>
        <LinkContainer to={`/`}>
          <Navbar.Brand>{title}</Navbar.Brand>
        </LinkContainer>
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
          <Nav className="me-auto">
            <LinkContainer to={`/`}>
              <Nav.Link>Home</Nav.Link>
            </LinkContainer>
            {!auth &&
            <LinkContainer to={`/login`}>
              <Nav.Link>Login</Nav.Link>
            </LinkContainer>}
            {auth &&
            <Navbar.Collapse className="justify-content-end">
              <Button
                variant='light'
                onClick={() => onClickLogout()}>
                Logout
              </Button>
            </Navbar.Collapse>
            }
            {/* <NavDropdown title="Dropdown" id="basic-nav-dropdown">
              <NavDropdown.Item href="#action/3.1">Action</NavDropdown.Item>
              <NavDropdown.Item href="#action/3.2">
                Another action
              </NavDropdown.Item>
              <NavDropdown.Item href="#action/3.3">Something</NavDropdown.Item>
              <NavDropdown.Divider />
              <NavDropdown.Item href="#action/3.4">
                Separated link
              </NavDropdown.Item>
            </NavDropdown> */}
          </Nav>
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
}

export default Navigation;
