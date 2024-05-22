import { notification } from 'antd';
import axios, { AxiosError, AxiosResponse } from 'axios';
export const http = axios.create({
  baseURL: 'https://localhost:7144/api',
  timeout: 10000,
  headers: {
    Authorization: localStorage.getItem('access_token') ? `Bearer ${localStorage.getItem('access_token')}` : undefined
  },
});

http.interceptors.response.use(
  (response: AxiosResponse) => response,
  (error: AxiosError) => {
    const status = error.response ? error.response.status : 0; 

  if (status >= 500 && status <= 599) {
        notification.error({
          message: 'Something went wrong, please try again later!!',
          duration: 10
        });
      }

    return Promise.reject(error);
  }
);