import React from 'react';
import { createStackNavigator } from '@react-navigation/stack';
import { Text } from 'react-native';
import { useChatClient } from '../Hooks/useChatClient';
import { Chat, OverlayProvider } from 'stream-chat-expo';
import { StreamChat } from 'stream-chat';
import { ChannelListScreen, ChannelScreen, ThreadScreen } from './Chat/ChannelListScreen';
import { CHAT_API_KEY } from '../Constants/constants';

const chatClient = StreamChat.getInstance(CHAT_API_KEY);

const Stack = createStackNavigator();

export const ChatScreen = () => {
  console.log("XXX", CHAT_API_KEY);
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
      </Stack.Navigator>
    </Chat>
    </OverlayProvider>
  );
};