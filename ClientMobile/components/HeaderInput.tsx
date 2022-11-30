import { TouchableOpacity, Platform, StyleSheet } from "react-native";
import { Text } from "@ui-kitten/components";
import { useNavigation } from "@react-navigation/native";

import { LISTMARGIN } from "../constants/constants";
import React from "react";
import { HomeAndWorkInput } from "./HomeAndWorkInput";
import { theme } from "../theme";
import { MaterialCommunityIcons } from "@expo/vector-icons";

export const HeaderInput = ({ location }: { location: string }) => {
  const navigation = useNavigation();

  return (
    <TouchableOpacity
      style={styles.container}
      onPress={() => navigation.navigate("FindLocations")}
    >
      <Text category="h3" style={styles.clrWhite}>Cześć <Text category="h3" style={styles.clrGreen}>Dawid.</Text></Text>
      <HomeAndWorkInput />
    </TouchableOpacity>
  );
};

const styles = StyleSheet.create({
  container: {
    marginTop: Platform.OS === "ios" ? 20 : 0,
    marginHorizontal: LISTMARGIN,
  },
  clrWhite: {
    color: "white",
  },
  clrGreen: {
    color: theme["color-green"],
  },
});
