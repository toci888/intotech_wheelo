import { Animated, View, StyleSheet } from "react-native";
import { useState, useEffect, useRef } from "react";
import MapView from "react-native-maps";
import LottieView from "lottie-react-native";
import { useNavigation } from "@react-navigation/native";

import { Screen } from "../components/Screen";
import { endpoints, HEADERHEIGHT, queryKeys } from "../constants/constants";
import { Card } from "../components/Card";
import { AnimatedListHeader } from "../components/AnimatedListHeader";
import { getPropertiesInArea } from "../data/properties";
import { Map } from "../components/Map";
import { SearchScreenParams } from "../types";
import { Property } from "../types/property";
import { Text } from "@ui-kitten/components";
import { useSearchPropertiesQuery } from "../hooks/queries/useSearchPropertiesQuery";
import { i18n } from "../i18n/i18n";
import React from "react";

export const SearchScreen = ({
  route,
}: {
  route: { params: SearchScreenParams };
}) => {
  const mapRef = useRef<MapView | null>(null);
  const [startLocation, setStartLocation] = useState<string | undefined>(undefined);
  const [endLocation, setEndLocation] = useState<string | undefined>(undefined);

  const initialPolishRegion = {
    latitude: 51,
    longitude: 19,
    latitudeDelta: 10,
    longitudeDelta: 10,
  }

  let boundingBox: number[] = [];
  if (route.params?.startBoundingBox && route.params?.endBoundingBox)
    boundingBox = [
      Number(route.params.startBoundingBox[0]),
      Number(route.params.startBoundingBox[1]),
      Number(route.params.startBoundingBox[2]),
      Number(route.params.startBoundingBox[3]),
    ];
  const searchProperties = useSearchPropertiesQuery(boundingBox);

  useEffect(() => {
    if (route.params) {
      console.log("route.params.location", route.params.startLocation)
      if (route.params.startLocation) {
        setStartLocation(route.params.startLocation);
      }

      if (route.params.startLocation) {
        setEndLocation(route.params.endLocation)
      }
      
      searchProperties.refetch();

      mapRef?.current?.animateCamera({
        center: {
          latitude: Number(route.params.startLat),
          longitude: Number(route.params.startLon),
        },
      });
    }
  }, [route]);

  return (
    <Screen>
      <AnimatedListHeader
        startLocation={startLocation ? startLocation : i18n.t('Search')}
        endLocation={endLocation ? endLocation : i18n.t('Search')}
        setStartLocation={setStartLocation}
        setEndLocation={setEndLocation}
      />
      <Map
        properties={searchProperties?.data ? searchProperties.data : []}
        mapRef={mapRef}
        startLocation={startLocation ? startLocation : i18n.t('Search')}
        endLocation={endLocation ? endLocation : i18n.t('Search')}
        setStartLocation={setStartLocation}
        setEndLocation={setEndLocation}
        initialRegion={route.params ? {
          latitude: Number(route.params.startLat),
          longitude: Number(route.params.endLon),
          latitudeDelta: 0.4,
          longitudeDelta: 0.4,
        } : initialPolishRegion} 
        />
    </Screen>
  );
};
