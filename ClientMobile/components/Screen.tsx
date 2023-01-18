import React from "react";
import { SafeAreaView, StyleSheet, ViewStyle, Platform, StatusBar } from "react-native";
import { DefaultTheme } from "@react-navigation/native";

import { Loading } from "./Loading";
import { useLoading } from "../hooks/useLoading";
import { os } from "../constants/constants";

export const Screen = ({
  children,
  style,
}: {
  children: any;
  style?: ViewStyle;
}) => {
  const { loading } = useLoading();

  return (
    <SafeAreaView style={[styles.container, style]}>
      <StatusBar barStyle={DefaultTheme.dark? "light-content" : "dark-content"} />
      {loading ? <Loading /> : children}
    </SafeAreaView>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    paddingTop: Platform.OS === os.android ? StatusBar.currentHeight : 0,
  },
});
