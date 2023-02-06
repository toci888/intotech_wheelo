import React from "react";
import { useColorScheme } from "react-native";

import { Screen } from "../components/Screen";
import { AnimatedListHeader } from "../components/AnimatedListHeader";
import { Map } from "../components/Map";
import { SearchScreenParams } from "../types";


export const SearchScreen = ({route}: {
  route: { params: SearchScreenParams };
}) => {
  const colorScheme = useColorScheme();
  
  return (
    <Screen>
      <AnimatedListHeader />
      <Map location={route.params} colorScheme={colorScheme}/>
    </Screen>
  );
};
