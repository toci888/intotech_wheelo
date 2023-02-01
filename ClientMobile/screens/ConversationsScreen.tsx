import React from "react";
import { FlatList, Pressable, StyleSheet } from "react-native";
import { Text } from "@ui-kitten/components";
import { useNavigation } from "@react-navigation/native";

import { useConversationsQuery } from "../hooks/queries/useConversationsQuery";
import { Loading } from "../components/Loading";
import { useUser } from "../hooks/useUser";
import { SignUpOrSignInScreen } from "./SignUpOrSignInScreen";
import { theme } from "../theme";
import { Row } from "../components/Row";
import { i18n } from "../i18n/i18n";
import useTheme from "../hooks/useTheme";
import { socket } from "../constants/socket";

export const ConversationsScreen = () => {
  const { user } = useUser();
  const conversations = useConversationsQuery();
  const { navigate } = useNavigation();
  const { colors } = useTheme();

  if (!user) return <SignUpOrSignInScreen />;

  if (conversations.isLoading) return <Loading />;

  if (!conversations?.data || conversations.data.length === 0) {
    return <Text>{i18n.t('YouHaveNoMessages')}</Text>;
  }

  const handleMessagePress = async (conversationID: number, recipientName: string ) => {
    await socket.invoke("JoinRoom", conversationID);
    console.log("Message Pressed", conversationID, recipientName)
    navigate("Chat", {
      screen: "Messages",
      params: {
          conversationID,
          recipientName,
      },
    });
  }

  return (
    <FlatList
      showsVerticalScrollIndicator={true}
      data={conversations.data}
      keyExtractor={(item) => item.id.toString()}
      renderItem={({ item }) => (
        <Pressable
          style={styles.message}
          onPress={() => handleMessagePress(item.id, item.recipientName)}
        >
          <Row style={styles.row}>
            <Text style={[styles.messageTitle, {color: colors.text}]} numberOfLines={1}>
              {item.recipientName} RoomId:{item.id}
            </Text>
            <Text appearance="hint">
              {new Date(item.messages[0].createdAt).toLocaleDateString()}
            </Text>
          </Row>
          <Text numberOfLines={2} appearance="hint" style={styles.messageText}>
            {item.messages[0].text}
          </Text>
        </Pressable>
      )}
    />
  );
};

const styles = StyleSheet.create({
  message: {
    justifyContent: "center",
    height: 100,
    paddingHorizontal: 30,
    borderBottomColor: theme["color-light-gray"],
    borderBottomWidth: 1,
    // backgroundColor: "white",
  },
  messageTitle: { fontWeight: "bold", width: "80%" },
  row: { justifyContent: "space-between" },
  messageText: { paddingTop: 10 },
});
