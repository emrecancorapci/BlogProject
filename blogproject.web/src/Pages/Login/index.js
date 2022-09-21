import React, {useEffect, useState} from 'react';
import axios from 'axios';

function Login({setAuth}) {
  const [form, setForm] = useState([]);
  const [token, setToken] = useState([]);

  useEffect(() => {
    sessionStorage.setItem('user', JSON.stringify(token));
    console.log(token);
  }, [token]);

  const onChangeInput = (event) => {
    setForm({...form, [event.target.name]: event.target.value});
  };

  const onSubmitForm = (event) => {
    event.preventDefault();

    const api = 'https://localhost:7169/api/Users/Login';

    if (form.username === '' || form.password === '') {
      console.log('Fill all the fields.');
      return false;
    }

    axios.post(api, form)
        .then((response) => setToken(response.data))
        .catch((event) => console.log(event));

    setAuth(true);

    console.log('Submit');
  };

  return (
    <>
      <form onSubmit={onSubmitForm}>
        <div>
          <input
            type="text"
            name="username"
            placeholder="Username"
            value={form.username}
            onChange={onChangeInput}
          />
          <input
            type="password"
            name="password"
            placeholder="Password"
            value={form.password}
            onChange={onChangeInput}
          />
        </div>

        <div className="btn">
          <button>Login</button>
        </div>
      </form>
    </>
  );
}

export default Login;
