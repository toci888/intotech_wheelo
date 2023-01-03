import React from "react";
import { StyleSheet } from "react-native";
import { Text, Toggle } from "@ui-kitten/components";

import { Screen } from "../components/Screen";
import { useUser } from "../hooks/useUser";
import { Row } from "../components/Row";
import { useNotifications } from "../hooks/useNotifications";
import { useDarkMode } from "../hooks/useDarkMode";

export const AccountSettingsScreen = () => {
  const { user, setAllowsNotifications, setDarkMode } = useUser();
  const { registerForPushNotificationsAsync } = useNotifications();
  const { registerForDarkModeAsync } = useDarkMode();

  const notificationsChanged = async (checked: boolean) => {
    try {
      if (!checked) return setAllowsNotifications(checked);

      setAllowsNotifications(checked);
      await registerForPushNotificationsAsync(true);
    } catch (error) {
      setAllowsNotifications(!checked);
    }
  };

  const darkModeChanged = async (checked: boolean) => {
    try {
      if (!checked) return setDarkMode(checked);

      setDarkMode(checked);
      await registerForDarkModeAsync(true);
    } catch (error) {
      setDarkMode(!checked);
    }
  };

  return (
    <Screen style={styles.container}>
      <Row style={styles.row}>
        <Text>Notifications</Text>
        <Toggle
          checked={user?.allowsNotifications}
          onChange={notificationsChanged}
        />
      </Row>
      <Row style={styles.row}>
        <Text>Dark mode</Text>
        <Toggle
          checked={user?.darkMode}
          onChange={darkModeChanged}
        />
      </Row>
    </Screen>
  );
};

const styles = StyleSheet.create({
  container: {
    marginHorizontal: 10,
    marginTop: 20,
  },
  header: {
    textAlign: "center",
  },
  row: {
    justifyContent: "space-between",
    marginTop: 15,
  },
});
