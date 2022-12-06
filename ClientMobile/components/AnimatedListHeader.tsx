import { Animated, View, StyleSheet, } from "react-native";
import React, { useState } from "react";
import { Text, Button, Divider } from "@ui-kitten/components";

import { endpoints, LISTMARGIN } from "../constants/constants";
import { HeaderInput } from "./HeaderInput";
import { HeaderFilterButtons } from "./HeaderFilterButtons";
import { Location } from "../types/locationIQ";
import { useNavigation } from "@react-navigation/native";
import axios from "axios";
import { SearchScreenParams } from "../types";
import { useUser } from "../hooks/useUser";

export const AnimatedListHeader = ({
  startLocation,
  endLocation,
  setStartLocation,
  setEndLocation
}: {
  startLocation: string | Location;
  endLocation: string | Location;
  setStartLocation: (startLocation: string | Location) => void;
  setEndLocation: (endLocation: string | Location) => void;
}) => {

  const navigation = useNavigation();
  const { user } = useUser();
  
  const submit = async () => {
    // console.log("start", startLocation); console.log("end", endLocation);

    if(typeof(startLocation) !== 'string' && typeof(endLocation) !== 'string') {
      // console.log(endpoints.addWorkTrip)
      // const data: SearchScreenParams[] = await axios.post(endpoints.addWorkTrip, {
      //   idaccount: 50,
      //   latitudefrom: startLocation.lat, //52.24802984098752,
      //   longitudefrom: startLocation.lon, //21.08828642005573,
      //   latitudeto: endLocation.lat, //52.20878607141056,
      //   longitudeto: endLocation.lon, //21.0188489021064,
      //   iFromHour: 8, // 00-23
      //   iToHour: 16,
      //   iFromMinute: 0, // 00-59
      //   iToMinute: 0,
      //   // acceptabledistance: 800 not yet
      // });

      // console.log("ZWROTKA: ", data)

      navigation.navigate("Root", {
        screen: "Search",
        params: {
          startLocation,
          endLocation
        }
      });
    }
  }

  return (
    <Animated.View style={styles.container}>
      <View style={styles.defaultMarginHorizontal}>
        <View style={{flexDirection: 'row', justifyContent: 'flex-end'}}>
          <Text style={{marginRight: 'auto'}}>Gdzie mieszkasz?</Text>
          <Text style={{marginLeft: 'auto'}}>O której wyjeżdżasz?</Text>
        </View>
        
        <HeaderInput type="start" location={startLocation} setLocation={setStartLocation} />
        
        <View style={{flexDirection: 'row', justifyContent: 'flex-end'}}>
          <Text style={{marginRight: 'auto'}}>Gdzie pracujesz?</Text>
          <Text style={{marginLeft: 'auto'}}>O której wracasz?</Text>
        </View>
        <HeaderInput type="end" location={endLocation} setLocation={setEndLocation} />
        
        {typeof(startLocation) !== 'string' && typeof(endLocation) !== 'string' &&
        <Button onPress={() => {submit()}}>Szukaj</Button>}
        {/* <HeaderFilterButtons /> */}
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
