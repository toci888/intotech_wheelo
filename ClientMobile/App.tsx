import React from "react";
import { StatusBar } from "expo-status-bar";
import { SafeAreaProvider } from "react-native-safe-area-context";
import * as eva from "@eva-design/eva";
import { ApplicationProvider } from "@ui-kitten/components";
import { QueryClient, QueryClientProvider } from "react-query";
import { useState, useEffect } from "react";
import * as SecureStore from "expo-secure-store";
import { LogBox } from "react-native";
import * as Notifications from "expo-notifications";

import useCachedResources from "./hooks/useCachedResources";
import useColorScheme from "./hooks/useColorScheme";
import Navigation from "./navigation";
import { theme } from "./theme";
import { AuthContext, LoadingContext } from "./context";
import { User } from "./types/user";
import { socket } from "./constants/socket";
import { queryKeys } from "./constants/constants";
import { refreshTokens } from "./services/tokens";

const queryClient = new QueryClient();
LogBox.ignoreAllLogs();

export default function App() {
  const isLoadingComplete = useCachedResources();
  const colorScheme = useColorScheme();
  const [user, setUser] = useState<User | null>(null);
  const [loading, setLoading] = useState<boolean>(false);
  
  useEffect(() => {
    async function getUser() {
      const user = await SecureStore.getItemAsync("user");
      if (user) {
        const userObj: User = JSON.parse(user);
        const newTokens = await refreshTokens(userObj.accessToken, userObj.refreshtoken);
        if (newTokens) {
          userObj.accessToken = newTokens.accessToken;
          userObj.refreshtoken = newTokens.refreshToken;
          SecureStore.setItemAsync("user", JSON.stringify(userObj));
        }
        setUser(userObj);

        socket.on(
          "getMessage",
          (message: { chatMessage: {
            id: number;
            senderID: number;
            text: string;
            createdAt: Date;
            authorFirstName: string;
            authorLastName: string;
          }}) => {
            let data = message.chatMessage;

            queryClient.invalidateQueries(queryKeys.conversations);
            queryClient.invalidateQueries(queryKeys.selectedConversation);
  
            Notifications.scheduleNotificationAsync({
              content: {
                title: data.authorFirstName,
                body: data.text,
                data: {
                  // will need to change url in prod build (use process.ENV && eas.json)
                  url: `exp://192.168.1.5:19000/--/messages/${data.id}/${data.authorFirstName}`,
                },
              },
              trigger: null,
            });
          }
        );
        socket.on("session", (sessionData: {data: {userId: number, userName: string, userSurname: string, sessionId: number}}) => {
          let data = sessionData.data;

          if (userObj) {
            const updatedUser = { ...userObj };
            updatedUser.sessionID = data.sessionId.toString();
            setUser(updatedUser);
            SecureStore.setItemAsync("user", JSON.stringify(updatedUser));
          }
        });
        socket.on("connect_error", (err) => {
          if (err.message === "Invalid userID" && user) {
            socket.start();
          }
        });
        
        await socket.start();
        await socket.invoke("ConnectUser", userObj.id, userObj.accessToken);
      }
    }

    getUser();

    return () => {
      socket.off("getMesssage");
      socket.off("session");
      socket.off("connect_error");
    };
  }, []);

  if (!isLoadingComplete) {
    return null;
  } else {
    return (
      <LoadingContext.Provider value={{ loading, setLoading }}>
        <AuthContext.Provider value={{ user, setUser }}>
          <QueryClientProvider client={queryClient}>
            <ApplicationProvider {...eva} theme={theme}>
              <SafeAreaProvider>
                <Navigation colorScheme={colorScheme} />
                <StatusBar />
              </SafeAreaProvider>
            </ApplicationProvider>
          </QueryClientProvider>
        </AuthContext.Provider>
      </LoadingContext.Provider>
    );
  }
}
