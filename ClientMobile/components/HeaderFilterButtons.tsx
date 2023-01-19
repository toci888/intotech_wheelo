import React from "react";
import { StyleSheet, View, Text, TouchableOpacity, Image } from "react-native";
import { MaterialCommunityIcons } from "@expo/vector-icons";
import { useNavigation } from "@react-navigation/native";

import { Location } from "../types/locationIQ";
import { theme } from "../theme";
import { i18n } from "../i18n/i18n";
import { SearchScreenParams } from "../types";

export const HeaderFilterButtons = ({ 
    startLocation, 
    endLocation, 
    startTime, 
    endTime 
  }: { 
    startLocation: Location, 
    endLocation: Location, 
    startTime: string,
    endTime: string
  }) => {
  const navigation = useNavigation();

  const submit = async () => {
    navigation.navigate("Root", {
      screen: "Search",
      params: {
        startLocation,
        endLocation,
        startLocationTime: startTime,
        endLocationTime: endTime,
        driverPassenger: 2,
        acceptableDistance: 800
      } as SearchScreenParams
    });
  }
  
  return <>{
    <View style={styles.container}>
      <View style = {{ flexDirection: 'row', marginHorizontal: 10 }}>
        <View style = {{ flexDirection: 'row', marginRight: "auto" }}>
          <TouchableOpacity onPress={() => console.log("Passenger")} style={{marginRight: 20}} >
            <Text style={styles.textButton}>{i18n.t('Passenger')}</Text>
          </TouchableOpacity>
          <TouchableOpacity onPress={() => console.log("Driver")}>
            <Text style={styles.textButton}>{i18n.t('Driver')}</Text>
          </TouchableOpacity>
        </View>
      
        {startLocation && startLocation.display_name !== i18n.t('Search') && endLocation.display_name !== i18n.t('Search') &&
          <TouchableOpacity onPress={() => submit()}>
            <MaterialCommunityIcons 
              name="check-circle"
              color={theme["color-success-500"]}
              size={48}
              style={styles.button}
            />
          </TouchableOpacity>
        }
      </View>
    </View>
  }</>;
};

const styles = StyleSheet.create({
  container: {
    borderRadius: 30,
    paddingBottom: 10
  },
  textButton: {
    fontWeight: 'bold',
    fontSize: 15,
    marginTop: 10,
    borderWidth: 3,
    padding: 8,
    borderRadius: 8,
    borderColor: theme["color-gray"],
    marginHorizontal: 3,
  },
  button: {

  },
});
