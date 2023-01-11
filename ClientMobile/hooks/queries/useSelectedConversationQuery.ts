import axios from "axios";
import { useQuery } from "react-query";
import { MessageType } from "@flyerhq/react-native-chat-ui";

import { endpoints, queryKeys } from "../../constants/constants";
import { Message } from "../../types/message";
import { useUser } from "../useUser";
import { Author, SelectedConversation } from "../../types/conversation";

const fetchConversation = async (
  conversationID: number,
  userID?: number,
  token?: string
): Promise<SelectedConversation> => {
  console.log("CzatKlik", `${endpoints.getConversationByID}/get-conversation-by-id?roomId=${conversationID}`, token)
  const response = await axios.get(
    `${endpoints.getConversationByID}/get-conversation-by-id?roomId=${conversationID}`,
    {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    }
  ); 
  console.log("XXZXZC", response.data)

  const data: ConversationRes = response.data;

  const tenantAuthor: Author = {
    id: data.tenantID.toString(),
    firstName: data.messages[0].authorFirstName ? data.messages[0].authorFirstName : data.tenantEmail,
    lastName: data.messages[0].authorFirstName && data.messages[0].authorLastName ? data.messages[0].authorLastName : "",
  };

  const ownerAuthor: Author = {
    id: data.ownerID.toString(),
    firstName: data.ownerFirstName ? data.ownerFirstName : "",
    lastName:  data.ownerLastName ? data.ownerLastName : "",
  };

  const messages: MessageType.Any[] = [];
  for (let m of data.messages) {
    const message: MessageType.Any = {
      id: m.id.toString(),
      author: m.senderID.toString() === ownerAuthor.id ? ownerAuthor : tenantAuthor,
      createdAt: new Date(m.createdAt).getTime(),
      text: m.text,
      type: "text",
    };
    messages.push(message);
  }

  const conversation: SelectedConversation = {
    id: data.id,
    receiverID: userID === data.ownerID ? data.tenantID : data.ownerID,
    messages,
    author: userID === data.ownerID ? ownerAuthor : tenantAuthor,
  };

  return conversation;
};

export const useSelectedConversationQuery = (conversationID: number) => {
  const { user } = useUser();

  return useQuery(queryKeys.selectedConversation, () =>
    fetchConversation(conversationID, user?.id, user?.accessToken)
  );
};

type ConversationRes = {
  id: number;
  CreatedAt: string;
  ownerID: number;
  ownerFirstName: string;
  ownerLastName: string;
  ownerEmail: string;
  tenantID: number;
  tenantFirstName?: string;
  tenantLastName?: string;
  tenantEmail: string;
  messages: Message[];
};
