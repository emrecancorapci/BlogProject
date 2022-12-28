import { AxiosRequestConfig } from 'axios'

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
