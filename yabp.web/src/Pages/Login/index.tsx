import {Dispatch, SetStateAction} from 'react';
import {useFormik} from 'formik';
import axios from 'axios';

import getApi from '../../Functions/Common/getApi';


/**
 * @description Form to login
 *
 * @param {function} setAuth - Sets the authentication state
 * @return {JSX.Element} - Form element
 */

type Fields = {
  username: string,
  password: string,
}

function Login({setAuth}: {setAuth: Dispatch<SetStateAction<boolean>>}): JSX.Element {
  const api = getApi('Users/Login');
  const fetchData = async (values : Fields) => await axios.post(api, values);

  const formik = useFormik({
    initialValues: {
      username: '',
      password: '',
    },
    onSubmit: (values : Fields) => {
      fetchData(values)
          .then((response) => {
            if (response.data) {
              sessionStorage.setItem('user', JSON.stringify(response.data));
              setAuth(true);
            }
          })
          .catch((event) => console.log(event));
    },
  });

  return (
    <>
      <form onSubmit={formik.handleSubmit}>
        <div>
          <input
            id='username'
            name="username"
            type="text"
            placeholder="Username"
            value={formik.values.username}
            onChange={formik.handleChange}
          />
          <input
            id='password'
            name="password"
            type="password"
            placeholder="Password"
            value={formik.values.password}
            onChange={formik.handleChange}
          />
          <button type="submit">Login</button>
        </div>
      </form>
    </>
  );
}

export default Login;
