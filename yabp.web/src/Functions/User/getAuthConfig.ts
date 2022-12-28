import { AxiosRequestConfig } from 'axios'

const getAuthConfig = () => {
    const storage = sessionStorage.getItem('user');
    const token = storage ? JSON.parse(storage) : null;

    const config: AxiosRequestConfig = {
        headers: {
          'Content-Type': 'application/json',
          'Authorization': `Bearer ${token}`,
        },
      };

    return config;
}

export default getAuthConfig;