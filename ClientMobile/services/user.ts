import axios from "axios";

import { endpoints } from "../constants/constants";
import { User } from "../types/user";
import { commonAlert, handleError } from "../utils/handleError";
import * as Crypto from 'expo-crypto';
import { loginDto, registerDto, ThemeMode as boolean } from "../types";
import { ReturnedResponse } from "../types";

export const registerUser = async (values: registerDto) => {
  try {
    values.password = await Crypto.digestStringAsync(Crypto.CryptoDigestAlgorithm.SHA256, values.password);
    values.method = 'wheelo';

    const { data } = await axios.post(endpoints.register, values);
    return data as ReturnedResponse<User>;
  } catch (error) {
    handleError(error);
  }
};

export const loginUser = async (values: loginDto) => {
  try {
    values.password = await Crypto.digestStringAsync(Crypto.CryptoDigestAlgorithm.SHA256, values.password);
    values.method = 'wheelo';
    values.token = '';
    console.log("HASZ", values.password)
    const { data } = await axios.post(endpoints.login, values);
    return data as ReturnedResponse<User>;
  } catch (error) {
    handleError(error);
  }
};

export const facebookLoginOrRegister = async (token: string) => {
  try {
    const { data } = await axios.post(endpoints.login, {
      token, method: 'facebook', email: "", password: ""
    });
    return data as ReturnedResponse<User>;
  } catch (error) {
    handleError(error);
  }
};

export const googleLoginOrRegister = async (token: string) => {
  try {
    const { data } = await axios.post(endpoints.login, {
      token, method: 'google', email: "", password: ""
    });
    return data as ReturnedResponse<User>;
  } catch (error) {
    handleError(error);
  }
};

export const appleLoginOrRegister = async (token: string) => {
  try {
    const user: ReturnedResponse<User> = await axios.post(endpoints.login, {
      token, method: 'apple',
    });
    return user;
  } catch (error) {
    handleError(error);
  }
};

export const forgotPassword = async (email: string) => {
  try {
    const { data } = await axios.post(endpoints.forgotPassword, { email });
    
    if(data.isSuccess === false) {
      commonAlert(data.errorMessage)
    }
    return data as ReturnedResponse<number>;
  } catch (error) {
    handleError(error);
  }
};

export const resetPassword = async (password: string, token: string, email: string) => {
  try {
    password = await Crypto.digestStringAsync(Crypto.CryptoDigestAlgorithm.SHA256, password);
    console.log("RESET PASSWORD", endpoints.resetPassword, { password, email, token })
    const { data } = await axios.post(endpoints.resetPassword,
      { password, email, token }
      // {
      //   headers: {
      //     Authorization: `Bearer ${token}`,
      //   },
      // }
    );

    return data;
  } catch (error: any) {
    // if (error.response.status === 401) return alert("Invalid or Expired Token");

    alert("Unable to reset password.");
  }
};

export const alterPushToken = (
  userID: number,
  op: "add" | "remove",
  pushToken: string,
  token: string
) => {
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
}

export const alterAllowsNotifications = (
  userID: number,
  allowsNotifications: boolean,
  token: string
) => {
  axios.patch(
    endpoints.allowsNotifications(userID),
    { allowsNotifications },
    {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    }
  );
}

  export const alterThemeMode = (
    userID: number,
    darkMode: boolean,
    token: string
  ) =>{
    console.log("TUTAJ")
    console.log("DARKMODE", endpoints.themeMode(userID, darkMode), userID, darkMode,
    { allowsDarkMode: darkMode }, {Authorization: `Bearer ${token}`})

    axios.patch(endpoints.themeMode(userID, darkMode),
      { allowsDarkMode: darkMode },
      {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      }
    );
  }
