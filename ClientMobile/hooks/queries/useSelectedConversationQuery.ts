import axios from "axios";
import { useQuery } from "react-query";
import { MessageType } from "@flyerhq/react-native-chat-ui";

import { endpoints, queryKeys } from "../../constants/constants";
import { Message } from "../../types/message";
import { useUser } from "../useUser";
import { Author, SelectedConversation } from "../../types/conversation";

const fetchConversation = async (
  roomId: string,
  userID?: number,
  token?: string
): Promise<SelectedConversation> => {
  console.log("Wybranie czatu", `${endpoints.getConversationByID}?roomId=${roomId}`)
  const response = await axios.get(`${endpoints.getConversationByID}?roomId=${roomId}`,
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
      createdAt: new Date(m.createdAt).getDate(),
      author: data.roomParticipants.find(x => Number(x.id) === m.idAccount) as Author
    }

    if(message.author != null) {
      messages.push(message);
    }
  };

  let authorsMessage = data.roomParticipants.find((author: Author) => Number(author.id) === userID)
  
  const conversation: SelectedConversation = {
    idRoom: data.idRoom,
    roomParticipants: data.roomParticipants,
    roomId: data.roomId,
    messages,
    author: authorsMessage as Author
  };
  
  return conversation;
};

export const useSelectedConversationQuery = (roomId: string) => {
  const { user } = useUser();

  return useQuery(queryKeys.selectedConversation, () =>
    fetchConversation(roomId, user?.id, user?.accessToken)
  );
};

type ConversationRes = {
  idRoom: number;
  roomId: string;
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
  roomParticipants: Author[];
};
