import React from "react";
import { useState } from "react";
import { View, StyleSheet, ViewStyle } from "react-native";
import { Button } from "@ui-kitten/components";
import { useNavigation } from "@react-navigation/native";

import { Location } from "../types/locationIQ";
import { RecentSearchButton } from "./RecentSearchButton";
import { getFormattedLocationText } from "../utils/getFormattedLocationText";

export const RecentSearchList = ({
  recentSearches,
  style,
  type, location, setLocation
}: {
  recentSearches?: Location[];
  style?: ViewStyle;
  type: "start" | "end", 
  location: string | Location, setLocation: (location: string | Location) => void
}) => {
  const [showMore, setShowMore] = useState(false);
  const navigation = useNavigation();

  const handleButtonPress = () => setShowMore(!showMore);

  const ShowButton = ({ text }: { text: string }) => (
    <Button
      appearance={"ghost"}
      status={"info"}
      style={styles.showButton}
      onPress={handleButtonPress}
    >
      {text}
    </Button>
  );

  const handleRecentSearchButtonPress = (location: Location) => {
    setLocation(location.display_name)
    navigation.goBack();
    // navigation.navigate("Root", type === "start"? {
    //   screen: "Search",
    //   params: {
    //     startLocation: getFormattedLocationText(location, "autocomplete"),
    //     startLat: location.lat,
    //     startLon: location.lon,
    //     startBoundingBox: location.boundingbox,
    //   }} : {
    //     screen: "Search",
    //     params: {
    //       endLocation: getFormattedLocationText(location, "autocomplete"),
    //       endLat: location.lat,
    //       endLon: location.lon,
    //       endBoundingBox: location.boundingbox,
    //     }
    // })
  };

  const getList = () => {
    if (!recentSearches || recentSearches.length === 0) return;

    if (recentSearches.length > 2 && !showMore)
      return (
        <>
          {recentSearches.map((i, index) =>
            index < 2 ? (
              <RecentSearchButton
                key={i.display_name + index}
                name={getFormattedLocationText(i, "autocomplete")}
                style={styles.recentSearchButton}
                onPress={() => handleRecentSearchButtonPress(i)}
              />
            ) : null
          )}
          <ShowButton text="See More" />
        </>
      );

    return (
      <>
        {recentSearches.map((i, index) => (
          <RecentSearchButton
            key={i.display_name + index}
            name={getFormattedLocationText(i, "autocomplete")}
            style={styles.recentSearchButton}
            onPress={() => handleRecentSearchButtonPress(i)}
          />
        ))}
        {recentSearches.length > 2 ? <ShowButton text="See Less" /> : null}
      </>
    );
  };

  return <View style={style}>{getList()}</View>;
};

const styles = StyleSheet.create({
  recentSearchButton: { marginVertical: 5 },
  showButton: { alignSelf: "flex-start" },
});
