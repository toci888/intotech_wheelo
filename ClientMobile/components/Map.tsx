import MapView, { Region } from "react-native-maps";
import { View, StyleSheet, Platform, TouchableOpacity } from "react-native";
import { useState, useEffect } from "react";
import { useNavigation } from "@react-navigation/native";
import { MaterialCommunityIcons } from "@expo/vector-icons";

import { CollocateAccount, Collocation } from "../types/property";
import { MapMarker } from "./MapMarker";
import { theme } from "../theme";
import { Card } from "./Card";
import React from "react";
import MapViewDirections from "react-native-maps-directions";
import { googleAPIKEY } from "../constants/constants";
import { SearchScreenParams } from "../types";
import { useSearchPropertiesQuery } from "../hooks/queries/useSearchPropertiesQuery";

export const Map = ({
  mapRef,
  location,
}: {
  mapRef: React.MutableRefObject<MapView | null>;
  location: SearchScreenParams;
}) => {

  const initPolishRegion = {
    latitude: 51,
    longitude: 19,
    latitudeDelta: 10,
    longitudeDelta: 10,
  }

  if(location == undefined) {
    return (
      <MapView
        provider={"google"}
        style={styles.map}
        userInterfaceStyle={"light"}
        ref={mapRef}
        onPress={() => console.log("ASD")}
        region={initPolishRegion}
      />
    )
  }

  const [activeIndex, setActiveIndex] = useState(-1);
  const [region, setRegion] = useState<Region>(initPolishRegion);

  
  const searchProperties = useSearchPropertiesQuery(location);
  let property: any;
  if(searchProperties.data?.isSuccess) {
    property = searchProperties.data as Collocation;
  }

  const navigation = useNavigation();

  useEffect(() => {
    if (location.startLocation.display_name === "Map Area") return;

    searchProperties.refetch();
    
    if (!isNaN(Number(location.startLocation.lat))) {
      setRegion({
        latitude: Number(location.startLocation.lat),
        longitude: Number(location.startLocation.lon),
        latitudeDelta: 2,
        longitudeDelta: 2,
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

      {property && property.methodResult.accountsCollocated.map((i: CollocateAccount, index: number) => (
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
