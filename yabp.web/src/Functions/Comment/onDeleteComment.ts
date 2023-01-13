import axios from 'axios';

import { getAuthConfig } from '../User';
import getApi from '../Common/getApi';

/**
 * @description Deletes comment with specified id
 *
 * @param {Number} id - Comment id
 * @returns {void} Nothing
 */

function onDeleteComment (id: number): void {
  const api = getApi(`Comments/${id}`);
  const config = getAuthConfig();

  axios.delete(api, config)
    .then((request) => { console.log(request); })
    .catch((event) => { console.log(event); });
}

export default onDeleteComment;
