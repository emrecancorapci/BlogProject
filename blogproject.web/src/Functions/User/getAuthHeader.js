function getAuthHeader() {
  const data = getUser();

  if (data === null) {
    return null;
  } else {
    return {headers: {'Authorization': `Bearer ${data.token}`}};
  }
}

export default getAuthHeader;
