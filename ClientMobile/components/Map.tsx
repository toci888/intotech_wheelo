import MapView, { Region } from "react-native-maps";
import { View, StyleSheet, Platform, TouchableOpacity } from "react-native";
import { useState, useEffect } from "react";
import { useNavigation } from "@react-navigation/native";
import { MaterialCommunityIcons } from "@expo/vector-icons";

import { Collocation } from "../types/property";
import { MapMarker } from "./MapMarker";
import { theme } from "../theme";
import { Card } from "./Card";
import React from "react";
import { Location } from "../types/locationIQ";
import MapViewDirections from "react-native-maps-directions";
import { googleAPIKEY } from "../constants/constants";

export const Map = ({
  property,
  mapRef,
  startLocation,
  endLocation,
}: {
  property: Collocation;
  mapRef: React.MutableRefObject<MapView | null>;
  startLocation: Location;
  endLocation: Location;
}) => {

  const [activeIndex, setActiveIndex] = useState(-1);
  const [region, setRegion] = useState<Region>({
    latitude: 51,
    longitude: 19,
    latitudeDelta: 10,
    longitudeDelta: 10,
  });

  const navigation = useNavigation();

  useEffect(() => {
    if (startLocation.display_name === "Map Area") return;

    if (!isNaN(Number(startLocation.lat))) {
      setRegion({
        latitude: Number(startLocation.lat),
        longitude: Number(startLocation.lon),
        latitudeDelta: 2,
        longitudeDelta: 2,
      } as Region);
    } 
  }, [startLocation]);

  const unFocusProperty = () => {
    setActiveIndex(-1);
    navigation.setOptions({ tabBarStyle: { display: "flex" } });
  };

  const handleMapPress = () => {
    if (Platform.OS === "android") unFocusProperty();
  };

  const handleMarkerPress = (index: number) => {
    console.log("DANE: ", property.methodResult.accountsCollocated[index])
    setTimeout(() => {
      mapRef.current?.animateCamera({
        center: {
          latitude: property.methodResult.accountsCollocated[index].latitudefrom,
          longitude: property.methodResult.accountsCollocated[index].longitudefrom,
        },
      });
    }, 100);
    setTimeout(() => {
      const newRegion: Region = {
        latitude: property.methodResult.accountsCollocated[index].latitudefrom,
        latitudeDelta:
          region?.latitudeDelta && region.latitudeDelta < 4
            ? region.latitudeDelta
            : 4,
        longitude: property.methodResult.accountsCollocated[index].longitudefrom,
        longitudeDelta:
          region?.longitudeDelta && region.longitudeDelta < 4
            ? region.longitudeDelta
            : 4,
      };

      setRegion(newRegion);
    }, 600);

    setActiveIndex(index);
    navigation.setOptions({ tabBarStyle: { display: "none" } });
  };

  return (
    <View style={styles.container}>
      <MapView
        provider={"google"}
        style={styles.map}
        userInterfaceStyle={"light"}
        ref={mapRef}
        onPress={handleMapPress}
        region={region}
      >

      {!isNaN(Number(startLocation.lat)) && !isNaN(Number(startLocation.lon)) 
      && !isNaN(Number(endLocation.lat)) && !isNaN(Number(endLocation.lon)) 
      && (
        <>
          <MapMarker
            lat={Number(startLocation.lat)}
            lng={Number(startLocation.lon)}
            color={'red'}
            onPress={() => console.log("Początek", startLocation.lat, startLocation.lon)}
          />
          <MapMarker
            lat={Number(endLocation.lat)}
            lng={Number(endLocation.lon)}
            color={'red'}
            onPress={() => console.log("Koniec", endLocation.lat, endLocation.lon)}
          />

          <MapViewDirections
            origin={{latitude: Number(startLocation.lat), longitude: Number(startLocation.lon)}}
            destination={{latitude: Number(endLocation.lat), longitude: Number(endLocation.lon)}}
            language='pl'
            strokeWidth={3}
            strokeColor="hotpink"
            apikey={googleAPIKEY}
          />
        </>)
      }

      {property.methodResult && property.methodResult.accountsCollocated.map((i, index) => (
        <MapMarker
          key={index} 
          lat={i.latitudefrom}
          lng={i.longitudefrom}
          color={activeIndex === index ? theme["color-info-400"] : theme["color-primary-500"]}
          onPress={() => handleMarkerPress(index)}
        />
      ))}

      </MapView>
      {activeIndex > -1 && (
        <>
          {Platform.OS === "ios" && (
            <TouchableOpacity style={styles.exit} onPress={unFocusProperty}>
              <MaterialCommunityIcons
                name="close"
                color={theme["color-primary-500"]}
                size={24}
              />
            </TouchableOpacity>
          )}
          <Card
            property={property.methodResult.accountsCollocated[activeIndex]}  //property[activeIndex]}
            style={styles.card}
            onPress={() =>
              navigation.navigate("PropertyDetails", {
                propertyID: property.methodResult.accountsCollocated[activeIndex].accountid,
              })
            }
          />
        </>
      )}
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    overflow: "hidden",
  },
  map: {
    height: "100%",
    width: "100%",
  },
  card: {
    position: "absolute",
    bottom: 10,
  },
  exit: {
    backgroundColor: "#fff",
    padding: 10,
    position: "absolute",
    top: 170,
    left: 15,
    borderRadius: 30,
  }
});
