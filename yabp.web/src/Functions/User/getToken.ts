
/**
 * @description Get token from session storage and return it
 *
 * @return {string} token
 */

type Token = {
  id: number,
  userName: string,
  token: string,

}

function getToken(): Token {
  const storage = sessionStorage.getItem('user');
  return storage ? JSON.parse(storage) : null;
}

export default getToken;
