import { AxiosRequestConfig } from 'axios'

/**
 * @description Get the user token from the session storage and return the config object for the axios request
 *
 * @return {AxiosRequestConfig} Axios request config object
 */

const getAuthConfig: () => AxiosRequestConfig = () => {
  const storage = sessionStorage.getItem('user');
  const token: string = storage !== null ? JSON.parse(storage) : null;

  const config: AxiosRequestConfig = {
    headers: {
      'Content-Type': 'application/json',
      Authorization: `Bearer ${token}`
    }
  };

  return config;
}

export default getAuthConfig;
