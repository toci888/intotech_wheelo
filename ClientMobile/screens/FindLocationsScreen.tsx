import React from "react";
import { Platform, Image, StyleSheet, View, ScrollView, PixelRatio, Touchable, TouchableOpacity } from "react-native";
import { useState } from "react";
import { useNavigation } from "@react-navigation/native";
import { useQueryClient } from "react-query";
import Svg, { Path } from 'react-native-svg';
import { Screen } from "../components/Screen";
import { ModalHeader } from "../components/ModalHeader";
import { theme } from "../theme";
import { Location } from "../types/locationIQ";
import { CurrentLocationButton } from "../components/CurrentLocationButton";
import { RecentSearchList } from "../components/RecentSearchList";
import { SearchAddress } from "../components/SearchAddress";
import { Text } from "react-native";
import { ClearLogo } from "../components/logos/ClearLogo";
import { AlarmLogo } from "../components/logos/AlarmLogo";
import { HouseLogo } from "../components/logos/HouseLogo";
import { WorkLogo } from "../components/logos/WorkLogo";
import { RestaurantLogo } from "../components/logos/RestaurantLogo";
import { DriverLogo } from "../components/logos/DriverLogo";
import { PassengerLogo } from "../components/logos/PassengerLogo";
import { SavedLocalizationButton } from "../components/SavedLocalizationsButton";
import { HeaderFilterButtons } from "../components/HeaderFilterButtons";
import symbolicateStackTrace from "react-native/Libraries/Core/Devtools/symbolicateStackTrace";



export const FindLocationsScreen = ({route}:{
  route: { params: { type: "start" | "end", location: Location, setLocation: (location: Location) => Location;} };
}) => {
  const [suggestions, setSuggestions] = useState<Location[]>([]);
  const navigation = useNavigation();
  const queryClient = useQueryClient();

  const savedLocalization=[
    { logo: HouseLogo, text: 'DOM' },
    { logo: WorkLogo, text: 'PRACA' },
    { logo: RestaurantLogo, text: 'PUB' }
  ]

  const travelers=[
    {logo: DriverLogo, text: 'kierowca'},
    {logo: PassengerLogo, text: 'pasażer'}
  ]

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
    route.params.setLocation(loc);
    navigation.goBack();
  };

  return (
    <Screen>
      
      {Platform.OS === "ios" ? <ModalHeader /> : null}         
      <View style={styles.screenContent}> 
        <View style={styles.inputDate}>
          <Text style={styles.textStyle}>
              START
          </Text>
          <ClearLogo></ClearLogo>
        </View>
        <SearchAddress
          type="autocomplete"
          handleGoBack={navigation.goBack}
          suggestions={suggestions}
          setSuggestions={(item) => setSuggestions(item as Location[])}
          handleSuggestionPress={(item) => {handleNavigate(item as Location)}}
        />
        {suggestions.length === 0 ? (
          <ScrollView bounces={false}>
            <CurrentLocationButton style={styles.currentLocationButton} location={route.params.location} setLocation={route.params.setLocation} />
            <View style={styles.hourseLeavingContainer}>
              <Text style={styles.textHourseStyle}>
                Godzina wyjazdu
              </Text>
              <TouchableOpacity style={styles.hourseLeavingButton}>
                <Text style={styles.textHourseStyle1}>
                  7:20
                </Text>
                <AlarmLogo></AlarmLogo>
              </TouchableOpacity>
            </View>
            <ScrollView horizontal={true}>
              {savedLocalization.map((lozalization)=>(
                  <SavedLocalizationButton
                  logo={lozalization.logo}
                  text={lozalization.text}
                  textStyle={styles.tileText}
                  style={styles.imageContainer}
              />
              ))}
              {/* <View style={styles.imageContainer}>
                <HouseLogo></HouseLogo>
                <Text style={styles.tileText}>
                  DOM
                </Text>
              </View>
              <View style={styles.imageContainer}>
                <WorkLogo></WorkLogo>
                <Text style={styles.tileText}>
                  PRACA
                </Text>
              </View> */}
              {/* <View style={styles.imageContainer}>
                <RestaurantLogo></RestaurantLogo>
                <Text style={styles.tileText}>
                  PUB
                </Text>r
              </View>  */}
            </ScrollView>
            <View style={styles.tileContainers}>
              {travelers.map((traveler) =>(
              <SavedLocalizationButton 
                logo={traveler.logo}
                text={traveler.text}
                textStyle={styles.driverText}
                style={styles.tileDriverContainers}
              />
              ))}
                {/* <View style={styles.tileDriverContainers}>
                  <DriverLogo></DriverLogo>
                  <Text style={styles.driverText}>
                    kierowca
                  </Text>
                </View>
                <View style={styles.tileDriverContainers}>
                  <PassengerLogo></PassengerLogo>
                    <Text style={styles.driverText}>
                      pasażer
                    </Text>
                </View> */}
            </View>
            <RecentSearchList
              style={styles.recentSearchContainer}
              recentSearches={recentSearches}
              type={route.params.type} 
              location={route.params.location} 
              setLocation={route.params.setLocation}
            />
          </ScrollView>
        ) : null}
      </View>
    </Screen>
  );
};

