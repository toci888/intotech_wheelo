import React, { useState } from 'react';
import { StyleSheet, Text, TextInput, View } from 'react-native';
import { environment } from '../../environment';
import { GooglePlacesInput } from '../Components/Map/GooglePlacesInput';
import { StatusBar } from 'expo-status-bar';
import { Feather } from '@expo/vector-icons'; 
import { TouchableOpacity } from 'react-native-gesture-handler';

export const GoogleMapsInputsScreen = (props: any) => {
  const [users, setUsers] = useState([]);

  const getData = async () => {
    // const res = await axios.get(environment.apiUrl + 'api/Account/Select');
    const res = await fetch(environment.apiUrl + 'api/Account/Select');

    setUsers(await res.json());
  };

  const [text, onChangeText] = React.useState('text');

  return (
    // <Button onPress={getData} title='Learn More'></Button>
    // <View>
    //   {users.map((user: any) => (
    //     <Text key={user.name}>{user.name} {user.email}</Text>
    //   ))}
    // </View>
    <View style={styles.container}>
      <TouchableOpacity onPress={() => console.log("click")}>
      <Feather name="user" size={24} color="white" />
      </TouchableOpacity>
      <TextInput style={{flex:.5}} onChangeText={onChangeText} value={text}/>
      <GooglePlacesInput inputText='zxc' minLength={4}/>
      <GooglePlacesInput inputText='asd' minLength={4}/>
      <StatusBar style='auto' />
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    paddingTop: '20%',
    backgroundColor: 'gray',
    // alignItems: "center",
    // justifyContent: 'center',
  }
});