import React from 'react';
import { NavigationContainer } from '@react-navigation/native';
import { SafeAreaView } from 'react-native-safe-area-context';
import { GestureHandlerRootView } from 'react-native-gesture-handler';
import { AppProvider } from './src/Hooks/AppContextHook';
import { NavigationStack } from './src/Screens/Navigation';
import { QueryClient, QueryClientProvider } from 'react-query';

export default function App() {

  return (
    <AppProvider>
      <QueryClientProvider client={new QueryClient}>
        <GestureHandlerRootView style={{ flex: 1 }}>
          <SafeAreaView style={{ flex: 1 }}>
            <NavigationContainer>

              <NavigationStack />
              {/* <Footer /> */}
            </NavigationContainer>
          </SafeAreaView>
        </GestureHandlerRootView>
      </QueryClientProvider>
    </AppProvider>
  );
};
