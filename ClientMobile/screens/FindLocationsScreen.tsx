import React from "react";
import { Platform, StyleSheet, View, ScrollView } from "react-native";
import { useState } from "react";
import { useNavigation } from "@react-navigation/native";
import { useQueryClient } from "react-query";

import { Screen } from "../components/Screen";
import { ModalHeader } from "../components/ModalHeader";
import { theme } from "../theme";
import { Location } from "../types/locationIQ";
import { CurrentLocationButton } from "../components/CurrentLocationButton";
import { getFormattedLocationText } from "../utils/getFormattedLocationText";
import { RecentSearchList } from "../components/RecentSearchList";
import { SearchAddress } from "../components/SearchAddress";

export const FindLocationsScreen = ({route}:{
  route: { params: { type: "start" | "end", location: string | Location, setLocation: (location: string | Location) => Location;} };
}) => {
  const [suggestions, setSuggestions] = useState<Location[]>([]);
  const navigation = useNavigation();
  const queryClient = useQueryClient();

  const recentSearches: Location[] | undefined = queryClient.getQueryData(route.params.type === "start" ? "recentStartSearches" : "recentEndSearches");

  const setRecentSearch = (location: Location) => {
    queryClient.setQueryData(route.params.type === "start" ? "recentStartSearches" : "recentEndSearches", () => {
      if (recentSearches) {
        let included = false;
        for (let i of recentSearches) {
          if (
            i.display_name === location.display_name &&
            i.lon === location.lon &&
            i.lat === location.lat
          ) {
            included = true;
            break;
          }
        }
        if (!included) return [location, ...recentSearches];
        return recentSearches;
      }
      return [location];
    });
  };

  const handleNavigate = (loc: Location) => {
    setRecentSearch(loc);
    route.params.location = loc;
    route.params.setLocation(loc as Location);
    navigation.goBack();
  };

  return (
    <Screen>
      {Platform.OS === "ios" ? <ModalHeader /> : null}
      <View style={styles.screenContent}>
        <SearchAddress
          type="autocomplete"
          handleGoBack={navigation.goBack}
          suggestions={suggestions}
          setSuggestions={(item) => setSuggestions(item as Location[])}
          handleSuggestionPress={(item) => {handleNavigate(item as Location)}}
        />
        {suggestions.length === 0 ? (
          <ScrollView bounces={false}>
            <CurrentLocationButton style={styles.currentLocationButton} />
            <RecentSearchList
              style={styles.recentSearchContainer}
              recentSearches={recentSearches}
              type={route.params.type} 
              location={route.params.location} 
              setLocation={route.params.setLocation}              />
          </ScrollView>
        ) : null}
      </View>
    </Screen>
  );
};

const styles = StyleSheet.create({
  screenContent: {
    marginHorizontal: 10,
  },
  defaultMarginTop: {
    marginTop: 10,
  },
  suggestionContainer: {
    alignItems: "center",
    padding: 15,
    borderBottomWidth: 1,
    borderBottomColor: theme["color-gray"],
  },
  currentLocationButton: {
    marginTop: 40,
  },
  recentSearchContainer: { marginTop: 30 },
});
