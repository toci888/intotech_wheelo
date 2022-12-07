import { StyleSheet, FlatList, View, Dimensions } from "react-native";
import React from "react";
import { ImageCarousel } from "../components/ImageCarousel";
import { Divider, Text } from "@ui-kitten/components";
import { useQuery } from "react-query";
import axios from "axios";

import { PropertyHeaderSection } from "../components/propertyDetailsSections/PropertyHeaderSection";
import { Screen } from "../components/Screen";
import { properties } from "../data/properties";
import { theme } from "../theme";
import { PricingAndFloorPlanSection } from "../components/propertyDetailsSections/PricingAndFloorPlanSection";
import { AboutSection } from "../components/propertyDetailsSections/AboutSection";
import { ContactSection } from "../components/propertyDetailsSections/ContactSection";
import { AmentitiesSection } from "../components/propertyDetailsSections/AmenitiesSection";
import { LeaseAndFeesSection } from "../components/propertyDetailsSections/LeaseAndFeesSection";
import { LocationSection } from "../components/propertyDetailsSections/LocationSection";
import { ReviewSection } from "../components/propertyDetailsSections/ReviewSection";
import { endpoints, queryKeys } from "../constants/constants";
import { useSelectedPropertyQuery } from "../hooks/queries/useSelectedPropertyQuery";

export const PropertyDetailsScreen = ({
  route,
}: {
  route: { params: { propertyID: number } };
}) => {
  console.log("PROP");
  const property = useSelectedPropertyQuery(route.params.propertyID);
  console.log("PROP", property);
  if (!property.data) return <Text>Unable to get property details ...</Text>;

  return (
    <Screen>
      <FlatList
        data={[property.data]}
        keyExtractor={(item) => item.accountid.toString()}
        renderItem={({ item }) => (
          <>
            {item.image ? (
              <ImageCarousel
                images={item.image}
                indexShown
                imageStyle={styles.image}
              />
            ) : null}
            <View style={styles.contentContainer}>
              <PropertyHeaderSection property={item} />
              <Divider style={styles.divider} />
              <PricingAndFloorPlanSection property={item} />
              <Divider style={styles.divider} />
              <AboutSection property={item} />
              <Divider style={styles.divider} />
              <ContactSection property={item} />
              <Divider style={styles.divider} />
              <AmentitiesSection property={item} />
              <Divider style={styles.divider} />
              <LeaseAndFeesSection property={item} />
              <Divider style={styles.divider} />
              <LocationSection property={item} />
              <Divider style={styles.divider} />
              <ReviewSection property={item} />
              <Divider style={styles.divider} />
            </View>
          </>
        )}
      />
    </Screen>
  );
};

const styles = StyleSheet.create({
  image: {
    width: Dimensions.get("window").width,
    height: 250,
    borderTopRightRadius: 0,
    borderTopLeftRadius: 0,
  },
  contentContainer: {
    marginHorizontal: 10,
  },
  divider: {
    backgroundColor: theme["color-gray"],
    marginTop: 10,
  },
});
