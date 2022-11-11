import React from 'react';
import {
  GooglePlaceData,
  GooglePlacesAutocomplete,
} from 'react-native-google-places-autocomplete';
import { StyleSheet, Text, View } from 'react-native';
import { GeogLocDataParser } from './public/bll/geoglocparser';
import { GeogLocModel } from './public/models/geogLocalizationModel';
import { Coordinates, createCoordinates } from './public/models/coordinates';
import { GOOGLE_MAPS_API_KEY } from './constants/constants';

async function GetLatitudeLongitude(data: GooglePlaceData, coordinates: Coordinates) {

  const res = await fetch("https://maps.googleapis.com/maps/api/place/details/json?place_id=" + data.place_id + "&key=" + GOOGLE_MAPS_API_KEY);
    const resJson = await res.json();

console.log("WTF?", resJson);
  const model: GeogLocModel = new GeogLocDataParser().ParseGeogLocResult(resJson, coordinates);

  return model;
}

export const GooglePlacesInput = () => {
  return (
    <View style={styles.textInputContainer}>
      <Text>Hello</Text>
      <GooglePlacesAutocomplete
        GooglePlacesDetailsQuery={{ fields: 'formatted_address,geometry' }}
        fetchDetails={true} // you need this to fetch the details object onPress
        placeholder="Search"
        query={{
          key: GOOGLE_MAPS_API_KEY,
          language: 'pl',
          types: 'geocode'
        }}
        onPress={(data: any, details: any = null) => {

          console.log("details", details);

          const coordinates = createCoordinates(details.geometry.location.lat, details.geometry.location.lng);
          if (coordinates.type === 'Success') {
            console.log(data);
            console.log("detailsHERE", details);
            GetLatitudeLongitude(data, coordinates.coordinates);
          } else {
            return Error('Podane wartości są niepoprawne');
          }

        }}
        onFail={(error) => console.error(error)}
      />
    </View>
  );
};

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
