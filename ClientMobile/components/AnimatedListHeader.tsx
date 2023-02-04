import { Animated, View, StyleSheet} from "react-native";
import React, { useState } from "react";
import { Text } from "@ui-kitten/components";

import { LISTMARGIN } from "../constants/constants";
import { HeaderInput } from "./HeaderInput";
import { Location } from "../types/locationIQ";
import { HeaderFilterButtons } from "./HeaderFilterButtons";
import { i18n } from "../i18n/i18n";
import useTheme from "../hooks/useTheme";

export const AnimatedListHeader = () => {
  const {colors} = useTheme();

  const [startLocation, setStartLocation] = useState<Location>({display_name: i18n.t('Search')} as Location);
  const [endLocation, setEndLocation] = useState<Location>({display_name: i18n.t('Search')} as Location);

  const [startTime, setStartTime] = useState<string>("08:00");
  const [endTime, setEndTime] = useState<string>("16:00");
  
  return (
    <Animated.View style={styles.container}>
      <View style={[styles.defaultMarginHorizontal, {"marginTop": 10}]} />
      <View style={styles.defaultMarginHorizontal}>
        <View style={{ flexDirection: "row", justifyContent: "flex-end" }}>
          <Text category="h6" style={{ marginRight: "auto", color: colors.text}}>{i18n.t('WhereDoYouLive')}</Text>
          <Text category="h6" style={{ marginLeft: "auto", color: colors.text}}>{i18n.t('WhatTimeAreYouGo')}</Text>
        </View>

        <HeaderInput type="start" location={startLocation} setLocation={setStartLocation} time={startTime} setTime={setStartTime} />

        <View style={{ flexDirection: "row", justifyContent: "flex-end" }}>
          <Text category="h6" style={{ marginRight: "auto", color: colors.text}}>{i18n.t('WhereAreYouWorking')}</Text>
          <Text category="h6" style={{ marginLeft: "auto", color: colors.text}}>{i18n.t('WhatTimeAreYouComingBack')}</Text>
        </View>
        <HeaderInput type="end" location={endLocation} setLocation={setEndLocation} time={endTime} setTime={setEndTime} />
        { startLocation.lat && endLocation.lat && 
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
