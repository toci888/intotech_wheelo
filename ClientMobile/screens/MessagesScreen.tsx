import React from "react";
import { StyleSheet, View, Text, Platform } from "react-native";
import { Chat, MessageType, defaultTheme, User, darkTheme } from "@flyerhq/react-native-chat-ui";
import { DarkTheme, DefaultTheme, useNavigation } from "@react-navigation/native";
import { useActionSheet } from '@expo/react-native-action-sheet'
import DocumentPicker from 'react-native-document-picker'
import { launchImageLibrary } from 'react-native-image-picker'
import FileViewer from 'react-native-file-viewer'
import { PreviewData } from '@flyerhq/react-native-link-preview'

import { useUser } from "../hooks/useUser";
import { mapStandardStyle, theme } from "../theme";
import { useSelectedConversationQuery } from "../hooks/queries/useSelectedConversationQuery";
import { Loading } from "../components/Loading";
import { useCreateMessageMutation } from "../hooks/mutations/useCreateMessageMutation";
import { i18n } from "../i18n/i18n";
import useColorScheme from "../hooks/useColorScheme";
import { themes } from "../constants/constants";
// import { ModalHeader } from "../components/ModalHeader";

export const MessagesScreen = ({
  route,
}: {
  route: { params: { roomId: number; recipientName: string } };
}) => {
  const { showActionSheetWithOptions } = useActionSheet()

  const title = route.params.recipientName.includes("%20")
    ? route.params.recipientName.replaceAll("%20", " ")
    : route.params.recipientName.includes("%")
      ? route.params.recipientName.replaceAll("%", " ")
      : route.params.recipientName;
  const navigation = useNavigation();
  // navigation.getParent()?.setOptions({ tabBarStyle: { display: "none" } });
  // navigation.setOptions({ tabBarStyle: { display: "none" } });
  const { user } = useUser();
  console.log("ConversationID", route.params)
  const colorScheme = useColorScheme();
  const conversation = useSelectedConversationQuery(route.params.roomId);
  const createMessage = useCreateMessageMutation();
  // const [messages, setMessages] = useState({} as any)

  // if (!user) return <SignUpOrSignInScreen />;
  if (conversation.isLoading) return <Loading />;

  if (!conversation.data) return <><Text>{i18n.t('UnableToGetChat')}</Text></>;

  const handleSendPress = (message: MessageType.PartialText) => {
    console.log("MESSAGExx", message)
    if (conversation)
      createMessage.mutate({
        idAccount: user!.id,
        author: conversation.data.author,
        roomId: conversation.data.id,
        receiverID: conversation.data.id,
        senderEmail: user!.email,
        text: message.text,
        authorFirstName: conversation.data.messages[0].author.firstName ? conversation.data.messages[0].author.firstName : "",
        authorLastName: conversation.data.messages[0].author.lastName ? conversation.data.messages[0].author.lastName : "",
        imageUrl: conversation.data.messages[0].author.imageUrl ? conversation.data.messages[0].author.imageUrl : ""
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
    } catch { }
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
        console.log("HEREE", buttonIndex)
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
    console.log("CLICK1 handleAttachmentPress")
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

  const handlePreviewDataFetched = ({
    message,
    previewData,
  }: {
    message: MessageType.Text
    previewData: PreviewData
  }) => {
    console.log("handlePreviewDataFetched??")
    conversation.data.messages = conversation.data.messages.map<MessageType.Any>((m) =>
      m.id === message.id ? { ...m, previewData } : m
    )
  }

  const handleMessagePress = async (message: MessageType.Any) => {
    console.log("KLIK MEsSAGE", message)
    if (message.type === 'file') {
      console.log("NO LECE file")
      try {
        // await FileViewer.open(message.uri, { showOpenWithDialog: true })
      } catch { }
    }
  }

  return (
    <>
    {/* <ModalHeader text="a" xShown onPress={() => {navigation.getParent()?.setOptions({ tabBarStyle: { display: "display" } }); navigation.goBack()}}/> */}
    <Chat
      messages={conversation.data.messages}
      onSendPress={handleSendPress}
      user={conversation.data.author as User}
      onAttachmentPress={handleAttachmentPress}
      onMessagePress={handleMessagePress}
      onPreviewDataFetched={handlePreviewDataFetched}
      sendButtonVisibilityMode="always"
      enableAnimation
      showUserNames
      showUserAvatars
      l10nOverride={{ inputPlaceholder: i18n.t('TypeAMessage') }}
      // locale='en'
      inputProps={{}}
      textInputProps={{
        style: styles.textInputProps,
      }}
      theme={colorScheme === themes.dark ? {
        ...darkTheme,
        colors: {
          ...darkTheme.colors,
        }
      } : {
        ...defaultTheme,
        colors: {
          ...defaultTheme.colors,
          primary: theme["color-primary-500"],
          secondary: theme["color-light-gray"],
          inputText: "black",
          inputBackground: "white" //TODO
        }
      }
      }
    />
    </>
  );
};

const styles = StyleSheet.create({
  textInputProps: {
    borderBottomColor: theme["color-gray"],
    borderBottomWidth: 1,
    paddingBottom: 10,
  },
});
