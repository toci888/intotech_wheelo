import React from "react";
import { View, StyleSheet, ViewStyle, Text } from "react-native";
import { Button } from "@ui-kitten/components";
import { useNavigation } from "@react-navigation/native";

import { theme } from "../theme";
import { GoogleButton } from "./GoogleButton";
import { FacebookButton } from "./FacebookButton";
import { AppleButton } from "./AppleButton";
import { OrDivider } from "./OrDivider";
import { useAuth } from "../hooks/useAuth";
import useTheme from "../hooks/useTheme";
import { i18n } from "../i18n/i18n";
import { WheeloLogo } from "./logos/WheeloLogo";
import { WheeloIcon } from "./logos/WheeloIcon";

export const SignUpAndSignInButtons = ({ style }: { style?: ViewStyle }) => {
  const navigation = useNavigation();
  const { colors } = useTheme();

  return (
    <View style={styles.container}>
      <WheeloLogo />
      <WheeloIcon />
      <Text style={[styles.bodyText, { color: colors.lightGray }]}>{i18n.t("WheeloSloganTitle")}</Text>
      <Text style={[styles.bodyText, { color: colors.lightGray }]}>{i18n.t("WheeloSloganSubtitle")}</Text>
      
      
      <Button onPress={() => navigation.navigate("SignIn")} style={{
        backgroundColor: colors.primary, borderColor: colors.primary,
        width: '100%', marginLeft: 'auto', marginRight: 'auto'
      }}>{i18n.t("SignIn")}</Button>
      
      <Button appearance="outline" onPress={() => navigation.navigate("SignUp")} style={{
        borderColor: colors.primary, width: '100%', marginLeft: 'auto', marginRight: 'auto'
      }}>
        {i18n.t("SignUp")}
      </Button>
      <Text style={[styles.bodyText, { color: colors.lightGray }]}>{i18n.t("OrSignInWith")}</Text>
    </View>
  );
};



const styles = StyleSheet.create({
  signUpButton: {
    marginVertical: 10,
    borderColor: theme["color-primary-500"],
  },
  container: {
    flex: 1,
    display: "flex",
    justifyContent: "center", /* Centrowanie poziome */
    alignItems: "center", /* Centrowanie w pionie */
    marginTop: 150,
  },
  defaultMarginHorizontal: { marginHorizontal: 10 },
  userName: {
    textAlign: "center",
    fontWeight: "600",
    marginBottom: 5,
    textTransform: "capitalize",
  },
  email: {
    textAlign: "center",
    fontWeight: "500",
    marginBottom: 20,
  },
  header: {
    textAlign: "center",
    marginVertical: 25,
    marginHorizontal: 70,
    fontWeight: "600",
    fontSize: "44px",
  },
  middleContainer: {
    justifyContent: "center",
    alignItems: "center",
    paddingTop: 30,
    paddingBottom: 50,
    borderTopColor: theme["color-gray"],
    borderTopWidth: 2,
  },
  subheader: { textAlign: "center", paddingHorizontal: 20 },
  bodyText: {
    marginTop: 10,
    textAlign: "center",
    marginHorizontal: 15,
    marginBottom: 15,
  },
  button: { marginBottom: 15 },
  specialMarginVertical: { marginTop: 30, marginBottom: 20 },
  link: { fontWeight: "600" },
  orContainer: {
    marginVertical: 30,
  },
  brandText: {
    textAlign: "center",
  },
});
