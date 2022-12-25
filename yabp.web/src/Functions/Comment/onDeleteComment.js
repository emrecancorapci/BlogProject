import axios from 'axios';

import {getAuthHeader} from '../../Functions/User';
import getApi from '../../Functions/Common/getApi';


/**
 * @description Deletes comment with specified id
 *
 * @param {Number} id - Comment id
 */

function onDeleteComment(id) {
  const api = getApi(`Comments/${id}`);
  const headers = getAuthHeader();

  axios.delete(api, headers)
      .then((request) => console.log(request))
      .catch((event) => console.log(event));
}

export default onDeleteComment;
