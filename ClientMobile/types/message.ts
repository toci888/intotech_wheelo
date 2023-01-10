export type Message = {
  id: number;
  createdAt: string;
  senderID: number;
  roomID: number;
  text: string;
  authorFirstName: string;
  authorLastName: string;
};
