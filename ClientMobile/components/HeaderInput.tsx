import { TouchableOpacity, Platform, StyleSheet, View } from "react-native";
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
    location: string | Location, 
    setLocation: (location: string | Location) => void; 
    time: string,
    setTime: (time: string) => void
  }) => {
  const navigation = useNavigation();

  const [showDate, setShowDate] = useState(false);
  
  const actualTime = (): Date => {
    const date = new Date();
    // console.log(date)
    return date
  }
  
  return (
    <View style={{flexDirection: 'row'}}>
      <TouchableOpacity style={styles.container} onPress={() => { navigation.navigate("FindLocations", {type, location, setLocation}) }}>
        <Row style={{alignItems: 'center'}}>
          <Text style={styles.input}>{typeof(location) === 'string' ? location : location.display_name}</Text>
          <MaterialIcons name="gps-fixed" size={24} color={theme["color-primary-500"]} style={styles.icon}/>
        </Row>
      </TouchableOpacity>

      <TouchableOpacity style={styles.dateContainer} onPress={() => setShowDate(true)}>
        <Row style={{alignItems: 'center'}}>
          <Text style={styles.inputTime}>{time}</Text>
        </Row>
        
        <DateTimePicker
          locale="pl_PL"
          isDarkModeEnabled={false}
          textColor="black" //razem, bialy sam nie dziala
          date={actualTime()}

          display="spinner" 
          isVisible={showDate}
          mode="time"
          onConfirm={(selectedDate: Date) => {
            if (selectedDate) {
              setShowDate(false);
              setTime(selectedDate.toTimeString().substring(0, 5))
              // setStartTime(selectedDate.toTimeString().substring(0, 5))
            }
          }}
          onCancel={() => { setShowDate(false); }}
          onChange={(selectedTime) => {setTime(selectedTime.toLocaleString().substring(10, 16))}}
        />
      </TouchableOpacity>
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    marginBottom: Platform.OS === "ios" ? 10 : 30,
    borderWidth: 1,
    borderColor: theme["color-gray"],
    borderRadius: 30,
    padding: 8,
    width: 250
  },
  dateContainer: {
    marginLeft: 'auto',
    marginBottom: Platform.OS === "ios" ? 10 : 30,
    borderWidth: 1,
    borderColor: theme["color-gray"],
    borderRadius: 30,
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
