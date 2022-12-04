import { Animated, View, StyleSheet, } from "react-native";
import React, { useState } from "react";
import { Text, Button, Divider } from "@ui-kitten/components";

import { LISTMARGIN } from "../constants/constants";
import { HeaderInput } from "./HeaderInput";
import { HeaderFilterButtons } from "./HeaderFilterButtons";

export const AnimatedListHeader = ({
  startLocation,
  endLocation,
  setStartLocation,
  setEndLocation
}: {
  startLocation: string;
  endLocation: string;
  setStartLocation: (startLocation: string) => void;
  setEndLocation: (endLocation: string) => void;
}) => {

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
        <Button onPress={() => {console.log("start", startLocation); console.log("end", endLocation);}}>ok</Button>
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
