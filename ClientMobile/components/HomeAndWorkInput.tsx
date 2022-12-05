import { MaterialIcons } from "@expo/vector-icons";
import React, { useState } from "react";
import { View, StyleSheet, Platform, TouchableOpacity } from "react-native";
import { Text } from "@ui-kitten/components";
import { Row } from "./Row";
import { LISTMARGIN } from "../constants/constants";
import { theme } from "../theme";
import { useNavigation } from "@react-navigation/native";
import DateTimePicker from "react-native-modal-datetime-picker";

export const HomeAndWorkInput = ({ type, location, setLocation }: 
  { type: "start" | "end", location: string, setLocation: (location: string) => void; }) => {
  const navigation = useNavigation();

  const [showDate, setShowDate] = useState(false);
  const [startTime, setStartTime] = useState(type==="start" ? "07:30" : "16:00");
  
  const actualTime = (): Date => {
    const date = new Date();
    console.log(date)
    return date
  };
    
  return (
    <View style={styles.container}>
      <Row style={styles.row}>
        <Text category="h3" style={styles.h3}>Cześć <Text category="h3" style={styles.h3Span}>Dawid.</Text></Text>
      </Row>
      <Row style={styles.row}>
        <Text category="h6" style={styles.h3}>Gdzie mieszkasz?</Text>
        <Text category="h6" style={styles.h3}>Czas wyjazdu?</Text>        
      </Row>
      <Row style={styles.row}>
        <TouchableOpacity style={styles.addressContainer} onPress={() => { navigation.navigate("FindLocations", {type: "start", location, setLocation}) }}>
            <Text style={styles.input}>{location}</Text>
            <MaterialIcons name="gps-fixed" size={24} color={theme["color-primary-500"]} style={styles.icon}/>
        </TouchableOpacity>
        <TouchableOpacity style={styles.dateContainer} onPress={() => setShowDate(true)}>
          <Text style={styles.inputTime}>{startTime}</Text>
        
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
                setStartTime(selectedDate.toTimeString().substring(0, 5))
              }
            }}
            onCancel={() => { setShowDate(false); }}
            onChange={(time) => {setStartTime(time.toLocaleString().substring(10, 16));}}
          />
        </TouchableOpacity>
      </Row>
      <Row style={styles.row}>
        <TouchableOpacity style={styles.swap}>
          <MaterialIcons name="swap-vert" size={24} color={"white"} style={styles.icon} onPress={() => console.log("press a swap")} />
        </TouchableOpacity>
      </Row>
      <Row style={styles.row}>
        <Text category="h6" style={styles.h3}>Gdzie pracujesz?</Text>
        <Text category="h6" style={styles.h3}>Czas powrotu?</Text>        
      </Row>
      <Row style={styles.row}>
        <TouchableOpacity style={styles.addressContainer} onPress={() => { navigation.navigate("FindLocations", {type: "end", location, setLocation}) }}>
            <Text style={styles.input}>{location}</Text>
            <MaterialIcons name="gps-fixed" size={24} color={theme["color-primary-500"]} style={styles.icon} />
        </TouchableOpacity>
        <TouchableOpacity style={styles.dateContainer} onPress={() => setShowDate(true)}>
          <Text style={styles.inputTime}>{startTime}</Text>
        
          <DateTimePicker
            locale="pl_PL"
            isDarkModeEnabled={false}
            textColor="black"
            date={actualTime()}

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
            onChange={(time) => {setStartTime(time.toLocaleString().substring(10, 16));}}
          />
        </TouchableOpacity>
      </Row>  
      <Row style={styles.row}>
        <TouchableOpacity style={styles.check}>
          <MaterialIcons name="check-circle" size={24} color={theme["color-green"]} style={styles.icon} onPress={() => console.log("press a check")} />
        </TouchableOpacity>
      </Row>    
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    marginTop: Platform.OS === "ios" ? 20 : 0,
    marginHorizontal: LISTMARGIN,
  },
  dateContainer: {
     marginLeft: 30,
  },
  input: {
    flex: 1,    
  },
  icon: {
    marginLeft: 10,
  },
  row: {
    flexDirection: "row",
    justifyContent: "space-between",
    alignItems: "center",
    marginBottom: 4,
  },
  swap: {
    marginLeft: "66%",
  },
  check: {
    justifyContent: "flex-end",
    marginLeft: "auto",
  },
  addressContainer: {
    textAlign: 'center',
    flex: 1,
    height: 40,
    borderRadius: 10,
    borderWidth: 1,
    backgroundColor: "white",
    flexDirection: "row",
    alignItems: "center",
  },  
  inputTime: {
    height: 40,
    borderRadius: 10,
    borderWidth: 1,
    padding: 10,
    backgroundColor: "white",
  },
  h3: {
    color: "white",
  },
  h3Span: {
    color: theme["color-green"],
  },
});
