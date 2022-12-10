import React from "react";
import { useState, useEffect } from "react";
import { Text, Divider } from "@ui-kitten/components";
import { StyleSheet, Image, View, TouchableOpacity } from "react-native";

import { CollocateAccount, Collocation } from "../../types/collocation";
import { theme } from "../../theme";
import { Row } from "../Row";
import { TabBar } from "../TabBar";

const removeUnnecessaryButtons = (
  array: {
    title: string;
    onPress: () => void;
  }[],
  title: "Studio" | "1 Bedroom" | "2 Bedrooms" | "3+ Bedrooms"
) => {
  array.splice(
    array.findIndex((i) => i.title === title),
    1
  );
};

export const PricingAndFloorPlanSection = ({
  collocation,
}: {
  collocation: CollocateAccount;
}) => {
  const [currentApartments, setCurrentApartments] = useState(collocation.name);

  useEffect(() => {
    if (collocation.name !== currentApartments) {
      setCurrentApartments(collocation.name);
    }
  }, [collocation]);

  const filterByBedroom = (
    numOfBedrooms: number,
    equalityType: "gt" | "eq"
  ) => {
    if (collocation.name) {
      let filtered = collocation.isDriver;

      setCurrentApartments(filtered.toString());
    }
  };

  const floorPlanOptions = [
    {
      title: "All",
      onPress: () => setCurrentApartments(collocation.name),
    },
    {
      title: "Studio",
      onPress: () => filterByBedroom(0, "eq"),
    },
    {
      title: "1 Bedroom",
      onPress: () => filterByBedroom(1, "eq"),
    },
    {
      title: "2 Bedrooms",
      onPress: () => filterByBedroom(2, "eq"),
    },
    {
      title: "3+ Bedrooms",
      onPress: () => filterByBedroom(2, "gt"),
    },
  ];

  let containsStudio,
    contains1Bed,
    contains2Bed,
    contains3Plus = false;
  if (collocation.name && collocation.name.length > 0) {
    // for (let i in collocation.apartments) {
    //   if (collocation.apartments[i].bedrooms === 0) containsStudio = true;
    //   if (collocation.apartments[i].bedrooms === 1) contains1Bed = true;
    //   if (collocation.apartments[i].bedrooms === 2) contains2Bed = true;
    //   if (collocation.apartments[i].bedrooms >= 3) contains3Plus = true;
    // }
    if (!containsStudio) removeUnnecessaryButtons(floorPlanOptions, "Studio");
    if (!contains1Bed) removeUnnecessaryButtons(floorPlanOptions, "1 Bedroom");
    if (!contains2Bed) removeUnnecessaryButtons(floorPlanOptions, "2 Bedrooms");
    if (!contains3Plus)
      removeUnnecessaryButtons(floorPlanOptions, "3+ Bedrooms");
  }

  return (
    <>
      <Text category={"h5"} style={styles.defaultMarginVertical}>
        Pricing & Floor Plans
      </Text>
      {currentApartments && currentApartments.length > 0 ? (
        <>
          <TabBar
            tabs={floorPlanOptions}
            style={styles.defaultMarginVertical}
          />
          <Text>zxzc</Text>
          
        </>
      ) : (
        <Text style={styles.apartmentLogisticsTitle}>No Apartments Listed</Text>
      )}
    </>
  );
};

const styles = StyleSheet.create({
  defaultMarginVertical: {
    marginVertical: 10,
  },
  container: {
    padding: 10,
    width: "100%",
    borderColor: theme["color-gray"],
    borderWidth: 1,
    borderRadius: 5,
  },
  apartmentLogisticsContainer: {
    flexShrink: 1,
    width: "90%",
    paddingRight: 10,
    marginTop: -5,
  },
  apartmentLogisticsTitle: { fontSize: 16, fontWeight: "600" },
  apartmentLogisticsMargin: { marginTop: 1 },
  image: {
    height: 60,
    width: 60,
    borderRadius: 5,
    borderColor: theme["color-gray"],
    borderWidth: 1,
  },
  availableNowContainer: {
    marginTop: 15,
    justifyContent: "space-between",
  },
  divider: {
    backgroundColor: theme["color-gray"],
    marginTop: 5,
  },
  layeredText: { width: "21%" },
  availableText: { width: "37%" },
});
