function getToken() {
  return JSON.parse(sessionStorage.getItem('user'));
}

export default getToken;
