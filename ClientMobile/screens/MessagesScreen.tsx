import React, { useState } from "react";
import { StyleSheet, View, Text } from "react-native";
import { Chat, MessageType, defaultTheme } from "@flyerhq/react-native-chat-ui";
import { useNavigation } from "@react-navigation/native";
import { useActionSheet } from '@expo/react-native-action-sheet'
import DocumentPicker from 'react-native-document-picker'
import { launchImageLibrary } from 'react-native-image-picker'

import { useUser } from "../hooks/useUser";
import { SignUpOrSignInScreen } from "./SignUpOrSignInScreen";
import { theme } from "../theme";
import { useSelectedConversationQuery } from "../hooks/queries/useSelectedConversationQuery";
import { Loading } from "../components/Loading";
import { useCreateMessageMutation } from "../hooks/mutations/useCreateMessageMutation";
import { i18n } from "../i18n/i18n";
import { Message } from "../types/message";

export const MessagesScreen = ({
  route,
}: {
  route: { params: { conversationID: number; recipientName: string } };
}) => {
  const { showActionSheetWithOptions } = useActionSheet()
  
  const title = route.params.recipientName.includes("%20")
    ? route.params.recipientName.replaceAll("%20", " ")
    : route.params.recipientName.includes("%")
    ? route.params.recipientName.replaceAll("%", " ")
    : route.params.recipientName;
  const navigation = useNavigation();
  navigation.setOptions({
    title: title
  });
  const { user } = useUser();
  console.log("ConversationID", route.params)
  const conversation = useSelectedConversationQuery(route.params.conversationID);
  const createMessage = useCreateMessageMutation();
  // const [messages, setMessages] = useState({} as any)

  if (!user) return <SignUpOrSignInScreen />;
  if (conversation.isLoading) return <Loading />;

  if (!conversation.data) return <><Text>{i18n.t('UnableToGetChat')}</Text></>;
  
  const handleSendPress = (message: MessageType.PartialText) => {
    if (conversation)
      createMessage.mutate({
        author: conversation.data.author,
        conversationID: conversation.data.id,
        receiverID: conversation.data.receiverID,
        senderID: user.email,
        text: message.text,
        authorFirstName: conversation.data.messages[0].author.firstName ? conversation.data.messages[0].author.firstName : "",
        authorLastName: conversation.data.messages[0].author.lastName ? conversation.data.messages[0].author.lastName : ""
      });
  };

  const handleFileSelection = async () => {
    try {
      const response = await DocumentPicker.pickSingle({
        type: [DocumentPicker.types.allFiles],
      })
      const fileMessage: MessageType.File = {
        author: conversation.data.author,
        createdAt: Date.now(),
        id: conversation.data.id.toString(),
        mimeType: response.type ?? undefined,
        name: response.name as string,
        size: response.size ?? 0,
        type: 'file',
        uri: response.uri,
      }
      addMessage(fileMessage)
    } catch {}
  }

  const addMessage = (message: MessageType.Any) => {
    conversation.data.messages = [message, ...conversation.data.messages]
  }

  const handleAttachmentPress = () => {
    showActionSheetWithOptions(
      {
        options: ['Photo', 'File', 'Cancel'],
        cancelButtonIndex: 2,
      },
      (buttonIndex) => {
        switch (buttonIndex) {
          case 0:
            handleImageSelection()
            break
          case 1:
            handleFileSelection()
            break
        }
      }
    )
  }

  const handleImageSelection = () => {
    launchImageLibrary(
      {
        includeBase64: true,
        maxWidth: 1440,
        mediaType: 'photo',
        quality: 0.7,
      },
      ({ assets }) => {
        const response = assets?.[0]

        if (response?.base64) {
          const imageMessage: MessageType.Image = {
            author: conversation.data.author,
            createdAt: Date.now(),
            height: response.height,
            id: conversation.data.id.toString(),
            name: response.fileName ?? response.uri?.split('/').pop() ?? '🖼',
            size: response.fileSize ?? 0,
            type: 'image',
            uri: `data:image/*;base64,${response.base64}`,
            width: response.width,
          }
          addMessage(imageMessage)
        }
      }
    )
  }

  return (
    <Chat
      messages={conversation.data.messages}
      onSendPress={handleSendPress}
      user={conversation.data.author}
      onAttachmentPress={handleAttachmentPress}
      sendButtonVisibilityMode="always"
      enableAnimation
      textInputProps={{
        style: styles.textInputProps,
      }}
      theme={{
        ...defaultTheme,
        colors: {
          ...defaultTheme.colors,
          primary: theme["color-primary-500"],
          secondary: theme["color-light-gray"],
          inputText: "black",
          inputBackground: "white",
        },
      }}
    />
  );
};

const styles = StyleSheet.create({
  textInputProps: {
    borderBottomColor: theme["color-gray"],
    borderBottomWidth: 1,
    paddingBottom: 10,
  },
});
