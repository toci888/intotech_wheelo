import axios from "axios";

import { endpoints } from "../constants/constants";

export const refreshTokens = async (accessToken: string, refreshToken: string) => {
  try {
    const { data } = await axios.post<{
      accessToken: string;
      refreshToken: string;
    }>(endpoints.refreshTokens, {
      accessToken,
      refreshToken
    });

    return data;
  } catch (error) {
    return null;
  }
};
