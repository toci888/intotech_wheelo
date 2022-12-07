import { Animated, View, StyleSheet } from "react-native";
import { useState, useEffect, useRef } from "react";
import MapView from "react-native-maps";
import LottieView from "lottie-react-native";
import { useNavigation } from "@react-navigation/native";

import { Screen } from "../components/Screen";
import { endpoints, HEADERHEIGHT, queryKeys } from "../constants/constants";
import { AnimatedListHeader } from "../components/AnimatedListHeader";
import { getPropertiesInArea } from "../data/properties";
import { Map } from "../components/Map";
import { SearchScreenParams } from "../types";
import { Collocation } from "../types/property";
import { useSearchPropertiesQuery } from "../hooks/queries/useSearchPropertiesQuery";
import { i18n } from "../i18n/i18n";
import React from "react";
import { Location } from "../types/locationIQ";

export const SearchScreen = ({
  route,
}: {
  route: { params: SearchScreenParams };
}) => {
  const mapRef = useRef<MapView | null>(null);
  const [startLocation, setStartLocation] = useState<string | Location>(i18n.t('Search'));
  const [endLocation, setEndLocation] = useState<string | Location>(i18n.t('Search'));
  
  const searchProperties = useSearchPropertiesQuery(route.params);

  useEffect(() => {
    if (route.params) {
      if (route.params.startLocation) {
        setStartLocation(route.params.startLocation);
        setEndLocation(route.params.endLocation);
      }
      
      searchProperties.refetch();

      mapRef?.current?.animateCamera({
        center: {
          latitude: Number(route.params.startLocation?.lat), //HERETODO
          longitude: Number(route.params.startLocation?.lon),
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
        property={searchProperties?.data ? searchProperties.data : {} as Collocation}
        mapRef={mapRef}
        startLocation={startLocation as Location}
        endLocation={endLocation as Location}
      />
    </Screen>
  );
};
