function getUser() {
  const data = JSON.parse(sessionStorage.getItem('user'));

  console.log('Getting user!');

  if (data === null) {
    console.log('You must login to see this page.');
    return null;
  } else {
    return data;
  }
}

export default getUser;
