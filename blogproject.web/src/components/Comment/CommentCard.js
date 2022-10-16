import PropTypes from 'prop-types';
import UserHover from '../User/UserHover';
// DONE Implement comment delete
// TODO Implement comment edit

function CommentCard({comment}) {
  return (
    <div className='card'>
      <div className='card-header'>
        <div className='row justify-content-between'>
          <div className='col-auto fw-bold'>
            <UserHover id={comment.authorId} />
          </div>
          <div className='col-auto'>
            <small className="text-muted">
              {comment.created.substr(0, 10)} - {comment.created.substr(11, 8)}
            </small>
          </div>
        </div>
      </div>
      <div className='card-body'>
        <div className='card-text'>
          {comment.content}
        </div>
      </div>
    </div>
  );
}

CommentCard.propType = {
  comment: PropTypes.object,
  id: PropTypes.number,
  authorId: PropTypes.number,
  content: PropTypes.string,

};

export default CommentCard;
