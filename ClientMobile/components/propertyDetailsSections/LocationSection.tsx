import { View, FlatList, StyleSheet } from "react-native";
import { Text } from "@ui-kitten/components";
import { MaterialCommunityIcons } from "@expo/vector-icons";
import MapView from "react-native-maps";

import { CollocateAccount } from "../../types/collocation";
import { getStateAbbreviation } from "../../utils/getStateAbbreviation";
import { Row } from "../Row";
import { MapMarker } from "../MapMarker";
import { theme } from "../../theme";
import { ScoreCard } from "../ScoreCard";
import React from "react";

export const LocationSection = ({ collocation }: { collocation: CollocateAccount }) => {
  return (
    <>
      <Text category={"h5"} style={styles.defaultVerticalMargin}>
        Location
      </Text>

      <Row style={styles.mapHeaderContainer}>
        <MaterialCommunityIcons name="map-outline" color="black" size={24} />
        <Text category={"h6"} style={styles.mapText}>
          Map
        </Text>
      </Row>

      <Text category={"c1"} appearance={"hint"}>
        {collocation.name}, {collocation.surname},{" "}
        {/* {getStateAbbreviation(collocation.state)} {collocation.zip} */}
      </Text>
      <View style={styles.mapContainer}>
        <Text>dane:{collocation.name},{collocation.latitudefrom},{collocation.longitudefrom}</Text>
        <MapView
          provider={"google"}
          style={styles.map}
          initialRegion={{
            latitude: collocation.latitudefrom,
            longitude: collocation.longitudefrom,
            latitudeDelta: 0.0922,
            longitudeDelta: 0.0421,
          }}
        >
          <MapMarker
            color={theme["color-info-400"]}
            lat={collocation.latitudefrom}
            lng={collocation.latitudeto}
          />
        </MapView>
      </View>

      {collocation.name ? (
        <FlatList
          horizontal
          style={styles.defaultVerticalMargin}
          showsHorizontalScrollIndicator={false}
          data={[collocation.name, collocation.surname]}
          keyExtractor={(item) => item}
          renderItem={({ item }) => (
            <ScoreCard score={{type: "Walk", 
              score: 1,
              description: "description"
            }} style={styles.scoreCard} />
          )}
        />
      ) : null}
    </>
  );
};

const styles = StyleSheet.create({
  defaultVerticalMargin: { marginVertical: 10 },
  mapText: { marginLeft: 10 },
  mapHeaderContainer: { alignItems: "center", marginVertical: 15 },
  mapContainer: {
    width: "100%",
    height: 250,
    marginVertical: 10,
    overflow: "hidden",
    borderRadius: 5,
  },
  map: {
    width: "100%",
    height: "100%",
  },
  scoreCard: { marginRight: 10 },
});
