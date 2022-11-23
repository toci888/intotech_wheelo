import React from 'react';
import { NavigationContainer } from '@react-navigation/native';
import { createStackNavigator } from '@react-navigation/stack';
import { SafeAreaView } from 'react-native-safe-area-context';
import { Text } from 'react-native';
import { useChatClient } from '../Hooks/useChatClient';
import { AppProvider } from "../Hooks/AppContextHook";
import {
  Chat, OverlayProvider, Channel,
  ChannelList, MessageList, MessageInput,
  Thread
} from 'stream-chat-expo'; // Or stream-chat-react-native'; 
import { StreamChat } from 'stream-chat';
import { chatApiKey, chatUserId } from '../Models/ChatUser';
import { useAppContext } from '../Hooks/AppContextHook';
import { GestureHandlerRootView } from 'react-native-gesture-handler';

const ThreadScreen = props => {
  const { channel, thread } = useAppContext();

  return (
    <Channel channel={channel} thread={message} threadList>
      <Thread />
    </Channel>
  );
}

const Stack = createStackNavigator();

const filters = {
  members: {
    '$in': [chatUserId]
  },
};

const sort = {
  last_message_at: -1,
};
// https://dashboard.getstream.io/organization/1152815/apps
// https://dashboard.getstream.io/app/1220901/chat/explorer?path=channels,channel~messaging:testChannel2,members,member~testUser2
// https://getstream.io/chat/react-native-chat/tutorial/#add-stream-chat-to-the-application -> configure channel component

const ChannelListScreen = props => {
  const { setChannel } = useAppContext();

  return (
    <ChannelList
      onSelect={(channel) => {
        const { navigation } = props;
        setChannel(channel);
        navigation.navigate('ChannelScreen');
      }}
      filters={filters}
      sort={sort}
    />);
}

const ChannelScreen = props => {

  const { channel, setThread } = useAppContext();

  return (
    <Channel channel={channel}>
      <MessageList
        onThreadSelect={(message) => {
          if (channel?.id) {
            setThread(message);
            navigation.navigate('ThreadScreen');
          }
        }}
      />
      <MessageInput />
    </Channel>
  );
}

const chatClient = StreamChat.getInstance(chatApiKey);

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
        </Stack.Navigator>
      </Chat>
    </OverlayProvider>
  );
};
