import { Animated, View, StyleSheet} from "react-native";
import React, { useState } from "react";
import { Text } from "@ui-kitten/components";

import { LISTMARGIN } from "../constants/constants";
import { HeaderInput } from "./HeaderInput";
import { Location } from "../types/locationIQ";
import { theme } from "../theme";
import useColorScheme from "../hooks/useColorScheme";
import { HeaderFilterButtons } from "./HeaderFilterButtons";
import { i18n } from "../i18n/i18n";

export const AnimatedListHeader = ({
  startLocation,
  endLocation,
  setStartLocation,
  setEndLocation
}: {
  startLocation: Location;
  endLocation: Location;
  setStartLocation: (startLocation: Location) => void;
  setEndLocation: (endLocation: Location) => void;
}) => {
  const colorScheme = useColorScheme();

  const [startTime, setStartTime] = useState<string>("08:00");
  const [endTime, setEndTime] = useState<string>("16:00");
  
  return (
    <Animated.View style={[styles.container, {backgroundColor: colorScheme === "dark" ? theme["color-primary-700"] : theme["color-white"]}]}>
      <View style={[styles.defaultMarginHorizontal, {"marginTop": 10}]} />
      <View style={styles.defaultMarginHorizontal}>
        <View style={{ flexDirection: "row", justifyContent: "flex-end" }}>
          <Text category="h6" style={{ marginRight: "auto"}}>Gdzie mieszkasz?</Text>
          <Text category="h6" style={{ marginLeft: "auto"}}>O której wyjeżdżasz?</Text>
        </View>

        <HeaderInput type="start" location={startLocation} setLocation={setStartLocation} time={startTime} setTime={setStartTime} />

        <View style={{ flexDirection: "row", justifyContent: "flex-end" }}>
          <Text category="h6" style={{ marginRight: "auto"}}>Gdzie pracujesz?</Text>
          <Text category="h6" style={{ marginLeft: "auto"}}>O której wracasz?</Text>
        </View>
        <HeaderInput type="end" location={endLocation} setLocation={setEndLocation} time={endTime} setTime={setEndTime} />
        {startLocation.lat && endLocation.lat && 
          <HeaderFilterButtons startLocation={startLocation} endLocation={endLocation} startTime={startTime} endTime={endTime} />
        }
      </View>
    </Animated.View>
  );
};

const styles = StyleSheet.create({
  container: {
    top: 0,
    right: 0,
    left: 0,
  },
  defaultMarginHorizontal: {
    marginHorizontal: LISTMARGIN,
  },
  row: {
    marginBottom: 5,
    alignItems: "center",
    justifyContent: "space-between",
  },  
});
