import * as Device from "expo-device";
import * as Notifications from "expo-notifications";
import { Alert, Linking, Platform } from "react-native";
import { openSettings } from "expo-linking";

import { useUser } from "./useUser";
import { os } from "../constants/constants";
import { i18n } from "../i18n/i18n";
import { openURL } from "../utils/openURL";
import * as WebBrowser from "expo-web-browser";
import { useNavigation } from "@react-navigation/native";

export const useNotifications = () => {
  const { addPushToken, setAllowsNotifications, user } = useUser();
  const navigation = useNavigation();

  const registerForPushNotificationsAsync = async (alertUser?: boolean) => {
    if (Device.isDevice) {
      if (!user) return;
      const { status: existingStatus } = await Notifications.getPermissionsAsync();
      let finalStatus = existingStatus;
      if (existingStatus !== "granted") {
        const { status } = await Notifications.requestPermissionsAsync();
        finalStatus = status;
      }

      if (finalStatus !== "granted") {
        if (alertUser)
          Alert.alert(i18n.t('Alert'), i18n.t('ToEnablePushNotificationsPleaseChangeYourSettings'),
            [
              {
                text: i18n.t('Ok'),
              },
              {
                text: i18n.t('OpenSettings'),
                onPress: openSettings,
              },
            ]
          );

        if (user.allowsNotifications) setAllowsNotifications(false);
        throw new Error("User doesn't allow for notifications");
      }
      const token = (await Notifications.getExpoPushTokenAsync()).data;
      
      addPushToken(token);
      if (!user.allowsNotifications) setAllowsNotifications(true);
    } else {
      alert("Must use physical device for Push Notifications");
    }

    if (Platform.OS === os.android) {
      Notifications.setNotificationChannelAsync("default", {
        name: "default",
        importance: Notifications.AndroidImportance.MAX,
        vibrationPattern: [0, 250, 250, 250],
        lightColor: "#FF231F7C",
      });
    }
  };

  // This listener is fired whenever a notification is received while the app is foregrounded
  const handleNotification = (notification: Notifications.Notification) => {
    console.log("dostalem notyfikacje")
    // could be useful if you want to display your own toast message
    // could also make a server call to refresh data in other part of the app
  };

  // This listener is fired whenever a user taps on or interacts with a notification (works when app is foregrounded, backgrounded, or killed)
  const handleNotificationResponse = (
    response: Notifications.NotificationResponse
  ) => {
    const data: { url?: string } = response.notification.request.content.data;
    
    if (data) {
      console.log("WESZLES", data);
      // navigation.navigate("AccountRoot", {screen: "Settings"}) // types.tsx RootTabParamList / AccountTabParamList
      // navigation.navigate("Root", {screen: "Saved"})
      // navigation.navigate("Root", {screen: "AccountRoot"});
    }
    // process.env
    //Linking.openURL(data.url);
    // WebBrowser.openBrowserAsync("WWW.GOOGLE.COM/kotki")
    // openURL("WWW.GOOGLE.COM/kotki")
  };

  return {
    registerForPushNotificationsAsync,
    handleNotification,
    handleNotificationResponse,
  };
};
