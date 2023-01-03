import { useContext } from "react";
import * as SecureStore from "expo-secure-store";
import { useQueryClient } from "react-query";
import * as Notifications from "expo-notifications";

import { AuthContext } from "../context";
import { User } from "../types/user";
import { CollocateAccount } from "../types/collocation";
import { queryKeys } from "../constants/constants";
import { alterThemeMode, alterAllowsNotifications, alterPushToken } from "../services/user";
import { socket } from "../constants/socket";
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
    // Nothing else is working so this is my last resort
    const searchCollocations: CollocateAccount[] | undefined = queryClient.getQueryData(
      queryKeys.searchCollocations
    );

    socket.auth = {
      userID: user.id,
      username:
        user.firstName && user.lastName
          ? `${user.firstName} ${user.lastName}`
          : `${user.email}`,
    };
    socket.connect();
    if (searchCollocations) {
      for (let i of searchCollocations) {
        i.areFriends = false;
        if (user.savedCollocations?.includes(i.idAccount)) i.areFriends = true;
      }
      queryClient.setQueryData(queryKeys.searchCollocations, searchCollocations);
    }
  };

  const logout = async () => {
    if (user) {
      const prevUser = { ...user };
      setUser(null);
      SecureStore.deleteItemAsync("user");
      socket.disconnect();
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
