export type Message = {
  id: number;
  idAccount: number;
  createdAt: string;
  senderEmail: string;
  roomID: number;
  text: string;
  imageUrl: string;
  authorFirstName: string;
  authorLastName: string;
};
