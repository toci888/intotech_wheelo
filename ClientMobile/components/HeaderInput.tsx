import { TouchableOpacity, Platform, StyleSheet, View } from "react-native";
import { Text } from "@ui-kitten/components";
import { MaterialIcons } from "@expo/vector-icons";
import { DefaultTheme, useNavigation } from "@react-navigation/native";

import { theme } from "../theme";
import { Row } from "./Row";
import React, { useState } from "react";
import DateTimePicker from "react-native-modal-datetime-picker";
import { Location } from "../types/locationIQ";
import { os } from "../constants/constants";

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
  
  return (
    <View style={{flexDirection: 'row'}}>
      <TouchableOpacity style={styles.container} onPress={() => { navigation.navigate("FindLocations", {type, location, setLocation} as any) }}>
        <Row style={{alignItems: 'center'}}>
          <Text style={[styles.input]}>{typeof(location) === 'string' ? location : location.display_name}</Text>
          <MaterialIcons name="gps-fixed" size={24} color={theme["color-primary-500"]} style={styles.icon}/>
        </Row>
      </TouchableOpacity>

      <TouchableOpacity style={styles.dateContainer} onPress={() => setShowDate(true)}>
        <Row style={{alignItems: 'center'}}>
          <Text style={styles.inputTime}>{time}</Text>
        </Row>
        
        { Platform.OS === os.ios ? 
        <DateTimePicker
          locale="pl_PL"
          isDarkModeEnabled={DefaultTheme.dark}
          textColor={DefaultTheme.dark ? "white" : "black"} //razem, bialy sam nie dziala
          date={new Date(`July 1, 1999, ${time}`)}

          display="spinner" 
          isVisible={showDate}
          mode="time"
          onConfirm={(selectedDate: Date) => {
            if (selectedDate) {
              setShowDate(false);
              setTime(selectedDate.toTimeString().split(' ')[0].substring(0,5))
            }
          }}
          onCancel={() => { setShowDate(false); }}
          onChange={(selectedTime) => {console.log("zmieniam", selectedTime.toLocaleString().split(', ')[1].substring(0,5));setTime(selectedTime.toLocaleString().split(', ')[1].substring(0,5))}}
          // onChange={() => {console.log("zmieniam");}}
        /> : 
        <DateTimePicker
          locale="pl_PL"
          isDarkModeEnabled={DefaultTheme.dark}
          // textColor={DefaultTheme.dark ? "white" : "black"} //razem, bialy sam nie dziala
          date={new Date(`July 1, 1999, ${time}`)}

          display="clock" 
          isVisible={showDate}
          mode="time"
          onConfirm={(selectedDate: Date) => {
            if (selectedDate) {
              setShowDate(false);
              setTime(selectedDate.toTimeString().split(' ')[0].substring(0,5))
            }
          }}
          onCancel={() => { setShowDate(false); }}
          onChange={(selectedTime) => {console.log("zmieniam", selectedTime.toLocaleString().split(', ')[1].substring(0,5));setTime(selectedTime.toLocaleString().split(', ')[1].substring(0,5))}}
          // onChange={() => {console.log("zmieniam");}}
        />}

      </TouchableOpacity>
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    marginTop: 8,
    marginBottom: Platform.OS === "ios" ? 5 : 15,
    backgroundColor: theme["color-white"],
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
    backgroundColor: theme["color-white"],
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
});
