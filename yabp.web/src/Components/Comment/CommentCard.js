import UserHover from '../User/UserHover';
import DateTooltip from '../Common/DateTooltip';
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
            <DateTooltip date={comment.created}/>
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

export default CommentCard;
