import React from "react";
import { View, StyleSheet } from "react-native";
import { Text } from "@ui-kitten/components";
import LottieView from "lottie-react-native";

import { Screen } from "../components/Screen";
import { ModalHeader } from "../components/ModalHeader";
import { SignUpAndSignInButtons } from "../components/SignUpAndSignInButtons";

export const SignUpOrSignInScreen = () => {
  return (
    <Screen>
      <ModalHeader text="Wheelo" xShown />
      <View style={styles.container}>
        <SignUpAndSignInButtons />
      </View>
    </Screen>
  );
};

const styles = StyleSheet.create({
  container: { marginHorizontal: 10 },
  header: { marginVertical: 20, textAlign: "center" },
  lottie: {
    marginBottom: 50,
    height: 250,
    width: 250,
    alignSelf: "center",
  },
  text: {
    textAlign: "center",
  },
  bottomText: {
    marginTop: 10,
    marginBottom: 30,
  },
});
