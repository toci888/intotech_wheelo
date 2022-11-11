import React from 'react';
import { Dimensions, StyleSheet, View } from 'react-native';

import MapView, { Marker } from 'react-native-maps';

export const GooglePlacesInput = () => {
  return (
    <View style={styles.textInputContainer}>
      <MapView initialRegion={region} style={styles.map} />
    </View>
  );
};

const region = {
  latitude: 137.78825,
  longitude: -122.4324,
  latitudeDelta: 0.0922,
  longitudeDelta: 0.0421,
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
  map: {
    width: Dimensions.get('window').width,
    height: Dimensions.get('window').height,
  },
});
