import { Author } from "./conversation";

export type Message = {
  id: number;
  text: string;
  author: Author;
};
