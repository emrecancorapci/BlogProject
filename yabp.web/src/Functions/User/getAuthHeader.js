import getToken from './getToken';

function getAuthHeader() {
  const data = getToken();

  if (data.token) {
    return {headers: {'Authorization': `Bearer ${data.token}`}};
  }
  return null;
}

export default getAuthHeader;
