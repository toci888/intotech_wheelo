/**
 * If you are not familiar with React Navigation, refer to the "Fundamentals" guide:
 * https://reactnavigation.org/docs/getting-started
 *
 */

import { createBottomTabNavigator } from "@react-navigation/bottom-tabs";
import { NavigationContainer, DefaultTheme, DarkTheme } from "@react-navigation/native";
import { createNativeStackNavigator } from "@react-navigation/native-stack";
import * as React from "react";
import { ColorSchemeName } from "react-native";
import { MaterialCommunityIcons } from "@expo/vector-icons";
import { useEffect } from "react";
import * as Notifications from "expo-notifications";

import { AccountScreen } from "../screens/AccountScreen";
import { SavedScreen } from "../screens/SavedScreen";
import { SearchScreen } from "../screens/SearchScreen";
import { FindLocationsScreen } from "../screens/FindLocationsScreen";
import { SignInScreen } from "../screens/SignInScreen";
import { SignUpScreen } from "../screens/SignUpScreen";
import { ForgotPasswordScreen } from "../screens/ForgotPasswordScreen";
import { ResetPasswordScreen } from "../screens/ResetPasswordScreen";
import { MessagePropertyScreen } from "../screens/MessagePropertyScreen";
import { AccountTabParamList, AuthParamList, ChatTabParamList,
  RootStackParamList, RootTabParamList, RootTabScreenProps } from "../types";
import LinkingConfiguration from "./LinkingConfiguration";
import { theme } from "../theme";
import { CollocationDetailsScreen } from "../screens/CollocationDetailsScreen";
import { AddPropertyScreen } from "../screens/AddPropertyScreen";
import { EditPropertyScreen } from "../screens/EditPropertyScreen";
import { MyPropertiesScreen } from "../screens/MyPropertiesScreen";
import { ManageUnitsScreen } from "../screens/ManageUnitsScreen";
import { ReviewScreen } from "../screens/ReviewScreen";
import { useNotifications } from "../hooks/useNotifications";
import { AccountSettingsScreen } from "../screens/AccountSettingsScreen";
import { ConversationsScreen } from "../screens/ConversationsScreen";
import { MessagesScreen } from "../screens/MessagesScreen";
import { CodeVerificationScreen } from "../screens/CodeVerificationScreen";
import { useUser } from "../hooks/useUser";
import { i18n } from "../i18n/i18n";

export default function Navigation({
  colorScheme,
}: {
  colorScheme: ColorSchemeName;
}) {
  DefaultTheme.dark = colorScheme === "dark" ? true : false;
  // DarkTheme.colors = { primary: 'blue', border: 'green', card: 'aqua', 
  //               notification: 'pink', background: 'gray', text: 'red'}
  const myTheme = DefaultTheme.dark ? DarkTheme : DefaultTheme

  myTheme.colors = Object.assign(myTheme.colors, theme)
  
  return (
    <NavigationContainer linking={LinkingConfiguration} theme={myTheme}>
      <RootNavigator colorScheme={colorScheme} />
    </NavigationContainer>
  );
}

/**
 * A root stack navigator is often used for displaying modals on top of all other content.
 * https://reactnavigation.org/docs/modal
 */
const Stack = createNativeStackNavigator<RootStackParamList>();

function RootNavigator(props: any) {
  const { registerForPushNotificationsAsync, handleNotificationResponse } = useNotifications();
  const { user } = useUser();

  useEffect(() => {
    console.log("TU", props.colorScheme);
    console.log("USER", user);
    registerForPushNotificationsAsync();
    Notifications.setNotificationHandler({
      handleNotification: async () => ({
        shouldShowAlert: true,
        shouldPlaySound: true,
        shouldSetBadge: true,
      }),
    });

    const responseListener =
      Notifications.addNotificationResponseReceivedListener(
        handleNotificationResponse
      );

    return () => {
      if (responseListener)
        Notifications.removeNotificationSubscription(responseListener);
    };
  }, []);

  return user ? (
    <Stack.Navigator>
      <Stack.Screen
        name="Root"
        component={BottomTabNavigator}
        options={{ headerShown: false }}
      />

      <Stack.Group screenOptions={{ presentation: "modal" }}>
        <Stack.Screen
          name="FindLocations"
          component={FindLocationsScreen}
          options={{ headerShown: false }}
        />
        <Stack.Screen
          name="PropertyDetails"
          component={CollocationDetailsScreen}
          options={{ headerShown: false }}
        />
        <Stack.Screen
          name="MessageProperty"
          component={MessagePropertyScreen}
          options={{ headerShown: false }}
        />
        <Stack.Screen
          name="AddProperty"
          component={AddPropertyScreen}
          options={{ headerShown: false }}
        />
        <Stack.Screen
          name="EditProperty"
          component={EditPropertyScreen}
          options={{ headerShown: false }}
        />
        <Stack.Screen
          name="MyProperties"
          component={MyPropertiesScreen}
          options={{ headerShown: false }}
        />
        <Stack.Screen
          name="ManageUnits"
          component={ManageUnitsScreen}
          options={{ headerShown: false }}
        />
        <Stack.Screen
          name="Review"
          component={ReviewScreen}
          options={{ headerShown: false }}
        />
      </Stack.Group>
    </Stack.Navigator>)
    :
    <AuthScreenStack />
}

