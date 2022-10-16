function getToken() {
  const storage = sessionStorage.getItem('user');
  return storage ? JSON.parse(storage) : null;
}

export default getToken;
