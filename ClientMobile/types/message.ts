export type Message = {
  id: number;
  createdAt: string;
  senderID: string;
  roomID: number;
  text: string;
  imageUrl: string;
  authorFirstName: string;
  authorLastName: string;
};
