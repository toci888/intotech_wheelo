import {
  Platform,
  TouchableOpacity,
  View,
  StyleSheet,
} from "react-native";
import React from "react";
import { Text } from "@ui-kitten/components";

import { LISTMARGIN } from "../constants/constants";
import { theme } from "../theme";
import { Row } from "./Row";
import { useNavigation } from "@react-navigation/native";
import { MaterialCommunityIcons } from "@expo/vector-icons";

export const TopBar = ({ location }: { location: string }) => {
    const navigation = useNavigation();
  
    return (
      <View
        style={styles.container}
      >
        <Row style={styles.row}>
          <TouchableOpacity onPress={() => console.log("press a bell")}>
            <MaterialCommunityIcons
              name={"bell-outline"}
              size={28}
              color={"white"} />
          </TouchableOpacity>
          <TouchableOpacity>
            <Text category="h2" style={{"textTransform": "uppercase", "color": "white"}} onPress={() => console.log("press a logo")}>Wheelo</Text>
          </TouchableOpacity>
          <TouchableOpacity onPress={() => console.log("press a cog")}>
            <MaterialCommunityIcons
              name={"cog"}
              size={28}
              color={"white"} />
          </TouchableOpacity>
        </Row>
      </View>
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
  });
  