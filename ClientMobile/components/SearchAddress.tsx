import React from "react";
import {
  View,
  Platform,
  StyleSheet,
  FlatList,
  TouchableOpacity,
  ViewStyle,
  TextInput,
} from "react-native";
import { Text, Input, Button } from "@ui-kitten/components";
import { useState } from "react";
import * as Locations from "expo-location";

import { getFormattedLocationText } from "../utils/getFormattedLocationText";
import { Row } from "./Row";
import { theme } from "../theme";
import { Location } from "../types/locationIQ";
import { getLocationByPlaceId, getSuggestedLocations, searchLocations } from "../services/location";
import { LozalizationLogo } from "./logos/LozalizationLogo";
import { MyLocationLogo } from "./logos/MyLocationLogo";
import { i18n } from "../i18n/i18n";
import { commonAlert } from "../utils/handleError";
import axios from "axios";
import { endpoints } from "../constants/constants";

export const SearchAddress = ({
  type,
  suggestions,
  setSuggestions,
  handleSuggestionPress,
  defaultLocation = "",
}: {
  type: "autocomplete" | "search";
  suggestions: Location[];
  setSuggestions: (item: Location[]) => void;
  handleSuggestionPress: (item: Location) => void;
  defaultLocation?: string;
}) => {
  const [value, setValue] = useState(defaultLocation);
  const handleChange = async (val: string) => {
    setValue(val);
    if (val.length > 2) await getSuggestions(val);
    else if (val.length === 0) setSuggestions([]);
  };

  const getSuggestions = async (value: string) => {
    let locations;
    if (type === "search") locations = await searchLocations(value); //TODO!
    else locations = await getSuggestedLocations(value);

    if (locations.length > 0) setSuggestions(locations as Location[]);
  };

  const handleSubmitEditing = async () => {
    await getSuggestions(value);

    // If only 1 suggestion appears, it's better UX for them to just press enter on the
    // keyboard, but if they are searching for a specific address & multiple appear,
    // the user needs to choose
    if (
      (type === "autocomplete" && suggestions.length > 0) ||
      suggestions.length === 1
    )
      handleSuggestionPress(suggestions[0]);
  };

  const SuggestedText = ({
    locationItem,
  }: {
    locationItem: Location;
  }) => {
    const location = getFormattedLocationText(locationItem, type);
    return (
      <Row style={styles.suggestionContainer}>
        <Text>{location}</Text>
      </Row>
    );
  };

  const getInput = () => {
    if (Platform.OS === "ios" && type === "autocomplete")
      return (
          <Input
            keyboardType="default"
            autoFocus
            selectionColor={theme["color-primary-500"]}
            placeholder="Enter Location"
            size={"large"}
            value={value}
            onChangeText={handleChange}
            onSubmitEditing={handleSubmitEditing}
            style={styles.defaultMarginTop}
          />
      );

    return (
      <Row>
        <View style={styles.defaultMarginTop}>
          <TextInput
            keyboardType="default"
            autoFocus
            placeholder="Enter Location"
            value={value}
            onChangeText={handleChange}
            onSubmitEditing={handleSubmitEditing}
          />
          <TouchableOpacity>
            <MyLocationLogo></MyLocationLogo>
          </TouchableOpacity>
        </View>
      </Row>
    );
  };

  return (
    <View>
      {getInput()}
      {suggestions.length > 0 ? (
        <FlatList
          showsVerticalScrollIndicator={false}
          data={suggestions as Location[]}
          keyExtractor={(item, index) => item.place_id + index}
          renderItem={({ item }) => (
            <TouchableOpacity style={styles.lastLocalizationStyle}
              onPress={() => {
                getLocationByPlaceId(item.place_id).then(m => {
                  handleSuggestionPress(m as Location)
                });
              }}
            >
              <Text style={{ marginRight: 15 }}>
                <LozalizationLogo></LozalizationLogo>
              </Text>
              <SuggestedText locationItem={item} />
              <Text>
                {item.address.road}
              </Text>
            </TouchableOpacity>
          )}
        />
      ) : null}
    </View>
  );
};

const styles = StyleSheet.create({
  defaultMarginTop: {
    marginTop: 10,
    borderRadius: 99,
    borderWidth: 1,
    borderColor: "#DBC2F5",
    flexDirection: 'row',
    justifyContent: "space-between",
    paddingVertical: 4,
    paddingHorizontal: 8,
    width: "100%"
  },
  suggestionContainer: {
  },
  lastLocalizationStyle: {
    alignItems: "center",
    flex: 1,
    flexDirection: "row",
    padding: 15,
    borderBottomWidth: 1,
  },
  container: {

  },
  icon: {
    marginLeft: 5,
  },
  text: {
    marginLeft: 10,
    fontWeight: "600",
  },
  buttonContainer: {
    flex: 1,
    flexDirection: "row",
    alignItems: 'center',
    justifyContent: "space-between"
  },
});
