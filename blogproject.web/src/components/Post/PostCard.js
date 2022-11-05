import {LinkContainer} from 'react-router-bootstrap';
import GetUserName from '../User/UserHover';

function PostCard({post}) {
  return (
    <div className='card'>
      <div className='card-body'>
        <LinkContainer to={`/Posts/${post.id}`} style={{cursor: 'pointer'}}>
          <div className='card-title'>
            <h3><strong>{post.title}</strong></h3>
          </div>
        </LinkContainer>
        <div className='card-subtitle row'>
          <div className='col-auto text-muted fw-bold'>
            <GetUserName id={post.authorId} />
          </div>
        </div>
        <div className='card-text'>
          {post.postSummary}
        </div>
        {/*
        <a href="#" class="card-link">Card link</a>
        <a href="#" class="card-link">Another link</a>
        */}
      </div>
    </div>);
}

export default PostCard;
