import axios from "axios";
import { useQuery } from "react-query";
import { MessageType, User } from "@flyerhq/react-native-chat-ui";

import { endpoints, queryKeys } from "../../constants/constants";
import { Message } from "../../types/message";
import { useUser } from "../useUser";
import { Author, SelectedConversation } from "../../types/conversation";

const fetchConversation = async (
  conversationID: number,
  userID?: number,
  token?: string
): Promise<SelectedConversation> => {
  console.log("CzatKlik", `${endpoints.getConversationByID}?roomId=${conversationID}`, token)
  const response = await axios.get(`${endpoints.getConversationByID}?roomId=${conversationID}`,
    {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    }
  ); 
  const data: ConversationRes = response.data;

  const messages: MessageType.Any[] = [];
  for (let m of data.messages) {
    const message: MessageType.Any = {
      id: m.id.toString(),
      type: "text",
      text: m.text,
      createdAt: new Date(m.createdAt).getTime(),
      author: {
        id: m.senderEmail.toString(),
        firstName: m.authorFirstName, 
        lastName: m.authorLastName,
        imageUrl: m.imageUrl
      } as User
    }
    messages.push(message);
  };
  
  const convAuthor = data.messages.map((auth: Message) => {
    if(auth.idAccount === userID) {
      return {
        id: auth.senderEmail,
        firstName: auth.authorFirstName, 
        lastName: auth.authorLastName,
        imageUrl: auth.imageUrl
      } as Author;
    }
  })
  const conversation: SelectedConversation = {
    id: data.id,
    receiverID: convAuthor[0] ? convAuthor[0].senderEmail : "",
    messages,
    author: convAuthor[0] as Author
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
  idAccount: number;
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
