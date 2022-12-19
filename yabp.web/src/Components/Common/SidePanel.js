import {LinkContainer} from 'react-router-bootstrap';
import {ListGroup} from 'react-bootstrap';

function SidePanel() {
  return (
    <ListGroup>
      <LinkContainer to={`/Posts/Add`}>
        <ListGroup.Item>New Post</ListGroup.Item>
      </LinkContainer>
      <ListGroup.Item>Button 2</ListGroup.Item>
      <ListGroup.Item>Button 3</ListGroup.Item>
      <ListGroup.Item>Button 4</ListGroup.Item>
      <ListGroup.Item>Button 5</ListGroup.Item>
    </ListGroup>
  );
}

export default SidePanel;
