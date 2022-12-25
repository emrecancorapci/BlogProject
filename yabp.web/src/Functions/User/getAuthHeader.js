import getToken from './getToken';


/**
 * @description Get auth header for axios requests
 *
 * @return {string} header
 */

function getAuthHeader() {
  const data = getToken();

  if (data.token) {
    return {headers: {'Authorization': `Bearer ${data.token}`}};
  }
  return null;
}

export default getAuthHeader;
