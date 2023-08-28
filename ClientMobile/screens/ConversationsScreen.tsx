import React, { useState } from "react";
import {
  ActivityIndicator,
  // FlatList,
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
import { socket } from "../constants/socket";
import { FlatList } from "react-native-bidirectional-infinite-scroll";
import { SafeAreaView } from "react-native-safe-area-context";

export const ConversationsScreen = () => {
  const { user } = useUser();
  const conversations = useConversationsQuery();
  const { navigate } = useNavigation();
  const { colors } = useTheme();
  const navigation = useNavigation();
  const [refreshingSwipeUp, setRefreshingSwipeUp] = useState(false);
  const [refreshingSwipeDown, setRefreshingSwipeDown] = useState(false);

  console.log("conversations: ", conversations);
  // navigation.getParent()?.setOptions({ tabBarStyle: { display: "none" } });
  // if (!user) return <SignUpOrSignInScreen />;

  if (conversations.isLoading) return <Loading />;

  if (!conversations?.data || conversations.data.length === 0) {
    return <Text>{i18n.t("YouHaveNoMessages")}</Text>;
  }
  const swipeUp = async () => {
    setRefreshingSwipeUp(true);
    console.log("swipeUp");
    setTimeout(() => {
      setRefreshingSwipeUp(false);
    }, 2000);
  };
  const swipeDown = async () => {
    setRefreshingSwipeDown(true);
    console.log("swipeDown");
    setTimeout(() => {
    setRefreshingSwipeDown(false);
    }, 5000);
  };

  const handleMessagePress = async (roomId: string, recipientName: string) => {
    await socket.invoke("JoinRoom", roomId);
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
    <SafeAreaView>
      {refreshingSwipeUp ? <ActivityIndicator /> : null}
      <FlatList
        // showsVerticalScrollIndicator={true}
        data={conversations.data}
        keyExtractor={(item) => item.idRoom.toString()}
        showDefaultLoadingIndicators={true} // optional
        // onStartReachedThreshold={10} // optional
        // onEndReachedThreshold={10} // optional
        // inverted
        // refreshControl={
        //   <RefreshControl
        //     refreshing={refreshing}
        //     onRefresh={() => console.log("pull-to-refresh")}
        //   />
        // }
        onEndReached={swipeUp}
        onStartReached={swipeDown}
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
      {refreshingSwipeDown ? <ActivityIndicator /> : null}
    </SafeAreaView>
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
