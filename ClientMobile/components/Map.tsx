import React from "react";
import MapViewDirections from "react-native-maps-directions";
import MapView, { LatLng, Polyline, Region } from "react-native-maps";
import { View, StyleSheet, Platform, TouchableOpacity } from "react-native";
import { useState, useEffect, useRef } from "react";
import { useNavigation } from "@react-navigation/native";
import { MaterialCommunityIcons } from "@expo/vector-icons";

import { CollocateAccount, Collocation } from "../types/collocation";
import { MapMarker } from "./MapMarker";
import { mapDarkStyle, mapStandardStyle, theme } from "../theme";
import { Card } from "./Card";
import { googleAPIKEY, themes } from "../constants/constants";
import { SearchScreenParams } from "../types";
import { useSearchPropertiesQuery } from "../hooks/queries/useSearchPropertiesQuery";
import useColorScheme from "../hooks/useColorScheme";

export const Map = ({
  location,
}: {
  location: SearchScreenParams;
}) => {
  const colorScheme = useColorScheme();
  
  const initPolishRegion = {
    latitude: 51,
    longitude: 19,
    latitudeDelta: 10,
    longitudeDelta: 10,
  }

  if(!location || location == undefined) {
    return (
      <MapView
        provider={"google"}
        style={styles.map}
        userInterfaceStyle={colorScheme}
        onPress={() => console.log("Mapa kliknięta")}
        region={initPolishRegion}
        customMapStyle={colorScheme === themes.dark ? mapDarkStyle : mapStandardStyle}
      />
    )
  }

  const coords: LatLng[] = 
  [
    {latitude: Number(location.startLocation.lat),
    longitude: Number(location.startLocation.lon)},
    {latitude: Number(location.endLocation.lat),
    longitude: Number(location.endLocation.lon)}
  ];

  
  const mapRef = useRef<MapView | null>(null);
  const [activeIndex, setActiveIndex] = useState(-1);
  const [region, setRegion] = useState<Region>(initPolishRegion);

  // const [coords, setCoords] = useState([
  //   { latitude: 37.766155, longitude: -122.51058 },
  //   { latitude: 37.7948605, longitude: -122.4596065 },
  //   { latitude: 37.799476, longitude: -122.397995 },
  // ]);

  const searchProperties = useSearchPropertiesQuery(location);
  let collocation: Collocation = searchProperties.data?.isSuccess ? searchProperties.data as Collocation : {} as Collocation;

  const navigation = useNavigation();

  useEffect(() => {
    if (location.startLocation.display_name === "Map Area") return;

    searchProperties.refetch();

    mapRef?.current?.fitToCoordinates(coords);

    if (!isNaN(Number(location.startLocation.lat))) {
      setRegion({
        latitude: (Number(location.startLocation.lat) + Number(location.endLocation.lat)) / 2,
        longitude: (Number(location.startLocation.lon) + Number(location.endLocation.lon)) / 2,
        latitudeDelta: Math.abs((Number(location.startLocation.lat)) - (Number(location.endLocation.lat))) + 2,
        longitudeDelta: Math.abs((Number(location.startLocation.lon)) - (Number(location.endLocation.lon))) + 2,
      } as Region);
    } 
  }, [location]);

  const unFocusProperty = () => {
    setActiveIndex(-1);
    navigation.setOptions({ tabBarStyle: { display: "flex" } });
  };

  const handleMapPress = () => {
    if (Platform.OS === "android") unFocusProperty();
  };

  const handleMarkerPress = (index: number) => {
    // console.log("DANE: ", collocation.methodResult.accountsCollocated[index])
    setTimeout(() => {
      mapRef.current?.animateCamera({
        center: {
          latitude: collocation.methodResult.accountsCollocated[index].latitudefrom,
          longitude: collocation.methodResult.accountsCollocated[index].longitudefrom,
        },
      });
    }, 100);
    setTimeout(() => {
      const newRegion: Region = {
        latitude: collocation.methodResult.accountsCollocated[index].latitudefrom,
        latitudeDelta:
          region?.latitudeDelta && region.latitudeDelta < 4
            ? region.latitudeDelta
            : 4,
        longitude: collocation.methodResult.accountsCollocated[index].longitudefrom,
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
        userInterfaceStyle={"dark"} //TODO!
        ref={mapRef}
        onPress={handleMapPress}
        region={region}
        customMapStyle={colorScheme === themes.dark ? mapDarkStyle : mapStandardStyle}
      >

      {!isNaN(Number(location.startLocation.lat)) && !isNaN(Number(location.startLocation.lon)) 
      && !isNaN(Number(location.endLocation.lat)) && !isNaN(Number(location.endLocation.lon)) 
      && (
        <>
          <MapMarker
            lat={Number(location.startLocation.lat)}
            lng={Number(location.startLocation.lon)}
            color={'red'}
            onPress={() => console.log("Początek", location.startLocation.lat, location.startLocation.lon)}
          />
          <MapMarker
            lat={Number(location.endLocation.lat)}
            lng={Number(location.endLocation.lon)}
            color={'red'}
            onPress={() => console.log("Koniec", location.endLocation.lat, location.endLocation.lon)}
          />

          <MapViewDirections
            origin={{latitude: Number(location.startLocation.lat), longitude: Number(location.startLocation.lon)}}
            destination={{latitude: Number(location.endLocation.lat), longitude: Number(location.endLocation.lon)}}
            language='pl'
            strokeWidth={3}
            strokeColor="hotpink"
            apikey={googleAPIKEY}
          />
        </>)
      }

      {collocation.methodResult && collocation.methodResult.accountsCollocated.map((i: CollocateAccount, index: number) => (
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
            collocation={collocation.methodResult.accountsCollocated[activeIndex]}
            style={styles.card}
            onPress={() =>{
              navigation.navigate("PropertyDetails", {
                collocationID: collocation.methodResult.accountsCollocated[activeIndex].idAccount,
              })
            }
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
    top: 60,
    left: 15,
    borderRadius: 30,
  }
});