/**
 * A bottom tab navigator displays tab buttons on the bottom of the display to switch screens.
 * https://reactnavigation.org/docs/bottom-tab-navigator
 */
const BottomTab = createBottomTabNavigator<RootTabParamList>();

function BottomTabNavigator() {
  return (
    <BottomTab.Navigator
      initialRouteName="Search"
      screenOptions={{
        tabBarActiveTintColor: theme["color-primary-500"],
      }}
    >
      <BottomTab.Screen
        name="Search"
        component={SearchScreen}
        options={{
          tabBarLabel: i18n.t('Search'),
          headerShown: false,
          tabBarIcon: ({ color }) => (
            <TabBarIcon name="magnify" color={color} />
          ),
        }}
      />
      <BottomTab.Screen
        name='Saved'
        component={SavedScreen}
        options={{
          tabBarLabel: "Osoby",
          headerShown: false,
          tabBarBadge: 5,
          tabBarIcon: ({ color }) => (
            <TabBarIcon name="cards-heart" color={color} />
          ),
        }}
      />
      <BottomTab.Screen
        name='Saved2'
        component={ChatStack}
        options={{
          tabBarLabel: i18n.t('Chat'),
          headerShown: false,
          tabBarIcon: ({ color }) => (
            <TabBarIcon name="chat-outline" color={color} />
          ),
        }}
      />
      <BottomTab.Screen
        name="AccountRoot"
        component={AccountStack}
        options={{
          tabBarLabel: i18n.t('Account'),
          headerShown: false,
          tabBarIcon: ({ color }) => (
            <TabBarIcon name="account" color={color} />
          ),
        }}
      />
    </BottomTab.Navigator>
  );
}

const AccountStackNavigator = createNativeStackNavigator<AccountTabParamList>();
const AccountStack = () => (
  <AccountStackNavigator.Navigator initialRouteName="Account">
    <AccountStackNavigator.Screen
      name="Account"
      component={AccountScreen}
      options={{ headerShown: false }}
    />
    <AccountStackNavigator.Screen
      name="Settings"
      component={AccountSettingsScreen}
      options={{
        headerTitle: "Account Settings",
        headerBackTitle: i18n.t("Back"),
      }}
    />
  </AccountStackNavigator.Navigator>
);

const ChatStackNavigator = createNativeStackNavigator<ChatTabParamList>();
const ChatStack = () => (
  <ChatStackNavigator.Navigator initialRouteName="Chat">
    <ChatStackNavigator.Screen
      name="Conversations"
      component={ConversationsScreen}
      options={{ headerTitle: i18n.t("Chat"), headerBackTitle: i18n.t("Back") }}
    /> 
    <ChatStackNavigator.Screen
      name="Messages"
      component={MessagesScreen}
      options={{
        headerBackTitle: i18n.t("Back"),
      }}
    />
  </ChatStackNavigator.Navigator>
);

const AuthStack = createNativeStackNavigator<AuthParamList>();
const AuthScreenStack = () => (
  <AuthStack.Navigator initialRouteName="Account">
    <AuthStack.Screen
      name="Account"
      component={AccountScreen}
      options={{ headerShown: false }} />
    <AuthStack.Screen
      name="SignIn"
      component={SignInScreen}
      options={{ headerShown: false }} />
    <AuthStack.Screen
      name="SignUp"
      component={SignUpScreen}
      options={{ headerShown: false }} />
    <AuthStack.Screen
      name="ForgotPassword"
      component={ForgotPasswordScreen}
      options={{ headerShown: false }} />
    <AuthStack.Screen
      name="ResetPassword"
      component={ResetPasswordScreen}
      options={{ headerShown: false }} />
    <AuthStack.Screen
      name="CodeVerification"
      component={CodeVerificationScreen}
      options={{ headerShown: false }} />
  </AuthStack.Navigator>
);

/**
 * You can explore the built-in icon families and icons on the web at https://icons.expo.fyi/
 */
function TabBarIcon(props: {
  name: React.ComponentProps<typeof MaterialCommunityIcons>["name"];
  color: string;
}) {
  return (
    <MaterialCommunityIcons size={30} style={{ marginBottom: -3 }} {...props} />
  );
}
