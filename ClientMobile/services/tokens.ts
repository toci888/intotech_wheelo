import axios from "axios";

import { endpoints } from "../constants/constants";
import { ReturnedResponse } from "../types";

export const refreshTokens = async (accessToken: string, refreshToken: string) => {
  try {
    console.log("NOWYTOKENx", endpoints.refreshTokens, {accessToken,refreshToken})
    const { data } = await axios.post<ReturnedResponse<{
      accessToken: string;
      refreshToken: string;
    }>>(endpoints.refreshTokens, {
      accessToken,
      refreshToken
    });

    console.log("DATATOKENx", data)
    if (data.methodResult) {
      return data.methodResult;
    }
    return;
  } catch (error) {
    return null;
  }
};
