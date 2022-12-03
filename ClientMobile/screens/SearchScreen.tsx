import { Animated, View, StyleSheet } from "react-native";
import { useState, useEffect, useRef } from "react";
import MapView from "react-native-maps";
import LottieView from "lottie-react-native";
import { useNavigation } from "@react-navigation/native";

import { Screen } from "../components/Screen";
import { endpoints, HEADERHEIGHT, queryKeys } from "../constants/constants";
import { Card } from "../components/Card";
import { AnimatedListHeader } from "../components/AnimatedListHeader";
import { getPropertiesInArea } from "../data/properties";
import { Map } from "../components/Map";
import { SearchScreenParams } from "../types";
import { Property } from "../types/property";
import { Text } from "@ui-kitten/components";
import { useSearchPropertiesQuery } from "../hooks/queries/useSearchPropertiesQuery";
import { i18n } from "../i18n/i18n";

export const SearchScreen = ({
  route,
}: {
  route: { params: SearchScreenParams };
}) => {
  const navigation = useNavigation();
  const [mapShown, setMapShown] = useState<boolean>(true);
  const [scrollAnimation] = useState(new Animated.Value(0));
  const mapRef = useRef<MapView | null>(null);
  const [location, setLocation] = useState<string | undefined>(undefined);
  // console.log("routehere", route)
  let boundingBox: number[] = [];
  if (route.params?.boundingBox)
    boundingBox = [
      Number(route.params.boundingBox[0]),
      Number(route.params.boundingBox[1]),
      Number(route.params.boundingBox[2]),
      Number(route.params.boundingBox[3]),
      // Number(52.3831203918457),
      // Number(52.387120391845706),
      // Number(16.877011154174806),
      // Number(16.881011154174804),
    ];
  const searchProperties = useSearchPropertiesQuery(boundingBox);

  useEffect(() => {
    if (route.params) {
      setLocation(route.params.location);
      searchProperties.refetch();

      mapRef?.current?.animateCamera({
        center: {
          latitude: Number(route.params.lat),
          longitude: Number(route.params.lon),
          // latitude: Number("52,38512"),          
          // longitude: Number("16,879011"),
        },
      });
    }
  }, [route]);

  return (
    <Screen>
      <AnimatedListHeader
        scrollAnimation={scrollAnimation}
        setMapShown={setMapShown}
        mapShown={mapShown}
        location={location ? location : i18n.t('Search')}
        availableProperties={
          searchProperties.data ? searchProperties.data.length : undefined
        }
      />

      {mapShown ? (
        <Map
          properties={searchProperties?.data ? searchProperties.data : []}
          mapRef={mapRef}
          location={location ? location : i18n.t('Search')}
          setLocation={setLocation}
          initialRegion={
            route.params
              ? {
                  latitude: Number(route.params.lat),
                  longitude: Number(route.params.lon),
                  latitudeDelta: 0.4,
                  longitudeDelta: 0.4,
                }
              : undefined
          }
        />
      ) : (
        <>
          {searchProperties.data && searchProperties.data?.length > 0 ? (
            <Animated.FlatList
              onScroll={Animated.event(
                [
                  {
                    nativeEvent: {
                      contentOffset: {
                        y: scrollAnimation,
                      },
                    },
                  },
                ],
                { useNativeDriver: true }
              )}
              contentContainerStyle={{ paddingTop: HEADERHEIGHT - 20 }}
              bounces={false}
              scrollEventThrottle={16}
              data={searchProperties?.data}
              keyExtractor={(item) => item.ID.toString()}
              showsVerticalScrollIndicator={false}
              renderItem={({ item }) => (
                <Card
                  style={styles.card}
                  property={item}
                  onPress={() =>
                    navigation.navigate("PropertyDetails", {
                      propertyID: item.ID,
                    })
                  }
                />
              )}
            />
          ) : (
            <>
              {route.params ? (
                <View style={styles.lottieContainer}>
                  <Text category={"h6"}>No Properties Found</Text>
                  <Text appearance={"hint"}>
                    Please search in a different location.
                  </Text>
                </View>
              ) : (
                <View style={styles.lottieContainer}>
                  <LottieView
                    autoPlay
                    loop
                    style={styles.lottie}
                    source={require("../assets/lotties/SearchScreen.json")}
                  />
                  <Text category={"h6"}>Begin Your Search</Text>
                  <Text appearance={"hint"} style={styles.subHeader}>
                    Find apartments anytime and anywhere.
                  </Text>
                </View>
              )}
            </>
          )}
        </>
      )}
    </Screen>
  );
};

const styles = StyleSheet.create({
  card: { marginVertical: 5 },
  lottieContainer: {
    backgroundColor: "#fff",
    flex: 1,
    justifyContent: "center",
    alignItems: "center",
  },
  lottie: { height: 200, width: 200 },
  subHeader: {
    marginTop: 10,
  },
});
