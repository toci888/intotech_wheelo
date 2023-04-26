import React, { useState } from "react";
import {
  ActivityIndicator,
  FlatList,
  Pressable,
  RefreshControl,
  StyleSheet,
  View,
} from "react-native";
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
import { joinRoom } from "../constants/socket";

export const ConversationsScreen = () => {
  const { user } = useUser();
  const conversations = useConversationsQuery();
  const { navigate } = useNavigation();
  const { colors } = useTheme();
  const navigation = useNavigation();
  const [refreshing, setRefreshing] = useState(false);

  // navigation.getParent()?.setOptions({ tabBarStyle: { display: "none" } });
  if (!user) return <SignUpOrSignInScreen />;

  if (conversations.isLoading) return <Loading />;

  if (!conversations?.data || conversations.data.length === 0) {
    return <Text>Brak wiadomosci stare TODO!</Text>;
  }

  const handleMessagePress = async (roomId: string, recipientName: string) => {
    await joinRoom(roomId);
    console.log("Message Pressed", roomId, recipientName);
    // navigation.getParent()?.setOptions({ tabBarStyle: { display: "none" } });
    navigate("Chat", {
      screen: "Messages",
      params: {
        roomId,
        recipientName,
      },
    });
  };

  return (
    <View>
      {refreshing ? <ActivityIndicator /> : null}
      <FlatList
        showsVerticalScrollIndicator={true}
        data={conversations.data}
        keyExtractor={(item) => item.idRoom.toString()}
        refreshControl={
          <RefreshControl
            refreshing={refreshing}
            onRefresh={() => {conversations.refetch();}}
          />
        }
        ListEmptyComponent={<Text>{i18n.t("YouHaveNoMessages")}</Text>}
        renderItem={({ item }) => (
          <Pressable
            style={styles.message}
            onPress={() => handleMessagePress(item.roomId, item.recipientName)}
          >
            <Row style={styles.row}>
              <Text
                style={[styles.messageTitle, { color: colors.text }]}
                numberOfLines={1}
              >
                {item.recipientName} RoomId:{item.idRoom}
              </Text>
              <Text appearance="hint">
                {item.messages[0].createdAt?.toString().split("T")[0]}
              </Text>
            </Row>
            <Text
              numberOfLines={2}
              appearance="hint"
              style={styles.messageText}
            >
              {item.messages[0].text}
            </Text>
          </Pressable>
        )}
      />
    </View>
  );
};

const styles = StyleSheet.create({
  message: {
    justifyContent: "center",
    height: 100,
    paddingHorizontal: 30,
    borderBottomColor: theme["color-light-gray"],
    borderBottomWidth: 1,
  },
  messageTitle: { fontWeight: "bold", width: "80%" },
  row: { justifyContent: "space-between" },
  messageText: { paddingTop: 10 },
});
