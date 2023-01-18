import React from "react";
import { useState } from "react";

import { Screen } from "../components/Screen";
import { AnimatedListHeader } from "../components/AnimatedListHeader";
import { Map } from "../components/Map";
import { SearchScreenParams } from "../types";
import { i18n } from "../i18n/i18n";
import { Location } from "../types/locationIQ";

export const SearchScreen = ({route}: {
  route: { params: SearchScreenParams };
}) => {
  const [startLocation, setStartLocation] = useState<Location>({display_name: i18n.t('Search')} as Location);
  const [endLocation, setEndLocation] = useState<Location>({display_name: i18n.t('Search')} as Location);
  
  return (
    <Screen>
      <AnimatedListHeader
        startLocation={startLocation} endLocation={endLocation}
        setStartLocation={setStartLocation} setEndLocation={setEndLocation}
      />
      <Map location={route.params} />
    </Screen>
  );
};
