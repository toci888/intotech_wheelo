// import React from 'react';
// import { createStackNavigator } from '@react-navigation/stack';
// import { OverlayProvider } from 'stream-chat-expo';
// import { Login } from './GoogleMapsInputsScreen';
// import { ChatStack } from './ChatScreen';

// const Stack = createStackNavigator();

// export const NavigationStack = () => {

//   return (
//     <OverlayProvider>
//       <Stack.Navigator>
//         {/* <Stack.Screen name="Login" component={Login} /> */}
//         <Stack.Screen name="ChatStackK" component={ChatStack} />
//       </Stack.Navigator>
//     </OverlayProvider>
//   );
// };

import React from 'react';
import { createStackNavigator } from '@react-navigation/stack';
import { Text } from 'react-native';
import { useChatClient } from '../Hooks/useChatClient';
import { Chat, OverlayProvider } from 'stream-chat-expo';
import { StreamChat } from 'stream-chat';
import { ChannelListScreen, ChannelScreen, ThreadScreen } from './Chat/ChannelListScreen';
import { CHAT_API_KEY } from '../Constants/constants';
import { ChatStack } from './ChatScreen';

const chatClient = StreamChat.getInstance(CHAT_API_KEY);

const Stack = createStackNavigator();

export const NavigationStack = () => {
  const { clientIsReady } = useChatClient();

  if (!clientIsReady) {
    return <Text>Loading chat ...</Text>
  }

  return (
    <OverlayProvider>
      <Chat client={chatClient}>
        <Stack.Navigator>
          <Stack.Screen name="ChannelListScreen" component={ChannelListScreen} />
          <Stack.Screen name="ChannelScreen" component={ChannelScreen} />
          <Stack.Screen name="ThreadScreen" component={ThreadScreen} />
          <Stack.Screen name="ChatStackK" component={ChatStack} />
        </Stack.Navigator>
      </Chat>
    </OverlayProvider>
  );
};
