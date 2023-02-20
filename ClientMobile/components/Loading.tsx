import React from "react";
import { Platform, Dimensions, StyleSheet, View } from "react-native";
import LottieView from "lottie-react-native";
import { useRef } from "react";
import { os } from "../constants/constants";

export const Loading = () => {
  const animation = useRef<LottieView | null>(null);

  setTimeout(() => {
    animation.current?.play();
  }, 100);
  //TODO https://stackoverflow.com/questions/58579584/react-native-expo-app-crashes-on-android-when-using-lottie-react-native-2-6-1
  return (
    <View style={styles.container}>
      <LottieView
        ref={animation}
        source={Platform.OS === os.ios ? require("../assets/lotties/loadingIos.json") : require("../assets/lotties/Loading.json")}
        style={styles.lottie}
      />
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    justifyContent: "center",
    alignItems: "center",
    right: Dimensions.get("screen").width/7

  },
  lottie: {
    marginTop: Dimensions.get("screen").height/15,
    height: 300,
    width: '100%',
  },
});
