import { TouchableOpacity, Platform, StyleSheet, View, useColorScheme } from "react-native";
import { Text } from "@ui-kitten/components";
import { MaterialIcons } from "@expo/vector-icons";
import { useNavigation } from "@react-navigation/native";

import { theme } from "../theme";
import { Row } from "./Row";
import React, { useState } from "react";
import DateTimePicker from "react-native-modal-datetime-picker";
import { Location } from "../types/locationIQ";

export const HeaderInput = ({ type, location, setLocation, time, setTime }: 
  { 
    type: "start" | "end", 
    location: Location, 
    setLocation: (location: Location) => void; 
    time: string,
    setTime: (time: string) => void
  }) => {
  const navigation = useNavigation();

  const [showDate, setShowDate] = useState(false);
  const colorScheme = useColorScheme();

  const themeTextStyle = 
    colorScheme === 'light' ? styles.lightThemeText : styles.darkThemeText;
  const themeIconStyle = 
    colorScheme === 'light' ? styles.lightThemeIcon : styles.darkThemeIcon;
  const themeContainerStyle =
    colorScheme === 'light' ? styles.lightContainer : styles.darkContainer;

  return (
    <View style={{flexDirection: 'row'}}>
      <TouchableOpacity style={[styles.container, themeContainerStyle]} onPress={() => { navigation.navigate("FindLocations", {type, location, setLocation} as any) }}>
        <Row style={{alignItems: 'center'}}>
          <Text style={[styles.input, themeTextStyle]}>{typeof(location) === 'string' ? location : location.display_name}</Text>
          <MaterialIcons name="gps-fixed" size={24} color={theme["color-primary-500"]} style={[styles.icon, themeIconStyle]}/>
        </Row>
      </TouchableOpacity>

      <TouchableOpacity style={[styles.dateContainer, themeContainerStyle]} onPress={() => setShowDate(true)}>
        <Row style={{alignItems: 'center'}}>
          <Text style={[styles.inputTime, themeTextStyle]}>{time}</Text>
        </Row>
        
        <DateTimePicker
          locale="pl_PL"
          isDarkModeEnabled={false}
          textColor="black" //razem, bialy sam nie dziala
          date={new Date(`July 1, 1999, ${time}`)}

          display="spinner" 
          isVisible={showDate}
          mode="time"
          onConfirm={(selectedDate: Date) => {
            if (selectedDate) {
              setShowDate(false);
              setTime(selectedDate.toTimeString().substring(0, 5))
            }
          }}
          onCancel={() => { setShowDate(false); }}
          onChange={(selectedTime) => {setTime(selectedTime.toLocaleString().substring(12, 17))}}
        />
      </TouchableOpacity>
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    marginTop: 8,
    marginBottom: Platform.OS === "ios" ? 5 : 15,
    borderWidth: 1,
    borderColor: theme["color-gray"],
    borderRadius: 20,
    padding: 8,
    width: 250
  },
  dateContainer: {
    marginTop: 8,
    marginLeft: 'auto',
    marginBottom: Platform.OS === "ios" ? 5 : 15,
    borderWidth: 1,
    borderColor: theme["color-gray"],
    borderRadius: 20,
    padding: 8,
    width: 100,
    textAlign: 'center'
  },
  input: {
    flex: 1,
  },
  inputTime: {
    textAlign: 'center',
    flex: 1,
  },
  icon: {
    marginLeft: 10,
  },
  lightContainer: {
    backgroundColor: theme["color-black"],
  },
  darkContainer: {
    backgroundColor: theme["color-white"],
  },
  lightThemeText: {
    color: "#EC82C5",
  },
  darkThemeText: {
    color: theme["color-primary-700"],
  },
  lightThemeIcon: {
    color: theme["color-black"],
  },
  darkThemeIcon: {
    color: theme["color-white"],
  },
});
