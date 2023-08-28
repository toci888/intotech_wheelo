import React from "react";
import { StyleSheet, TouchableOpacity, ViewStyle } from "react-native";
import * as WebBrowser from "expo-web-browser";
import { Text } from "@ui-kitten/components";

import { FacebookLogo } from "./logos/FacebookLogo";

WebBrowser.maybeCompleteAuthSession();

export const FacebookButton = ({
  text,
  onPress,
  style,
}: {
  text: string;
  onPress: () => void;
  style?: ViewStyle;
}) => {
  return (
    <TouchableOpacity style={[styles.button, style]} onPress={onPress}>
      <FacebookLogo style={{  }} />
    </TouchableOpacity>
  );
};

const styles = StyleSheet.create({
  button: {
    /* borderRadius: 5,
    padding: 10,
    borderWidth: 2, */
  },
});
