
/**
 * @description Get token from session storage and return it
 *
 * @return {string} token
 */

interface Token {
  id: number
  userName: string
  token: string

}

function getToken (): Token {
  const storage = sessionStorage.getItem('user');
  return storage !== null ? JSON.parse(storage) : null;
}

export default getToken;
