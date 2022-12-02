import { TouchableOpacity, Platform, StyleSheet, TextInput, View } from "react-native";
import { Text } from "@ui-kitten/components";
import { MaterialCommunityIcons, MaterialIcons } from "@expo/vector-icons";
import { useNavigation } from "@react-navigation/native";

import { theme } from "../theme";
import { Row } from "./Row";
import React, { useState } from "react";
import RNDateTimePicker, { DateTimePickerEvent } from "@react-native-community/datetimepicker";
import DateTimePicker from "react-native-modal-datetime-picker";
// import TimePicker from '@mui/lab/TimePicker';

export const HeaderInput = ({ type, location }: { type: "start" | "finish", location: string }) => {
  const navigation = useNavigation();

  const [showDate, setShowDate] = useState(false);
  // Date().getMonth()
  const [startTime, setStartTime] = useState("07:30"); // let today = new Date().toLocaleTimeString();
  
  return (
  <View style={{flexDirection: 'row'}}>
    <TouchableOpacity style={styles.container} onPress={() => navigation.navigate("FindLocations")}>
      <Row style={{alignItems: 'center'}}>
        <Text style={styles.input}>{location}</Text>
        {/* <MaterialCommunityIcons name="magnify" color={theme["color-primary-500"]} size={28} style={styles.text}/> */}
        <MaterialIcons name="gps-fixed" size={24} color={theme["color-primary-500"]} style={styles.icon}/>
      </Row>
    </TouchableOpacity>

    <TouchableOpacity style={styles.dateContainer} onPress={() => setShowDate(true)}>
      <Row style={{alignItems: 'center'}}>
        <Text style={styles.input}>{startTime}</Text>
      </Row>
      {showDate && 
    <DateTimePicker
        locale="pl_PL"
        isDarkModeEnabled={false}
        textColor="black" //razem, bialy nie dziala
        // date={new Date("2022-12-02T14:53:00.000Z")}
        display="spinner" 
        isVisible={showDate}
        mode="time"
        onConfirm={(selectedDate: Date) => {
          if (selectedDate) {
            setShowDate(false);
            setStartTime(selectedDate.toTimeString().substring(0, 5))
          }
        }}
        onCancel={() => { setShowDate(false); }}
        
       />
      }
    </TouchableOpacity>
  </View>
  );
};

const styles = StyleSheet.create({
  container: {
    // marginLeft: 'auto',
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
    // backgroundColor: '#fff',
  },
  icon: {
    marginLeft: 10,
  },
});