const styles = StyleSheet.create({
  screenContent: {
    paddingHorizontal: 15,
    flexDirection: "column",
    justifyContent: "flex-start",
    gap: 40,
    flex: 1,
    borderWidth: 1,
    borderColor: "#DBC2F5",
    shadowColor: '#000',
    shadowOffset: {
      width: 3,
      height: 4,
    },
    shadowOpacity: 0.25,
    shadowRadius: 6,
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
    borderRadius: 99,
    borderWidth: 1,
    borderColor: "#DBC2F5",
    flexDirection: 'row',
    paddingVertical: 4,
    paddingHorizontal: 8,
    width: "100%",
    marginTop: 20
  },
  inputDate: {
    flexDirection: 'row',
    paddingVertical: 0,
    paddingHorizontal: 20,
    marginTop: 20,
    marginBottom: 20,
    justifyContent: 'space-between',
    alignItems: 'center',
    alignSelf: 'stretch',
  },
  textStyle: {
    color: '#F3EBFC',
    fontSize: 24,
    fontFamily: 'OpenSans',
    fontWeight: 'normal',
    lineHeight: 28.8, 
  },
  hourseLeavingContainer: {
    marginTop: 20,
    height: 38,
    marginLeft: "auto",
    flex: 1,
    flexDirection: "row",
  },
  hourseLeavingButton: {
    borderRadius: 99,
    borderWidth: 1,
    borderColor: "#DBC2F5",   
    width: 83,
    alignItems: "center",
    marginHorizontal: 12,
    justifyContent: "center",
    paddingRight: 8,
    paddingLeft: 8,
    paddingTop: 4,
    paddingBottom: 4,
    flexDirection: "row"
    
  },
  textHourseStyle: {
    color: '#DBC2F5',
    fontSize: 16,
    fontFamily: 'OpenSans',
    fontWeight: 'normal',
    lineHeight: 22, 
    alignSelf: 'flex-end',
  },
  textHourseStyle1: {
    color: '#DBC2F5',
    fontSize: 16,
    fontFamily: 'OpenSans',
    fontWeight: 'normal',
    lineHeight: 22,
  },
  imageContainer: {
    flex: 1,
    flexDirection: "row",
    width: 150,
    backgroundColor: "#9C4DC7",
    padding: 8,
    borderRadius: 4,
    marginTop: 40,
    marginLeft: 2,
    marginRight: 2
    },
  tileText: {
    fontSize: 14,
    fontFamily: "Open Sans",
    fontStyle: "normal",
    fontWeight: "700",
    lineHeight: 16.8,
    letterSpacing: 0.15,
    alignSelf: "flex-end",
    marginLeft: 5
    },
    tileContainers: {
      flex: 1,
      flexDirection: "row",
    },
    driverText: {
      fontSize: 14,
      fontFamily: "Open Sans",
      fontStyle: "normal",
      fontWeight: "400",
      lineHeight: 21,
      letterSpacing: 0.15,
      alignSelf: "flex-end",
      marginLeft: 5,
      color: '#DBC2F5',
      },
    tileDriverContainers: {
      flex: 1,
      flexDirection: "row",
      marginTop: 40
    },
  recentSearchContainer: { marginTop: 30 },
  
});
