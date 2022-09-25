import axios from 'axios';
// TODO Not woking
function getUser(id) {
  console.log(`Getting user(${id}).`);
  let data = JSON.parse(sessionStorage.getItem('usersdata'));

  if (data) {
    console.log(data);

    data.forEach((userdata, index) => {
      if (userdata.id == id) {
        console.log(`User founded in storage. (${index})`);
        return userdata;
      }
    });
  };

  axios(`https://localhost:7169/api/Users/${id}`)
      .catch((event) => console.log(event))
      .then((response) => {
        if (!data) {
          data = [];
        }
        data.push(response.data);
        sessionStorage.setItem('usersdata', JSON.stringify(data));
        return userdata;
      });
};

export default getUser;
