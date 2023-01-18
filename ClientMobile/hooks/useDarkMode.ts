import * as Device from "expo-device";
import { Alert, Linking, Platform } from "react-native";
import { openSettings } from "expo-linking";
import { DefaultTheme } from "@react-navigation/native";

import { useUser } from "./useUser";
import { os } from "../constants/constants";
import useColorScheme from "./useColorScheme";

export const useDarkMode = () => {
  const isDarkMode = useColorScheme
  const { setDarkMode, user } = useUser();
  const isDarkModeEnabled = () => {
    return user?.darkMode;
  }
  
  const registerForDarkModeAsync = async (alertUser?: boolean) => {
    if (!user) return;

    DefaultTheme.dark = !DefaultTheme.dark;
  };

  return {
    registerForDarkModeAsync,
    isDarkModeEnabled
  };
};
