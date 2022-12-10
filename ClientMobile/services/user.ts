import axios from "axios";

import { endpoints } from "../constants/constants";
import { User } from "../types/user";
import { handleError } from "../utils/handleError";
import * as Crypto from 'expo-crypto';
import { useUser } from "../hooks/useUser";

type DataRes = { data: User };

export const registerUser = async (
  firstName: string,
  lastName: string,
  email: string,
  password: string,
) => {
  try {
    password = await Crypto.digestStringAsync(Crypto.CryptoDigestAlgorithm.SHA256, password);
    const { data }: DataRes = await axios.post(endpoints.register, {
      method: 'wheelo',
      email,
      password,
      firstName,
      lastName,
    });
    return data;
  } catch (error) {
    handleError(error);
  }
};

export const loginUser = async (email: string, password: string) => {
  try {
    password = await Crypto.digestStringAsync(Crypto.CryptoDigestAlgorithm.SHA256, password);
    const { data }: DataRes = await axios.post(endpoints.login, {
      method: 'wheelo',
      email,
      password,
    });
    return data;
  } catch (error) {
    handleError(error);
  }
};

export const facebookLoginOrRegister = async (token: string) => {
  try {
    const { data }: DataRes = await axios.post(endpoints.login, {
      token, method: 'facebook',
    });
    return data;
  } catch (error) {
    handleError(error);
  }
};

export const googleLoginOrRegister = async (token: string) => {
  try {
    const { data }: DataRes = await axios.post(endpoints.login, {
      token, method: 'google',
    });
    return data;
  } catch (error) {
    handleError(error);
  }
};

export const appleLoginOrRegister = async (token: string) => {
  try {
    const { data }: DataRes = await axios.post(endpoints.login, {
      token, method: 'apple',
    });
    return data;
  } catch (error) {
    handleError(error);
  }
};

export const forgotPassword = async (email: string) => {
  try {
    const { data } = await axios.post<{ emailSent: boolean }>(
      endpoints.forgotPassword,
      { email }
    );

    return data;
  } catch (error) {
    handleError(error);
  }
};

export const resetPassword = async (password: string, token: string) => {
  try {
    const { data } = await axios.post(
      endpoints.resetPassword,
      { password },
      {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      }
    );

    return data;
  } catch (error: any) {
    if (error.response.status === 401) return alert("Invalid or Expired Token");

    alert("Unable to reset password.");
  }
};

export const alterPushToken = (
  userID: number,
  op: "add" | "remove",
  pushToken: string,
  token: string
) =>
  axios.patch(
    endpoints.alterPushToken(userID),
    {
      op,
      token: pushToken,
    },
    {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    }
  );

export const alterAllowsNotifications = (
  userID: number,
  allowsNotifications: boolean,
  token: string
) =>
  axios.patch(
    endpoints.allowsNotifications(userID),
    { allowsNotifications },
    {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    }
  );
