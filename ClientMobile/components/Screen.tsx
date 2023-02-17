import React from "react";
import { SafeAreaView, StyleSheet, ViewStyle, Platform, StatusBar } from "react-native";

import { Loading } from "./Loading";
import { useLoading } from "../hooks/useLoading";
import { os, themes } from "../constants/constants";
import useColorScheme from "../hooks/useColorScheme";

export const Screen = ({
  children,
  style,
}: {
  children: React.FC<any> | any;
  style?: ViewStyle;
}) => {
  const { loading } = useLoading();
  const colorScheme = useColorScheme();
  return (
    <SafeAreaView style={[styles.container, style]}>
      <StatusBar barStyle={colorScheme === themes.dark ? "light-content" : "dark-content"} />
      {loading ? <Loading /> : children}
    </SafeAreaView>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    paddingTop: Platform.OS === os.android ? StatusBar.currentHeight : 0,
    // paddingTop: StatusBar.currentHeight
  },
});
