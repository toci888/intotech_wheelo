import React from "react";
import { StyleSheet, TouchableOpacity, ViewStyle } from "react-native";
import { Text } from "@ui-kitten/components";
import * as WebBrowser from "expo-web-browser";

import { GoogleLogo } from "./logos/GoogleLogo";

WebBrowser.maybeCompleteAuthSession();

export const GoogleButton = ({
  text,
  style,
  onPress,
}: {
  text: string;
  onPress: () => void;
  style?: ViewStyle;
}) => {
  return (
    <TouchableOpacity style={[styles.button, style]} onPress={onPress}>
      {/* specific margins to line up with the other social buttons */}
      <GoogleLogo />
    </TouchableOpacity>
  );
};

const styles = StyleSheet.create({
  button: {
    // borderRadius: 5,
    // padding: 10,
    // border: 5,
    // borderWidth: 2,
  },
});
