
/**
 * @description Get token from session storage and return it
 *
 * @return {string} token
 */

function getToken() {
  const storage = sessionStorage.getItem('user');
  return storage ? JSON.parse(storage) : null;
}

export default getToken;
