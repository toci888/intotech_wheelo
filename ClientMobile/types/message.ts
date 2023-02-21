import { Author } from "./conversation";

export type Message = {
  id: number;
  idAccount: number;
  text: string;
  createdAt: string;
  roomId: string, // ??
  senderEmail: string,
};
