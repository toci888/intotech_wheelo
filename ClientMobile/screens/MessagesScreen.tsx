import React from "react";
import { StyleSheet, View, Text } from "react-native";
import { Chat, MessageType, defaultTheme } from "@flyerhq/react-native-chat-ui";
import { useNavigation } from "@react-navigation/native";

import { useUser } from "../hooks/useUser";
import { SignUpOrSignInScreen } from "./SignUpOrSignInScreen";
import { theme } from "../theme";
import { useSelectedConversationQuery } from "../hooks/queries/useSelectedConversationQuery";
import { Loading } from "../components/Loading";
import { useCreateMessageMutation } from "../hooks/mutations/useCreateMessageMutation";
import { i18n } from "../i18n/i18n";

export const MessagesScreen = ({
  route,
}: {
  route: { params: { conversationID: number; recipientName: string } };
}) => {
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
  console.log("CONVID", route.params)
  const conversation = useSelectedConversationQuery(route.params.conversationID);
  const createMessage = useCreateMessageMutation();

  if (!user) return <SignUpOrSignInScreen />;
  if (conversation.isLoading) return <Loading />;

  if (!conversation.data) return <><Text>{i18n.t('UnableToGetChat')}</Text></>;
  console.log("WSzYSTMESSA", conversation)
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

  return (
    <Chat
      messages={conversation.data.messages}
      onSendPress={handleSendPress}
      user={conversation.data.author}
      sendButtonVisibilityMode="always"
      // enableAnimation
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
