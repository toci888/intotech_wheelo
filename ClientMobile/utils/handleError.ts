import axios from "axios";
import { Alert } from "react-native";

import { ErrorRes } from "../types/error";

export const handleError = (error: unknown) => {
  if (axios.isAxiosError(error)) {
    if (error.response?.data.isSuccess === false) {
      return Alert.alert('Komunikat', (error.response.data as ErrorRes).errorMessage);
    }

    return alert(error.message);
  }
};
