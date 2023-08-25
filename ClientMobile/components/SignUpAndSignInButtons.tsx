import React from "react";
import { View, StyleSheet, Text, Pressable } from "react-native";
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

export const SignUpAndSignInButtons = () => {
  const navigation = useNavigation();
  const { colors } = useTheme();
  
  return (
    <View style={styles.container}>
      <WheeloLogo />
      <WheeloIcon />
      <Text style={styles.sloganTitle}>{i18n.t("WheeloSloganTitle")}</Text>
      <Text style={styles.sloganSubtitle}>{i18n.t("WheeloSloganSubtitle")}</Text>

      <Pressable onPress={() => navigation.navigate("SignIn")} style={styles.signInButton}>
        <Text>{i18n.t("SignIn")}</Text>
      </Pressable>
        
      <Pressable onPress={() => navigation.navigate("SignUp")} style={styles.signUpButton}>
        <Text>{i18n.t("SignUp")}</Text>
      </Pressable>
      <Text style={styles.bodyText}>{i18n.t("OrSignInWith")}</Text>
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    display: "flex",
    justifyContent: "center",
    alignItems: "center",
  },
  sloganTitle: {

  },
  sloganSubtitle: {

  },
  signInButton: {

  },
  signUpButton: {

  },
  bodyText: {
    marginTop: 10,
    textAlign: "center",
    marginHorizontal: 15,
    marginBottom: 15,
    color: '#DBC2F5'
  }
});
