import { MaterialCommunityIcons } from "@expo/vector-icons";
import React from "react";
import { View, TextInput, StyleSheet } from "react-native";
import { Text } from "@ui-kitten/components";
import { Row } from "./Row";
import { LISTMARGIN } from "../constants/constants";
import { theme } from "../theme";

export const HomeAndWorkInput = () => {
  const [textHome, onChangeTextHome] = React.useState("Olesno, ul.Opolska 2");
  const [textWork, onChangeTextWork] = React.useState("Olesno, ul.Częstochowska 7");
    
  return (  
    <View>
      <Row style={styles.row}>
        <View style={{flexDirection: "column", width: "70%", marginBottom: 20}}>
          <Text category="h6" style={{"color": "white"}}>Gdzie mieszkasz?</Text>
          <TextInput
            style={styles.inputAdress}
            onChangeText={onChangeTextHome}
            value={textHome} />
          <MaterialCommunityIcons style={styles.swap}
            name={"swap-vertical"}
            size={28}
            color={"white"}
          />
          <Text category="h6" style={{"color": "white"}}>Gdzie pracujesz?</Text>
          <TextInput
            style={styles.inputAdress}
            onChangeText={onChangeTextWork}
            value={textWork} />
        </View>
        <View style={{flexDirection: "column", width: "30%", marginBottom: 20}}>
          <Text category="h6"></Text>
          <TextInput
            style={styles.inputTime}
            onChangeText={onChangeTextHome}
            value={textHome} />
          <Text></Text>
          <Text category="h6"></Text>
          <TextInput
            style={[styles.inputTime,
            {
              marginTop: 16,
            },
          ]}
            onChangeText={onChangeTextHome}
            value={textHome} />
        </View>
        <View>
          <MaterialCommunityIcons style={styles.check} 
            name={"check-circle"}
            size={28}
            color={theme["color-check"]}
          />
        </View>
      </Row>      
    </View>
    );
  };

const styles = StyleSheet.create({
  row: {
    flexDirection: "row"
  },
  swap: {
    marginLeft: "80%",
  },
  check: {
    width: "100%",
    right: 30,
    top: "75%",
    backgroundColor: theme["color-green"],
    borderRadius: 28,
  },
  inputAdress: {
    height: 40,
    margin: 8,
    marginBottom: 12,
    marginLeft: 0,
    borderWidth: 1,
    padding: 10,
    backgroundColor: "white",
  },  
  inputTime: {
    width: "60%",
    height: 40,
    margin: 8,
    marginBottom: 12,
    marginLeft: 0,
    borderWidth: 1,
    padding: 10,
    backgroundColor: "white",
  },  
});
