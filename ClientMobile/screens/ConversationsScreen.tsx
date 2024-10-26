import React, { useState, useCallback } from "react";
import {
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
import { i18n } from "../i18n/i18n";
import useTheme from "../hooks/useTheme";
import { socket } from "../constants/socket";
import { Row } from "../components/Row";

export const ConversationsScreen = () => {
  const { user } = useUser();
  const conversations = useConversationsQuery();
  const { navigate } = useNavigation();
  const { colors } = useTheme();
  const [refreshing, setRefreshing] = useState(false);

  const onRefresh = useCallback(async () => {
    setRefreshing(true);
    await conversations.refetch();
    setRefreshing(false);
  }, [conversations]);

  const handleMessagePress = async (roomId: string, recipientName: string) => {
    await socket.invoke("JoinRoom", roomId);
    navigate("Chat", {
      screen: "Messages",
      params: {
        roomId,
        recipientName,
      },
    });
  };

  if (conversations.isLoading) return <Loading />;

  if (!conversations?.data || conversations.data.length === 0) {
    return <Text>{i18n.t("YouHaveNoMessages")}</Text>;
  }

  return (
    <View style={styles.container}>
      <FlatList
        showsVerticalScrollIndicator={true}
        data={conversations.data}
        keyExtractor={(item) => item.idRoom.toString()}
        refreshControl={
          <RefreshControl refreshing={refreshing} onRefresh={onRefresh} />
        }
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
                {new Date(item.messages[0].createdAt).toLocaleDateString()}
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
  container: {
    flex: 1,
  },
  message: {
    justifyContent: "center",
    height: 100,
    paddingHorizontal: 30,
    borderBottomColor: theme["color-light-gray"],
    borderBottomWidth: 1,
  },
  messageTitle: {
    fontWeight: "bold",
    width: "80%",
  },
  row: {
    justifyContent: "space-between",
  },
  messageText: {
    paddingTop: 10,
  },
});
