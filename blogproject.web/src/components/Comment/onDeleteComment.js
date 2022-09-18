import axios from 'axios';

function onDeleteComment({id}) {
  const data = JSON.parse(sessionStorage.getItem('login'));

  if (data == null) {
    console.log('Please Login!');
    return;
  }

  const api = `https://localhost:7169/api/Comments/${id}`;
  const headers = {headers: {'Authorization': `Bearer ${data.token}`}};

  axios.delete(api, headers)
      .then((request) => console.log(request))
      .catch((event) => console.log(event));
}

export default onDeleteComment;
