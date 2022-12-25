import UserHover from '../User/UserHover';
import DateTooltip from '../Common/DateTooltip';

// TODO Add control menu
// TODO Implement comment like
// TODO Implement comment delete
// TODO Implement comment edit
// TODO Implement comment reply
// TODO Implement comment report
// TODO Implement comment share
// TODO Implement comment save
// TODO Implement comment pin

/**
 * @description Comment card with date tooltip
 *
 * @param {Object} comment - Comment object
 * @return {JSX.Element} Comment card
 */

function CommentCard({comment}) {
  return (
    <div className='card'>
      <div className='card-header c-bg-light'>
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
