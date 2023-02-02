import React from "react";
import { StyleSheet, FlatList, View, Dimensions } from "react-native";
import { Divider, Text } from "@ui-kitten/components";

import { ImageCarousel } from "../components/ImageCarousel";
import { CollocationHeaderSection } from "../components/propertyDetailsSections/PropertyHeaderSection";
import { Screen } from "../components/Screen";
import { theme } from "../theme";
import { PricingAndFloorPlanSection } from "../components/propertyDetailsSections/PricingAndFloorPlanSection";
import { AboutSection } from "../components/propertyDetailsSections/AboutSection";
import { ContactSection } from "../components/propertyDetailsSections/ContactSection";
import { AmentitiesSection } from "../components/propertyDetailsSections/AmenitiesSection";
import { LeaseAndFeesSection } from "../components/propertyDetailsSections/LeaseAndFeesSection";
import { LocationSection } from "../components/propertyDetailsSections/LocationSection";
import { ReviewSection } from "../components/propertyDetailsSections/ReviewSection";
import { useSelectedCollocationQuery } from "../hooks/queries/useSelectedPropertyQuery";
import { i18n } from "../i18n/i18n";

export const CollocationDetailsScreen = ({
  route,
}: {
  route: { params: { collocationID: number } };
}) => {
  const collocation = useSelectedCollocationQuery(route.params.collocationID);
  if (!collocation.data) return <Text>{i18n.t('UnableToGetCollocationDetails')}</Text>;
  
  return (
    <Screen>
      <FlatList
        data={[collocation.data]}
        keyExtractor={(item) => item.idAccount.toString()}
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
              <CollocationHeaderSection collocation={item} />
              <Divider style={styles.divider} />
              <PricingAndFloorPlanSection collocation={item} />
              <Divider style={styles.divider} />
              <AboutSection collocation={item} />
              <Divider style={styles.divider} />
              <ContactSection collocation={item} />
              <Divider style={styles.divider} />
              <AmentitiesSection collocation={item} />
              <Divider style={styles.divider} />
              <LeaseAndFeesSection collocation={item} />
              <Divider style={styles.divider} />
              <LocationSection collocation={item} />
              <Divider style={styles.divider} />
              <ReviewSection collocation={item} />
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
