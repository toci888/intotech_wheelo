import axios from 'axios';
import { useUser } from '../hooks/useUser';

export const useApiClient = () => {
  const { user } = useUser();

  const headers = () => {
    return {
      headers: //{"Authorization": ""}
      {
        'Content-Type': 'application/json',
        ...(user && {
          Authorization: `Bearer ${user.accessToken}`,
        }),
        timeout: 10 * 1000,
      }
    }
  };

  const Get = async (url: string) => {
    try {
      const response = await axios.get(url, headers().headers);
      return response.data;
    } catch (error) {
      handleServiceError(error);
    }
    return {};
  }

  const Delete = async (url: string) => {
    try {
      const response = await axios.delete(url, headers().headers)
      return response.data;
    } catch (error) {
      handleServiceError(error);
    }
    return {};
  }
  
  const Patch = async (url: string, body: object) => {
    try {
      const response = await axios.patch(url, body, headers().headers);
      return response.data;
    } catch (error) {
      handleServiceError(error);
    }
    return {};
  }
  
  const Put = async (url: string, body: object) => {
    try {
      const response = await axios.put(url, body, headers().headers);
      return response.data;
    } catch (error) {
      handleServiceError(error);
    }
    return {};
  }
  
  const Post = async (url: string, body: object) => {
    try {
      const response = await axios.post(url, body, headers().headers)
      return response.data;
    } catch (error) {
      handleServiceError(error);
    }
    return {};
  }

  return {
    Get,
    Delete,
    Patch,
    Post,
    Put
  }
}

function handleServiceError(error: unknown) {
  console.log("ERROR:", error);
}
