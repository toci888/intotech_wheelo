import React, { FC } from 'react';
import { GooglePlacesAutocomplete } from 'react-native-google-places-autocomplete';
import { StyleSheet, View } from 'react-native';
import { createCoordinates } from '../../Models/Coordinates';
import { GOOGLE_MAPS_API_KEY } from '../../Constants/constants';
import { createAddress } from '../../Models/Address';
import { createGeographicLocationModel } from '../../Models/GeographicLocationModel';

type TGoogleInput = {
  inputText: string;
  minLength: number;
}

export const GooglePlacesInput: FC<TGoogleInput> = ({inputText, minLength}) => {
  return (
    <View style={styles.textInputContainer}>
      <GooglePlacesAutocomplete
        GooglePlacesDetailsQuery={{ fields: 'geometry,address_components' }}
        fetchDetails={true} // you need this to fetch the details object onPress
        placeholder={inputText}
        minLength={minLength}
        query={{
          key: GOOGLE_MAPS_API_KEY,
          language: 'pl',
        }}
        // currentLocationLabel="Your location!" TODO
        // currentLocation={true}
        onNotFound={() => console.log('no results')}
        onPress={(data: any, details: any = null) => {
          const coordinates = createCoordinates(details.geometry.location.lat, details.geometry.location.lng);
          const address = createAddress(details);
          if (coordinates.type === 'Success') {
            const geographicLocation = createGeographicLocationModel(coordinates.coordinates, address);
            console.log('geographicLocation', geographicLocation);
          } else {
            return Error('Podane wartości są niepoprawne.');
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
