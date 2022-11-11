import { StatusBar } from 'expo-status-bar';
import { useState } from 'react';
import {
  StyleSheet,
  Text,
  View,
  Button,
  SafeAreaView,
  Dimensions,
} from 'react-native';
import { QueryClient, QueryClientProvider, useQuery } from 'react-query';
import axios from 'axios';
import { environment } from './environment';
import MapView, { Marker } from 'react-native-maps';
import * as React from 'react';
import { GooglePlacesAutocomplete } from 'react-native-google-places-autocomplete';
import { GooglePlacesInput } from './GooglePlacesInput';
// import {apiKey} from './config'; // your google cloud api key
// import {Input} from '@rneui/themed';

const queryClient = new QueryClient();

export default function App() {
  const [users, setUsers] = useState([]);
  const [geoLocation, setGeoLocation] = useState([]);

  const getData = async () => {
    // const res = await axios.get(environment.apiUrl + 'api/Account/Select');
    const res = await fetch(environment.apiUrl + 'api/Account/Select');

    setUsers(await res.json());
  };

  return (
    // <View style={styles.container}>
    //   <Text>Open up App.tsx to start working on your app!</Text>
    //   <QueryClientProvider client={queryClient}>
    //     <Button onPress={getData} title='Learn More'></Button>
    //     <View>
    //       {users.map((user: any) => (
    //         <Text key={user.name}>{user.name} {user.email}</Text>
    //       ))}
    //     </View>
    //   </QueryClientProvider>
    //   <StatusBar style='auto' />
    // </View>
    // <SafeAreaView>
    //   <GooglePlacesAutocomplete
    //     placeholder="Type a place"
    //     onPress={(data, details = null) => console.log(data, details)}
    //     query={{key: 'AIzaSyDxVQqaiKE1L6N9Etv9SUgKsEHfPr9Et40'}}
    //     fetchDetails={true}
    //     onFail={error => console.log(error)}
    //     onNotFound={() => console.log('no results')}
    //     currentLocation={true}
    //     currentLocationLabel="Your location!" // add a simple label
    //   />
    // </SafeAreaView>
    <View style={styles.container}>
      {/* <MapView
        initialRegion={region}
        style={styles.map}
      /> */}
      <GooglePlacesInput />
    </View>
  );
}

const region = {
  latitude: 137.78825,
  longitude: -122.4324,
  latitudeDelta: 0.0922,
  longitudeDelta: 0.0421,
};

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
  map: {
    width: Dimensions.get('window').width,
    height: Dimensions.get('window').height,
  },
});

// import * as React from 'react';
// import MapView from 'react-native-maps';
// import { StyleSheet, Text, View, Dimensions } from 'react-native';

// export default function App() {
//   return (
//     <View style={styles.container}>
//       <MapView style={styles.map} />
//     </View>
//   );
// }
