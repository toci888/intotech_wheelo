import axios from "axios";
import { Alert } from "react-native";
import { i18n } from "../i18n/i18n";

import { ErrorRes } from "../types/error";
import { ReturnedResponse } from "../types";

export const handleError = (error: unknown | ReturnedResponse<unknown>) => {
  if (axios.isAxiosError(error)) {
    if (error.response?.data && error.response?.data.isSuccess === false) {
      return Alert.alert(i18n.t('Alert'), (error.response.data as ErrorRes).errorMessage);
    }

    return Alert.alert(error.message);
  }
};

export const commonAlert = (description: string) => {
  return Alert.alert(i18n.t('Alert'), description)
}
