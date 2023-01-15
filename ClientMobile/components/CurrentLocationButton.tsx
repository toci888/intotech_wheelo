import { TouchableOpacity, StyleSheet, ViewStyle } from "react-native";
import { Text } from "@ui-kitten/components";
import { FontAwesome } from "@expo/vector-icons";
import { useNavigation } from "@react-navigation/native";
import * as Location from "expo-location";

import { Row } from "./Row";
import { theme } from "../theme";
import React from "react";
import axios from "axios";
import { endpoints } from "../constants/constants";
import { commonAlert } from "../utils/handleError";
import { i18n } from "../i18n/i18n";

export const CurrentLocationButton = ({ style, location, setLocation 
}: { 
  style?: ViewStyle, 
  location: Location, 
  setLocation: (location: Location) => Location;
}) => {
  const navigation = useNavigation();

  const getLocation = async () => {
    let { status } = await Location.requestForegroundPermissionsAsync();
    if (status !== "granted") {
      commonAlert(i18n.t('Permissiontoaccesslocationwasdenied'))
      return;
    }

    let currentLocation = await Location.getCurrentPositionAsync({});

    let lat =  currentLocation.coords.latitude; //52.38705 16.88180 52.38512
    let lon = currentLocation.coords.longitude; // 16.879011
    
    const {data} = await useApiClient.get(`${endpoints.currentLocation(lat, lon)}`);

    setLocation(data);
    navigation.goBack();
  };

  return (
    <Row style={[styles.container, style as ViewStyle]}>
      <FontAwesome
        name="location-arrow"
        size={30}
        style={styles.icon}
        color={theme["color-primary-500"]}
      />
      <TouchableOpacity onPress={async () => await getLocation()}>
        <Text style={styles.text} status={"info"}>
          {i18n.t('UseMyCurrentLocation')}
        </Text>
      </TouchableOpacity>
    </Row>
  );
};

const styles = StyleSheet.create({
  container: {
    alignItems: "center",
  },
  icon: {
    marginLeft: 5,
  },
  text: {
    marginLeft: 10,
    fontWeight: "600",
  },
});
