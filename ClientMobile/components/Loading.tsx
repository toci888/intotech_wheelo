import React from "react";
import { Dimensions, StyleSheet, View } from "react-native";
import LottieView from "lottie-react-native";
import { useRef } from "react";

export const Loading = () => {
  const animation = useRef<LottieView | null>(null);

  setTimeout(() => {
    animation.current?.play();
  }, 100);

  return (
    <View style={styles.container}>
      <LottieView
        ref={animation}
        source={require("../assets/lotties/Loading.json")}
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
