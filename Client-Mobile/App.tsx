import React from 'react';
import { NavigationContainer } from '@react-navigation/native';
import { SafeAreaView } from 'react-native-safe-area-context';
import { Text } from 'react-native';
import { GestureHandlerRootView } from 'react-native-gesture-handler';
import { NavigationStack } from './src/Screens/NavigationStack';
import { AppProvider } from './src/Hooks/AppContextHook';

export default () => {
  return (
    <AppProvider>
      <GestureHandlerRootView style={{ flex: 1 }}>
        <SafeAreaView style={{ flex: 1 }}>
          <NavigationContainer>
            <NavigationStack />
          </NavigationContainer>
        </SafeAreaView>
      </GestureHandlerRootView>
    </AppProvider>
  );
};

// const root = ReactDOM.createRoot(document.getElementById("root") as HTMLElement);
// root.render(
//   <React.StrictMode>
//     <App />
//   </React.StrictMode>
// );