import { StatusBar } from 'expo-status-bar';
import { useState } from 'react';
import {
  StyleSheet,
  Text,
  View,
  Button,
  SafeAreaView,
  Dimensions,
  TextInput,
} from 'react-native';
import { QueryClient, QueryClientProvider, useQuery } from 'react-query';
import axios from 'axios';
import { environment } from './environment';
import * as React from 'react';
import { GooglePlacesAutocomplete } from 'react-native-google-places-autocomplete';
import { GooglePlacesInput } from './src/Components/Map/GooglePlacesInput';
// import {apiKey} from './config'; // your google cloud api key
// import {Input} from '@rneui/themed';



export default function App() {
  const [users, setUsers] = useState([]);
  const [geoLocation, setGeoLocation] = useState([]);

  const getData = async () => {
    // const res = await axios.get(environment.apiUrl + 'api/Account/Select');
    const res = await fetch(environment.apiUrl + 'api/Account/Select');

    setUsers(await res.json());
  };

  const [text, onChangeText] = React.useState('text');

  return (
  //     <Button onPress={getData} title='Learn More'></Button>
  //     <View>
  //       {users.map((user: any) => (
  //         <Text key={user.name}>{user.name} {user.email}</Text>
  //       ))}
  //     </View>
    <QueryClientProvider client={new QueryClient}>
      <View style={styles.container}>
        <TextInput style={{flex:.5}} onChangeText={onChangeText} value={text}/>
        <GooglePlacesInput inputText='zxc' minLength={4}/>
        <GooglePlacesInput inputText='asd' minLength={4}/>
        <StatusBar style='auto' />
      </View>
    </QueryClientProvider>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    paddingTop: '20%',
    backgroundColor: 'gray',
    // alignItems: "center",
    // justifyContent: 'center',
  },
  textInputContainer: {
    flexDirection: 'row',
  },
  textInput: {
    backgroundColor: '#FFFFFF',
    height: 44,
    borderRadius: 5,
    paddingVertical: 5,
    paddingHorizontal: 10,
    fontSize: 15,
    flex: 1,
  },
  poweredContainer: {
    justifyContent: 'flex-end',
    alignItems: 'center',
    borderBottomRightRadius: 5,
    borderBottomLeftRadius: 5,
    borderColor: '#c8c7cc',
    borderTopWidth: 0.5,
  },
  powered: {},
  listView: {},
  row: {
    backgroundColor: '#FFFFFF',
    padding: 13,
    height: 44,
    flexDirection: 'row',
  },
  separator: {
    height: 0.5,
    backgroundColor: '#c8c7cc',
  },
  description: {},
  loader: {
    flexDirection: 'row',
    justifyContent: 'flex-end',
    height: 20,
  },
});