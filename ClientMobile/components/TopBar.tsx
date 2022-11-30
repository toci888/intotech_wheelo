import {
  Animated,
  FlatList,
  LayoutChangeEvent,
  Platform,
  TouchableOpacity,
  View,
  StyleSheet,
} from "react-native";
import React, { useState } from "react";
import { Text } from "@ui-kitten/components";

import { LISTMARGIN } from "../constants/constants";
import { theme } from "../theme";
import { Row } from "./Row";
import { useNavigation } from "@react-navigation/native";
import { MaterialCommunityIcons } from "@expo/vector-icons";

export const TopBar = ({ location }: { location: string }) => {
    const navigation = useNavigation();
  
    return (
      <TouchableOpacity
        style={styles.container}
      >
        <Row style={styles.row}>
          <MaterialCommunityIcons
            name={"bell-outline"}
            size={28}
            color={"white"} />
          <Text category="h1" style={{"textTransform": "uppercase", "color": "white"}}>Wheelo</Text>
          <MaterialCommunityIcons
            name={"cog"}
            size={28}
            color={"white"} />
        </Row>
      </TouchableOpacity>
    );
  };
  
  const styles = StyleSheet.create({
    container: {
      marginTop: Platform.OS === "ios" ? 50 : 30,
      marginHorizontal: LISTMARGIN,
    },
    row: {
      marginBottom: 10,
      alignItems: "center",
      justifyContent: "space-between",
    },
    locationInput: {
      width: "70%",
      borderWidth: 1,
      borderColor: theme["color-gray"],
      borderRadius: 5,
      padding: 10,
    },
    timeInput: {
      width: "20%",
      marginLeft: 20,
      borderWidth: 1,
      borderColor: theme["color-gray"],
      borderRadius: 5,
      padding: 10,
    },
  });
  