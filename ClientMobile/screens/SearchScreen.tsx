import { useState, useEffect, useRef } from "react";
import MapView, { LatLng } from "react-native-maps";

import { Screen } from "../components/Screen";
import { AnimatedListHeader } from "../components/AnimatedListHeader";
import { Map } from "../components/Map";
import { SearchScreenParams } from "../types";
import { i18n } from "../i18n/i18n";
import React from "react";
import { Location } from "../types/locationIQ";

export const SearchScreen = ({
  route,
}: {
  route: { params: SearchScreenParams };
}) => {
  const [startLocation, setStartLocation] = useState<string | Location>(i18n.t('Search'));
  const [endLocation, setEndLocation] = useState<string | Location>(i18n.t('Search'));

  return (
    <Screen>
      <AnimatedListHeader
        startLocation={startLocation ? startLocation : i18n.t('Search')}
        endLocation={endLocation ? endLocation : i18n.t('Search')}
        setStartLocation={setStartLocation}
        setEndLocation={setEndLocation}
      />
      <Map
        location={route.params}
      />
    </Screen>
  );
};
