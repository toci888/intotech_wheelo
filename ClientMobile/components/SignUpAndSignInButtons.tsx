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

export const SignUpAndSignInButtons = ({ style }: { style?: ViewStyle }) => {
  const navigation = useNavigation();
  const { nativeLogin, facebookAuth, googleAuth, appleAuth } = useAuth();
  const { colors } = useTheme();
  return (
    <View style={style}>
      <Text style={[styles.bodyText, {color: colors.lightGray}]}>Zaloguj się, aby rozpocząć</Text>
      <Button onPress={() => navigation.navigate("SignIn")} style={{backgroundColor: colors.primary, borderColor: colors.primary, width: '70%',marginLeft:'auto', marginRight: 'auto', shadowColor:'red', shadowOpacity: 10,shadowOffset: {width:10, height:10}} }>Zaloguj</Button>
      <Text style={[styles.bodyText, {color: colors.lightGray}]}>
        {i18n.t('YouDontHaveAnAccountYet')}{" "}
        <Text style={[styles.link, {color: colors.primary}]} onPress={() => navigation.navigate("SignUp")}>
          {i18n.t("SignUp")}
        </Text>
      </Text>
      <OrDivider style={styles.orContainer} />

      <GoogleButton
        text={i18n.t('ContinueWithGoogle')}
        style={styles.button}
        onPress={async () => await googleAuth()}
      />
      <FacebookButton
        text={i18n.t('ContinueWithFacebook')}
        style={styles.button}
        onPress={async () => await facebookAuth()}
      />
      <AppleButton type="sign-in" onPress={async () => await appleAuth()} />
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
