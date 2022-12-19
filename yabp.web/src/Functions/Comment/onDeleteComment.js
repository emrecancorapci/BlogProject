import axios from 'axios';

import {getAuthHeader} from '../../Functions/User';
import getApi from '../../Functions/Common/getApi';

function onDeleteComment(id) {
  const api = getApi(`Comments/${id}`);
  const headers = getAuthHeader();

  axios.delete(api, headers)
      .then((request) => console.log(request))
      .catch((event) => console.log(event));
  console.log('Delete comment end!');
}

export default onDeleteComment;
