import { useContext } from "react";
import * as SecureStore from "expo-secure-store";
import { useQueryClient } from "react-query";
import * as Notifications from "expo-notifications";
import { DefaultTheme } from "@react-navigation/native";

import { AuthContext } from "../context";
import { User } from "../types/user";
import { CollocateAccount } from "../types/collocation";
import { queryKeys } from "../constants/constants";
import { alterThemeMode, alterAllowsNotifications, alterPushToken } from "../services/user";
import { createSocket, socket } from "../constants/socket";
import { ThemeMode } from "../types";

export const useUser = () => {
  const { user, setUser } = useContext(AuthContext);
  const queryClient = useQueryClient();

  const setAndStoreUser = (user: User) => {
    let stringUser = JSON.stringify(user);
    setUser(user);
    SecureStore.setItemAsync("user", stringUser);
  };

  const login = (user: User) => {
    setAndStoreUser(user);
    
    const searchCollocations: CollocateAccount[] | undefined = queryClient.getQueryData(queryKeys.searchCollocations);

    createSocket(user.accessToken);
    socket.start();

    if (searchCollocations) {
      for (let i of searchCollocations) {
        i.relationshipStatus = false;
        if (user.savedCollocations?.includes(i.idAccount)) i.relationshipStatus = true;
      }
      queryClient.setQueryData(queryKeys.searchCollocations, searchCollocations);
    }
  };

  const logout = async () => {
    if (user) {
      const prevUser = { ...user };
      setUser(null);
      SecureStore.deleteItemAsync("user");
      socket.stop();
      queryClient.clear();
      try {
        const token = (await Notifications.getExpoPushTokenAsync()).data;
        if (token)
          await alterPushToken(user?.id, "remove", token, user.accessToken);
      } catch (error) {
        setAndStoreUser(prevUser);
      }
    }
  };

  const setSavedProperties = (savedProperties: number[]) => {
    if (user) {
      const newUser = { ...user };
      newUser.savedCollocations = savedProperties;
      setAndStoreUser(newUser);
    }
  };

  const addPushToken = async (token: string) => {
    if (user) {
      const updatedUser = { ...user };
      const prevUser = { ...user };

      updatedUser.pushToken = token;

      setAndStoreUser(updatedUser);
      console.log('tokens', token, user.accessToken);
      try {
        await alterPushToken(user.id, "add", token, user.accessToken);
      } catch (error) {
        setAndStoreUser(prevUser);
      }
    }
  };

  const setAllowsNotifications = async (allowed: boolean) => {
    if (user) {
      const updatedUser = { ...user };
      const prevUser = { ...user };
      updatedUser.allowsNotifications = allowed;
      setAndStoreUser(updatedUser);

      try {
        await alterAllowsNotifications(user.id, allowed, user.accessToken);
      } catch (error) {
        console.error(error);
        setAndStoreUser(prevUser);
      }
    }
  };

  const setDarkMode = async (darkMode: boolean) => {
    if (user) {
      const updatedUser = { ...user };
      const prevUser = { ...user };
      updatedUser.darkMode = darkMode;
      setAndStoreUser(updatedUser);
      DefaultTheme.dark = !DefaultTheme.dark;
      try {
        await alterThemeMode(user.id, darkMode, user.accessToken);
      } catch (error) {
        console.error(error);
        setAndStoreUser(prevUser);
      }
    }
  };

  return {
    user,
    login,
    logout,
    setSavedProperties,
    addPushToken,
    setAllowsNotifications,
    setDarkMode
  };
};
