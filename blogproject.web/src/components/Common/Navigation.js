import { LinkContainer } from 'react-router-bootstrap';

import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
// import NavDropdown from 'react-bootstrap/NavDropdown';

function Navigation({ title }) {
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
						<LinkContainer to={`/Posts/Add`}>
							<Nav.Link>New Post</Nav.Link>
						</LinkContainer>
						<LinkContainer to={`/login`}>
							<Nav.Link>Login</Nav.Link>
						</LinkContainer>
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
	)
}

export default Navigation