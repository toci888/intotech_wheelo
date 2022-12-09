import * as Device from "expo-device";
import * as Notifications from "expo-notifications";
import { Alert, Linking, Platform } from "react-native";
import { openSettings } from "expo-linking";

import { useUser } from "./useUser";
import { os } from "../constants/constants";

export const useDarkMode = () => {
  const { setDarkMode, user } = useUser();

  const registerForDarkModeAsync = async (alertUser?: boolean) => {
    if (!user) return;
    // const { status: existingStatus } =
    // await Notifications.getPermissionsAsync();
    // let finalStatus = existingStatus;
    // if (existingStatus !== "granted") {
    // const { status } = await Notifications.requestPermissionsAsync();
    // finalStatus = status;
    // }

    // if (finalStatus !== "granted") {
    // if (alertUser)
    //     Alert.alert(
    //     "Error",
    //     "To enable Push Notifications please change your settings.",
    //     [
    //         {
    //         text: "OK",
    //         },
    //         {
    //         text: "Open Settings",
    //         onPress: openSettings,
    //         },
    //     ]
    //     );

    // if (user.allowsNotifications) setAllowsNotifications(false);
    // throw new Error("User doesn't allow for notifications");
    // }
    // const token = (await Notifications.getExpoPushTokenAsync()).data;

    // addPushToken(token);
    // if (!user.allowsNotifications) setAllowsNotifications(true);

    // if (Platform.OS === os.android) {
    //   Notifications.setNotificationChannelAsync("default", {
    //     name: "default",
    //     importance: Notifications.AndroidImportance.MAX,
    //     vibrationPattern: [0, 250, 250, 250],
    //     lightColor: "#FF231F7C",
    //   });
    // }
  };

  return {
    registerForDarkModeAsync
  };
};
