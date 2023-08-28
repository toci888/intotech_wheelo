import axios from "axios";
import { useQuery } from "react-query";

import { endpoints, queryKeys } from "../../constants/constants";
import { TransformedConversation } from "../../types/conversation";
import { Message } from "../../types/message";
import { getStateAbbreviation } from "../../utils/getStateAbbreviation";
import { useUser } from "../useUser";

const fetchConversations = async (
  email?: string,
  token?: string
): Promise<TransformedConversation[]> => {
  if (!email) return [];

  // const response = await axios.post(
  //   `${endpoints.getConversationsByUserEmail}`,
  //   {
  //     email
  //   },
  //   {
  //     headers: {
  //       Authorization: `Bearer ${token}`,
  //     },
  //   }
  // );
  // const conversations: ConversationsRes[] = response.data.conversations;
  const conversations: ConversationsRes[] = [{
    idRoom: 1,
    roomId: "Tomek",
    roomName: "Test",
    idAccount: 1,
    CreatedAt: "1",
    tenantID: 1,
    ownerID: 1,
    ownerEmail: "tomek@gmail.com",
    ownerFirstName: "Tomek",
    ownerLastName: "Romek",
    messages: [{
      id: 1,
      idAccount: 1,
      createdAt: 1,
      senderEmail: "tomek@gmail.com",
      roomID: "string",
      text: "string",
      imageUrl: "https://picsum.photos/200",
      authorFirstName: "Tomek",
      authorLastName: "Romek"
    }]
},
{
  idRoom: 2,
  roomId: "Tomek",
  roomName: "Test",
  idAccount: 1,
  CreatedAt: "1",
  tenantID: 1,
  ownerID: 1,
  ownerEmail: "tomek@gmail.com",
  ownerFirstName: "Tomek",
  ownerLastName: "Romek",
  messages: [{
    id: 1,
    idAccount: 1,
    createdAt: 1,
    senderEmail: "tomek@gmail.com",
    roomID: "string",
    text: "string",
    imageUrl: "https://picsum.photos/200",
    authorFirstName: "Tomek",
    authorLastName: "Romek"
  }]
},
{
  idRoom: 3,
  roomId: "Tomek",
  roomName: "Test",
  idAccount: 1,
  CreatedAt: "1",
  tenantID: 1,
  ownerID: 1,
  ownerEmail: "tomek@gmail.com",
  ownerFirstName: "Tomek",
  ownerLastName: "Romek",
  messages: [{
    id: 1,
    idAccount: 1,
    createdAt: 1,
    senderEmail: "tomek@gmail.com",
    roomID: "string",
    text: "string",
    imageUrl: "https://picsum.photos/200",
    authorFirstName: "Tomek",
    authorLastName: "Romek"
  }]
},
{
  idRoom: 4,
  roomId: "Tomek",
  roomName: "Test",
  idAccount: 1,
  CreatedAt: "1",
  tenantID: 1,
  ownerID: 1,
  ownerEmail: "tomek@gmail.com",
  ownerFirstName: "Tomek",
  ownerLastName: "Romek",
  messages: [{
    id: 1,
    idAccount: 1,
    createdAt: 1,
    senderEmail: "tomek@gmail.com",
    roomID: "string",
    text: "string",
    imageUrl: "https://picsum.photos/200",
    authorFirstName: "Tomek",
    authorLastName: "Romek"
  }]
},
{
  idRoom: 5,
  roomId: "Tomek",
  roomName: "Test",
  idAccount: 1,
  CreatedAt: "1",
  tenantID: 1,
  ownerID: 1,
  ownerEmail: "tomek@gmail.com",
  ownerFirstName: "Tomek",
  ownerLastName: "Romek",
  messages: [{
    id: 1,
    idAccount: 1,
    createdAt: 1,
    senderEmail: "tomek@gmail.com",
    roomID: "string",
    text: "string",
    imageUrl: "https://picsum.photos/200",
    authorFirstName: "Tomek",
    authorLastName: "Romek"
  }]
},
{
  idRoom: 6,
  roomId: "Tomek",
  roomName: "Test",
  idAccount: 1,
  CreatedAt: "1",
  tenantID: 1,
  ownerID: 1,
  ownerEmail: "tomek@gmail.com",
  ownerFirstName: "Tomek",
  ownerLastName: "Romek",
  messages: [{
    id: 1,
    idAccount: 1,
    createdAt: 1,
    senderEmail: "tomek@gmail.com",
    roomID: "string",
    text: "string",
    imageUrl: "https://picsum.photos/200",
    authorFirstName: "Tomek",
    authorLastName: "Romek"
  }]
},
{
  idRoom: 7,
  roomId: "Tomek",
  roomName: "Test",
  idAccount: 1,
  CreatedAt: "1",
  tenantID: 1,
  ownerID: 1,
  ownerEmail: "tomek@gmail.com",
  ownerFirstName: "Tomek",
  ownerLastName: "Romek",
  messages: [{
    id: 1,
    idAccount: 1,
    createdAt: 1,
    senderEmail: "tomek@gmail.com",
    roomID: "string",
    text: "string",
    imageUrl: "https://picsum.photos/200",
    authorFirstName: "Tomek",
    authorLastName: "Romek"
  }]
},
{
  idRoom: 8,
  roomId: "Tomek",
  roomName: "Test",
  idAccount: 1,
  CreatedAt: "1",
  tenantID: 1,
  ownerID: 1,
  ownerEmail: "tomek@gmail.com",
  ownerFirstName: "Tomek",
  ownerLastName: "Romek",
  messages: [{
    id: 1,
    idAccount: 1,
    createdAt: 1,
    senderEmail: "tomek@gmail.com",
    roomID: "string",
    text: "string",
    imageUrl: "https://picsum.photos/200",
    authorFirstName: "Tomek",
    authorLastName: "Romek"
  }]
},
{
  idRoom: 9,
  roomId: "Tomek",
  roomName: "Test",
  idAccount: 1,
  CreatedAt: "1",
  tenantID: 1,
  ownerID: 1,
  ownerEmail: "tomek@gmail.com",
  ownerFirstName: "Tomek",
  ownerLastName: "Romek",
  messages: [{
    id: 1,
    idAccount: 1,
    createdAt: 1,
    senderEmail: "tomek@gmail.com",
    roomID: "string",
    text: "string",
    imageUrl: "https://picsum.photos/200",
    authorFirstName: "Tomek",
    authorLastName: "Romek"
  }]
},
{
  idRoom: 10,
  roomId: "Tomek",
  roomName: "Test",
  idAccount: 1,
  CreatedAt: "1",
  tenantID: 1,
  ownerID: 1,
  ownerEmail: "tomek@gmail.com",
  ownerFirstName: "Tomek",
  ownerLastName: "Romek",
  messages: [{
    id: 1,
    idAccount: 1,
    createdAt: 1,
    senderEmail: "tomek@gmail.com",
    roomID: "string",
    text: "string",
    imageUrl: "https://picsum.photos/200",
    authorFirstName: "Tomek",
    authorLastName: "Romek"
  }]
}];


  const data: TransformedConversation[] = [];
  for (let c of conversations) {
    if (c && c.messages[0]) {
      data.push({
        idRoom: c.idRoom,
        roomId: c.roomId,
        recipientName: c.roomName,
        messages: c.messages,
      });
    }
  }

  return data;
};

export const useConversationsQuery = () => {
  const { user } = useUser();

  return useQuery(
    queryKeys.conversations,
    () => fetchConversations(user?.email, user?.accessToken),
    {
      retry: false,
    }
  );
};

type ConversationsRes = {
  idRoom: number;
  roomId: string;
  idAccount: number;
  roomName: string;
  CreatedAt: string;
  tenantID: number;
  ownerID: number;
  ownerFirstName: string;
  ownerLastName: string;
  ownerEmail: string;
  messages: Message[];
};
