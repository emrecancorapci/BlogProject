import {LinkContainer} from 'react-router-bootstrap';
import {ListGroup} from 'react-bootstrap';

function SidePanel() {
  return (
    <ListGroup>
      <LinkContainer to={`/Posts/Add`} activeClassName=''>
        <ListGroup.Item>New Post</ListGroup.Item>
      </LinkContainer>
      <ListGroup.Item>Listgroup texts here</ListGroup.Item>
      <ListGroup.Item>Listgroup texts here</ListGroup.Item>
      <ListGroup.Item>Listgroup texts here</ListGroup.Item>
      <ListGroup.Item>Listgroup texts here</ListGroup.Item>
    </ListGroup>
  );
}

export default SidePanel;
