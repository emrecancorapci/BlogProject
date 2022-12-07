import axios from 'axios';
import {getAuthHeader} from '../../Functions/User';

function CommentDeleteButton({id}) {
  const onDeleteComment = (id) => {
    const api = `https://localhost:7169/api/Comments/${id}`;
    const headers = getAuthHeader();

    axios.delete(api, headers)
        .then((request) => console.log(request))
        .catch((event) => console.log(event));
  };

  return (
    <button
      className='btn btn-primary'
      onClick={() => onDeleteComment(id)}>
        Delete
    </button>
  );
}

export default CommentDeleteButton;