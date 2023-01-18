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
  id: number;
  receiverID: string;
  messages: MessageType.Any[];
  author: User;
};

export type TransformedConversation = {
  id: number;
  // collocationID: number;
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

export type Author = {
  id: string; //?
  createdAt: number;
  firstName: string;
  lastName: string;
  lastSeen: string; //?
  senderEmail: string;
  imageUrl: string;
};
