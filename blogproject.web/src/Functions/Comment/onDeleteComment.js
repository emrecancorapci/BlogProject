import axios from 'axios';
import {getAuthHeader} from '../../Functions/User';

function onDeleteComment(id) {
  const api = `https://localhost:7169/api/Comments/${id}`;
  const headers = getAuthHeader();

  axios.delete(api, headers)
      .then((request) => console.log(request))
      .catch((event) => console.log(event));
  console.log('Delete comment end!');
};

export default onDeleteComment;
