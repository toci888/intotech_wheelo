import React from 'react';
import { createStackNavigator } from '@react-navigation/stack';
import { OverlayProvider } from 'stream-chat-expo'; // Or stream-chat-react-native'; 
import { ChatScreen } from './ChatScreen';

const Stack = createStackNavigator();

export const NavigationStack = () => {

  return (
    <OverlayProvider>
      <Stack.Navigator>
        <Stack.Screen name="ChatScreen" component={ChatScreen} />
      </Stack.Navigator>
    </OverlayProvider>
  );
};
