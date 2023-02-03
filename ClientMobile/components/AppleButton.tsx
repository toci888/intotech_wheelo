import React from "react";
import { Platform, StyleSheet, View, ViewStyle } from "react-native";
import * as AppleAuthentication from "expo-apple-authentication";

export const AppleButton = ({
  type,
  onPress,
  style,
}: {
  type: "sign-in" | "sign-up";
  onPress: () => void;
  style?: ViewStyle;
}) => {
  if (Platform.OS !== "ios") return null;
  if (!AppleAuthentication.isAvailableAsync()) return null;

  return (
    <AppleAuthentication.AppleAuthenticationButton
      buttonType={
        type === "sign-in"
          ? AppleAuthentication.AppleAuthenticationButtonType.CONTINUE
          : AppleAuthentication.AppleAuthenticationButtonType.SIGN_UP
      }
      buttonStyle={AppleAuthentication.AppleAuthenticationButtonStyle.BLACK}
      cornerRadius={5}
      borderRadius={5}
      style={styles.button}
      onPress={onPress}
    />
  );
};

const styles = StyleSheet.create({
  button: {
    borderRadius: 5,
    padding: 10,
    borderWidth: 2,

  },
});
