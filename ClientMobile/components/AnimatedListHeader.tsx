import { Animated, View, StyleSheet, TouchableOpacity, } from "react-native";
import React, { useState } from "react";
import { Text, Button, Divider } from "@ui-kitten/components";

import { LISTMARGIN } from "../constants/constants";
import { HeaderInput } from "./HeaderInput";
import { Location } from "../types/locationIQ";
import { useNavigation } from "@react-navigation/native";
import { i18n } from "../i18n/i18n";
import { TopBar } from "./TopBar";
import { MaterialCommunityIcons } from "@expo/vector-icons";
import { Row } from "./Row";
import { theme } from "../theme";

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

  const [startTime, setStartTime] = useState<string>("08:00");
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
      <View
          style={[styles.defaultMarginHorizontal, {"marginTop": 10}]}
        >
        <Row style={styles.row}>
          <TouchableOpacity onPress={() => console.log("press a bell")}>
            <MaterialCommunityIcons
              name={"bell-outline"}
              size={28}
              color={theme["color-white"]} />
          </TouchableOpacity>
          <TouchableOpacity>
            <Text category="h3" style={{"textTransform": "uppercase", "color": theme["color-white"]}} onPress={() => console.log("press a logo")}>Wheelo</Text>
          </TouchableOpacity>
          <TouchableOpacity onPress={() => console.log("press a cog")}>
            <MaterialCommunityIcons
              name={"cog"}
              size={28}
              color={theme["color-white"]} />
          </TouchableOpacity>
        </Row>
        <Text category="h3" style={{"textTransform": "capitalize", "color": theme["color-white"]}}>Cześć,
          {/* TODO - dorobić wyświetlanie zalogowanego użytkownika */}
          <Text category="h3" style={{"textTransform": "capitalize", "color": theme["color-green"]}}> Dawid.</Text>
        </Text>
      </View>    
      <View style={styles.defaultMarginHorizontal}>
        <View style={{ flexDirection: "row", justifyContent: "flex-end" }}>
          <Text category="h6" style={{ marginRight: "auto", color: theme["color-white"] }}>Gdzie mieszkasz?</Text>
          <Text category="h6" style={{ marginLeft: "auto", color: theme["color-white"] }}>O której wyjeżdżasz?</Text>
        </View>

        <HeaderInput type="start" location={startLocation} setLocation={setStartLocation} time={startTime} setTime={setStartTime} />

        <View style={{ flexDirection: "row", justifyContent: "flex-end" }}>
          <Text category="h6" style={{ marginRight: "auto", color: theme["color-white"] }}>Gdzie pracujesz?</Text>
          <Text category="h6" style={{ marginLeft: "auto", color: theme["color-white"] }}>O której wracasz?</Text>
        </View>
        <HeaderInput type="end" location={endLocation} setLocation={setEndLocation} time={endTime} setTime={setEndTime} />

        {
          startLocation.display_name !== i18n.t('Search') && endLocation.display_name !== i18n.t('Search') &&
            <Button style={{ marginBottom: 10, borderRadius: 20, }} onPress={() => { submit(); }} >
              {evaProps => <Text {...evaProps} style={{ fontSize: 18, fontWeight: "500", color: theme["color-white"], textTransform: "uppercase" }}>{i18n.t("FindAvailableConnections")}</Text>}
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
    backgroundColor: theme["color-blue"],
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
