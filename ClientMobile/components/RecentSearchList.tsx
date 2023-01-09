import React from "react";
import { useState } from "react";
import { View, StyleSheet, ViewStyle } from "react-native";
import { Button } from "@ui-kitten/components";
import { useNavigation } from "@react-navigation/native";

import { Location } from "../types/locationIQ";
import { RecentSearchButton } from "./RecentSearchButton";
import { getFormattedLocationText } from "../utils/getFormattedLocationText";
import { i18n } from "../i18n/i18n";

export const RecentSearchList = ({
  recentSearches, style, type, location, setLocation 
  }: {
  recentSearches?: Location[];
  style?: ViewStyle;
  type: "start" | "end", 
  location: Location, 
  setLocation: (location: Location) => void
}) => {
  const [showMore, setShowMore] = useState(false);
  const navigation = useNavigation();

  const handleButtonPress = () => setShowMore(!showMore);

  const ShowButton = ({ text }: { text: string }) => (
    <Button appearance={"ghost"} status={"info"} style={styles.showButton} onPress={handleButtonPress}>
      {text}
    </Button>
  );

  const handleRecentSearchButtonPress = (loc: Location) => {
    setLocation(loc)
    navigation.goBack();
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
          <ShowButton text={i18n.t("SeeMore")} />
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
        {recentSearches.length > 2 ? <ShowButton text={i18n.t("SeeLess")} /> : null}
      </>
    );
  };

  return <View style={style}>{getList()}</View>;
};

const styles = StyleSheet.create({
  recentSearchButton: { marginVertical: 5 },
  showButton: { alignSelf: "flex-start" },
});
