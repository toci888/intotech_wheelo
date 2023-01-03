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

export const SignUpAndSignInButtons = ({ style }: { style?: ViewStyle }) => {
  const navigation = useNavigation();
  const { nativeLogin, facebookAuth, googleAuth, appleAuth } = useAuth();

  return (
    <View style={style}>
      <Text style={styles.bodyText}>Zaloguj się, aby rozpocząć</Text>
      <Button onPress={() => navigation.navigate("SignIn")}>Zaloguj</Button>
      <Text style={styles.bodyText}>
        Nie masz jeszcze konta?{" "}
        <Text style={styles.link} onPress={() => navigation.navigate("SignUp")}>
          Zarejestruj się
        </Text>
      </Text>
      <OrDivider style={styles.orContainer} />

      <GoogleButton
        text="Continue with Google"
        style={styles.button}
        onPress={async () => await googleAuth()}
      />
      <FacebookButton
        text="Continue with Facebook"
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
    color: theme["color-violet"],
  },
  button: { marginBottom: 15, borderColor: theme["color-primary-500"] },
  specialMarginVertical: { marginTop: 30, marginBottom: 20 },
  link: { fontWeight: "600", color: theme["color-violet"] },
  orContainer: {
    marginVertical: 30,
  },
  brandText: {
    textAlign: "center",
  },
});
