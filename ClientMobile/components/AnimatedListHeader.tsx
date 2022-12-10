import { Animated, View, StyleSheet, } from "react-native";
import React, { useState } from "react";
import { Text, Button, Divider } from "@ui-kitten/components";

import { LISTMARGIN } from "../constants/constants";
import { HeaderInput } from "./HeaderInput";
import { Location } from "../types/locationIQ";
import { useNavigation } from "@react-navigation/native";
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

  const [startTime, setStartTime] = useState<string>("07:30");
  const [endTime, setEndTime] = useState<string>("16:00");

  const navigation = useNavigation();
  
  const submit = async () => {
    console.log(startLocation.display_name)
    console.log(endLocation.display_name)

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
    <Animated.View style={styles.container}>
      <View style={styles.defaultMarginHorizontal}>
        <View style={{flexDirection: 'row', justifyContent: 'flex-end'}}>
          <Text style={{marginRight: 'auto'}}>Gdzie mieszkasz?</Text>
          <Text style={{marginLeft: 'auto'}}>O której wyjeżdżasz?</Text>
        </View>
        
        <HeaderInput type="start" location={startLocation} setLocation={setStartLocation} time={startTime} setTime={setStartTime}/>
        
        <View style={{flexDirection: 'row', justifyContent: 'flex-end'}}>
          <Text style={{marginRight: 'auto'}}>Gdzie pracujesz?</Text>
          <Text style={{marginLeft: 'auto'}}>O której wracasz?</Text>
        </View>
        <HeaderInput type="end" location={endLocation} setLocation={setEndLocation} time={endTime} setTime={setEndTime}/>
        
        {startLocation.display_name !== i18n.t('Search') && endLocation.display_name !== i18n.t('Search') &&
        <Button onPress={() => {submit()}}>Szukaj</Button>}
      </View>
      <Divider style={styles.divider} />
    </Animated.View>
  );
};

const styles = StyleSheet.create({
  container: {
    top: 0,
    right: 0,
    left: 0,
    backgroundColor: "#fff",
  },
  defaultMarginHorizontal: {
    marginHorizontal: LISTMARGIN,
  },
  divider: { 
    height: 20,
    backgroundColor: 'white'
  },
});
