import React from 'react';
import { Channel, ChannelList, MessageList, MessageInput, Thread } from 'stream-chat-expo';
import { chatUserId } from '../../Models/ChatUser';
import { useAppContext } from '../../Hooks/AppContextHook';

const filters = {
  members: {
    '$in': [chatUserId]
  },
};

const sort = {
  last_message_at: -1,
};

export const ThreadScreen = (props: any) => {
  const { channel, thread } = useAppContext();

  return (
    <Channel channel={channel} thread={message} threadList>
      <Thread />
    </Channel>
  );
}

export const ChannelListScreen = (props: any) => {
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

export const ChannelScreen = (props: any) => {

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
