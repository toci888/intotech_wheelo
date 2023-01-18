import { Animated, View, StyleSheet} from "react-native";
import React, { useState } from "react";
import { Text, Button } from "@ui-kitten/components";

import { LISTMARGIN, themes } from "../constants/constants";
import { HeaderInput } from "./HeaderInput";
import { Location } from "../types/locationIQ";
import { useNavigation } from "@react-navigation/native";
import { i18n } from "../i18n/i18n";
import { theme } from "../theme";
import useColorScheme from "../hooks/useColorScheme";
import { HeaderFilterButtons } from "./HeaderFilterButtons";

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
  const navigation = useNavigation();

  const [startTime, setStartTime] = useState<string>("08:00");
  const [endTime, setEndTime] = useState<string>("16:00");
  
  const submit = async () => {
    if(startLocation.display_name !== i18n.t('Search') && endLocation.display_name !== i18n.t('Search')) {
      navigation.navigate("Root", {
        screen: "Search",
        params: {
          startLocation,
          endLocation,
          startLocationTime: startTime,
          endLocationTime: endTime
        }
      } as any);
    }
  }

  return (
    <Animated.View style={[styles.container, {backgroundColor: colorScheme === themes.dark ? theme["color-primary-700"] : theme["color-white"]}]}>
      <View 
          style={[styles.defaultMarginHorizontal, {"marginTop": 10}]}
        >
      </View>    
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
        <HeaderFilterButtons />
        
        {
          startLocation.display_name !== i18n.t('Search') && endLocation.display_name !== i18n.t('Search') &&
            <Button style={{ marginBottom: 10, borderRadius: 20, }} onPress={() => { submit(); }} >
              {evaProps => <Text {...evaProps} style={{ fontSize: 18, fontWeight: "500", textTransform: "uppercase" }}>{i18n.t("FindAvailableConnections")}</Text>}
            </Button>
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
