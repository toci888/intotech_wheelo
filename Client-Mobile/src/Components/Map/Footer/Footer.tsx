import React from 'react';
import { View, Text, StyleSheet } from 'react-native';

export const Footer = () => {

  return (
    <View style={styles.container}>
        <Text>Pic1</Text>
        <Text>Pic2</Text>
        <Text>Pic3</Text>
    </View>
  );
}

const styles = StyleSheet.create({
    container: { },
});