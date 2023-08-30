import React from "react";
import { View, StyleSheet, Text, Pressable } from "react-native";
import { useNavigation } from "@react-navigation/native";

import { GoogleButton } from "./GoogleButton";
import { FacebookButton } from "./FacebookButton";
import { AppleButton } from "./AppleButton";
import { useAuth } from "../hooks/useAuth";
import useTheme from "../hooks/useTheme";
import { i18n } from "../i18n/i18n";
import { WheeloLogo } from "./logos/WheeloLogo";
import { WheeloIcon } from "./logos/WheeloIcon";
import { LinkedLogo } from "./logos/LinkedLogo";

export const SignUpAndSignInButtons = () => {
  const navigation = useNavigation();
  const { colors } = useTheme();
  const { facebookAuth, googleAuth, appleAuth } = useAuth();

  return (
    <View style={styles.container}>
      <WheeloLogo style={{ marginTop: 20, marginBottom: 70 }} />
      <WheeloIcon style={{ marginBottom: 70 }} />
      <Text style={styles.sloganTitle}>{i18n.t("WheeloSloganTitle")}</Text>
      <Text style={styles.sloganSubtitle}>{i18n.t("WheeloSloganSubtitle")}</Text>
      <Pressable onPress={() => navigation.navigate("SignIn")} style={styles.signInButtonContainer}>
        <View style={styles.signInButton}>
          <Text style={styles.SignInTxt}>{i18n.t("SignIn")}</Text>
        </View>
      </Pressable>
      <Pressable onPress={() => navigation.navigate("SignUp")} style={styles.signUpButton}>
        <Text style={styles.SignUpTxt}>{i18n.t("SignUp")}</Text>
      </Pressable>
      <Text style={styles.bodyText}>{i18n.t("OrSignInWith")}</Text>
      <View style={styles.socialButtonContainer}>
        <GoogleButton
          text={i18n.t('ContinueWithGoogle')}
          style={{ borderColor: colors.text, marginRight: 30 }}
          onPress={async () => await googleAuth()}
        />
        <FacebookButton
          text={i18n.t('ContinueWithFacebook')}
          style={{ borderColor: colors.text, marginRight: 30 }}
          onPress={async () => await facebookAuth()}
        />
        <LinkedLogo style={{ marginRight: 30 }} />
        <AppleButton
          type="sign-in"
          onPress={async () => await appleAuth()}
          style={{ borderColor: colors.text }}
        />
      </View>
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    display: "flex",
    justifyContent: "center",
    alignItems: "center",
  },
  socialButtonContainer:
  {
    flexDirection: 'row',
  },
  sloganTitle: {
    textAlign: "center",
    fontSize: 46,
    fontStyle: "normal",
    fontWeight: "700",
    lineHeight: 120,
    marginBottom: -70,
  },
  sloganSubtitle: {
    textAlign: "center",
    fontSize: 46,
    fontStyle: "normal",
    fontWeight: "700",
    lineHeight: 120,
  },
  signInButton: {
    display: 'flex',
    paddingVertical: 14,
    paddingHorizontal: 40,
    alignSelf: 'stretch',
    backgroundColor: '#9C4DC7',
    borderRadius: 99,
    width: 310,
    alignItems: 'center',
    justifyContent: 'center',
  },
  signInButtonContainer: {
    marginBottom: 30,
  },
  signUpButton: {
    marginBottom: 30,
    color: '#DBC2F5'
  },
  SignInTxt: {
    color: '#DBC2F5',
    fontSize: 20,
  },
  SignUpTxt: {
    color: '#DBC2F5',
    fontSize: 20,
  },
  bodyText: {
    marginTop: 10,
    textAlign: "center",
    marginHorizontal: 15,
    marginBottom: 30,
    color: '#DBC2F5'
  }
});
