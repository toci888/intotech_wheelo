import { TouchableOpacity, StyleSheet, ViewStyle } from "react-native";
import { Text } from "@ui-kitten/components";
import { FontAwesome } from "@expo/vector-icons";
import { useNavigation } from "@react-navigation/native";
import * as Location from "expo-location";

import { Row } from "./Row";
import { theme } from "../theme";
import React from "react";

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
      alert("Permission to access location was denied");
      return;
    }

    let location = await Location.getCurrentPositionAsync({});
    console.log("XXXX", location);
    handleNavigate(location);
  };

  const handleNavigate = (location: Location.LocationObject) => {
    let lat =  location.coords.latitude; //52.38705 16.88180 52.38512
    let lon = location.coords.longitude; // 16.879011
    
    

    // navigation.navigate("Root", {
    //   screen: "Search",
    //   params: {
    //     location: "Your Current Location",
    //     boundingBox,
    //     lat: lat.toString(),
    //     lon: lon.toString(),
    //   },
    // });
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
          Use my current location
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
