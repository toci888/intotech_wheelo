import React from 'react';
import {
  GooglePlaceData,
  GooglePlacesAutocomplete,
} from 'react-native-google-places-autocomplete';
import { StyleSheet, Text, View } from 'react-native';
import { GeogLocDataParser } from './public/bll/geoglocparser';
import { GeogLocModel } from './public/models/geoglocmodel';

async function GetLatitudeLongitude(data: GooglePlaceData) {
  const res = await fetch(
    'https://maps.googleapis.com/maps/api/place/details/json?place_id=' +
      data.place_id +
      '&key=AIzaSyDxVQqaiKE1L6N9Etv9SUgKsEHfPr9Et40'
  );
  const resJson = await res.json();

  const model: GeogLocModel = new GeogLocDataParser().ParseGeogLocResult(resJson);
}

export const GooglePlacesInput = () => {
  return (
    <View style={styles.textInputContainer}>
      <Text>Hello</Text>
      <GooglePlacesAutocomplete
        placeholder="Type address here"
        onPress={(data, details = null) => {
          GetLatitudeLongitude(data);
        }}
        query={{
          key: 'AIzaSyDxVQqaiKE1L6N9Etv9SUgKsEHfPr9Et40',
          language: 'en',
        }}
      />
    </View>
  );
};
//https://maps.googleapis.com/maps/api/place/details/json?place_id=ChIJrTLr-GyuEmsRBfy61i59si0&key=AIzaSyDxVQqaiKE1L6N9Etv9SUgKsEHfPr9Et40
//EhxLb3JkZWNraWVnbywgUG96bmHFhCwgUG9sYW5kIi4qLAoUChIJGX5Lii9FBEcRtPGGCAQKaioSFAoSCbcK4ezSRARHEdG_NAOYMeqk
//https://maps.googleapis.com/maps/api/place/details/json?place_id=EhxLb3JkZWNraWVnbywgUG96bmHFhCwgUG9sYW5kIi4qLAoUChIJGX5Lii9FBEcRtPGGCAQKaioSFAoSCbcK4ezSRARHEdG_NAOYMeqk=AIzaSyDxVQqaiKE1L6N9Etv9SUgKsEHfPr9Et40
const styles = StyleSheet.create({
  textInputContainer: {
    backgroundColor: 'grey',
    flex: 1,
  },
  textInput: {
    height: 38,
    color: '#5d5d5d',
    fontSize: 16,
  },
  predefinedPlacesDescription: {
    color: '#1faadb',
  },
});

{
  /* <GooglePlacesAutocomplete
        placeholder="Search"
        onPress={(data, details = null) => {
          // 'details' is provided when fetchDetails = true
          console.log(data, details);
        }}
        query={{
          key: "AIzaSyDxVQqaiKE1L6N9Etv9SUgKsEHfPr9Et40",
          language: "en",
        }}
        requestUrl={{
          useOnPlatform: "web", // or "all"
          url: "https://cors-anywhere.herokuapp.com/https://maps.googleapis.com/maps/api", // or any proxy server that hits https://maps.googleapis.com/maps/api
          headers: {
            Authorization: `an auth token`, // if required for your proxy
          },
        }}
      /> */
}
