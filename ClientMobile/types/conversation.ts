import { MessageType, User } from "@flyerhq/react-native-chat-ui/lib/types";

import { Message } from "./message";

export type Conversation = {
  id: number;
  ownerID: number;
  tenantID: number;
  propertyID: number;
  messages: Message[];
};

export type SelectedConversation = {
  idRoom: number;
  roomId: string;
  messages: MessageType.Any[];
  author: Author;
};

export type TransformedConversation = {
  idRoom: number;
  roomId: string;
  recipientName: string;
  messages: Message[];
};

export type CreateConversation = {
  tenantID: number;
  ownerID: number;
  propertyID: number;
  senderID: number;
  receiverID: number;
  text: string;
};

export type Author = User & {
  senderEmail: string;
  id: number;
};

export type RoomsDto = {
  ownerEmail: string;
  idRoom: number;
  roomId: string;
  roomName: string;
  roomMembers: RoomMembersDto[];
}

export type RoomMembersDto = {
  idAccount: number;
  email: string;
  firstName: string;
  lastName: string;
  createdAt: Date;
  pushTokens: string;
}
