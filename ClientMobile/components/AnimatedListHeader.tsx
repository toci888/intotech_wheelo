import {
  Animated,
  LayoutChangeEvent,
  View,
  StyleSheet,
} from "react-native";
import React, { useState } from "react";

import { HEADERHEIGHT, LISTMARGIN } from "../constants/constants";
import { HeaderInput } from "./HeaderInput";
import { TopBar } from "./TopBar";
import { theme } from "../theme";

export const AnimatedListHeader = ({
  scrollAnimation,
  mapShown,
  setMapShown,
  location,
  availableProperties,
}: {
  scrollAnimation: Animated.Value;
  mapShown: boolean;
  setMapShown: (bool: boolean) => void;
  location: string;
  availableProperties?: number;
}) => {
  const [offsetAnimation] = useState(new Animated.Value(0));
  const [clampedScroll, setClampedScroll] = useState(
    Animated.diffClamp(
      Animated.add(
        scrollAnimation.interpolate({
          inputRange: [0, 1],
          outputRange: [0, 1],
          extrapolateLeft: "clamp",
        }),
        offsetAnimation
      ),
      0,
      1
    )
  );

  const navbarTranslate = clampedScroll.interpolate({
    inputRange: availableProperties && !mapShown ? [0, HEADERHEIGHT] : [0, 0],
    outputRange: availableProperties && !mapShown ? [0, -HEADERHEIGHT] : [0, 0],
    extrapolate: "clamp",
  });

  const onLayout = (event: LayoutChangeEvent) => {
    let { height } = event.nativeEvent.layout;
    setClampedScroll(
      Animated.diffClamp(
        Animated.add(
          scrollAnimation.interpolate({
            inputRange: [0, 1],
            outputRange: [0, 1],
            extrapolateLeft: "clamp",
          }),
          offsetAnimation
        ),
        0,
        height
      )
    );
  };

  return (
    <Animated.View
      style={[
        styles.container,
        {
          transform: [{ translateY: navbarTranslate }],
        },
      ]}
      onLayout={onLayout}
    >
      <View style={styles.defaultMarginHorizontal}>
        <TopBar location={""} />
        <HeaderInput location={location} />
      </View>
    </Animated.View>
  );
};

const styles = StyleSheet.create({
  container: {
    position: "absolute",
    top: 0,
    right: 0,
    left: 0,
    zIndex: 1000,
    height: HEADERHEIGHT,
    backgroundColor: theme["color-blue"],
  },
  defaultMarginHorizontal: {
    marginHorizontal: LISTMARGIN,
  },
});
