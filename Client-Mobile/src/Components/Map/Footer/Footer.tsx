import React from 'react';
import {
  StyleSheet,
  SafeAreaView,
  Button,
  TouchableOpacity,
} from 'react-native';
import { FontAwesome, FontAwesome5, Ionicons } from '@expo/vector-icons';

const styles = StyleSheet.create({
  footer: {
    height: '130',
    backgroundColor: '#6B50a5',
    flex: 1,
    flexDirection: 'row',
    alignItems: 'center',
    justifyContent: 'space-around'
  },
  itemContainer: {
    paddingVertical: 20,
    borderRadius: 5,
    alignItems: 'center',
  },
});

const Footer = () => {

return (
  <SafeAreaView style={styles.footer}> 
    <TouchableOpacity onPress={() => console.log("List is clicked")}>
      <FontAwesome name="list-alt" size={80} color="white" />
    </TouchableOpacity>
    <TouchableOpacity onPress={() => console.log("Map is clicked")}>
      <FontAwesome5 name="map-marked-alt" size={80} color="green" />    
    </TouchableOpacity>
    <TouchableOpacity onPress={() => console.log("User is clicked")}>
      <Ionicons name="person" size={80} color="white" />
    </TouchableOpacity>        
  </SafeAreaView>
);

};
export default Footer;