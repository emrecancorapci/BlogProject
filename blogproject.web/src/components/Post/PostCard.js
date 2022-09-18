import React from 'react';
import {LinkContainer} from 'react-router-bootstrap';
import {Card} from 'react-bootstrap';

import GetUserName from '../User/UserHover';


function PostCard({post}) {
  return (<>
    <Card>
      <Card.Body>
        <LinkContainer to={`/Posts/${post.id}`} style={{cursor: 'pointer'}}>
          <Card.Title>
            <h3><strong>{post.title}</strong></h3>
          </Card.Title>
        </LinkContainer>

        <Card.Text className='text-muted'>
          <GetUserName id={post.authorId} />
        </Card.Text>

        <Card.Text>
          {post.postSummary}
        </Card.Text>
        {/* <Card.Link href="#">Card Link</Card.Link>
    <Card.Link href="#">Another Link</Card.Link> */}
      </Card.Body>
    </Card>
  </>);
}

export default PostCard;
