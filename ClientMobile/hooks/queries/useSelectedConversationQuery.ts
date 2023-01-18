import axios from "axios";
import { useQuery } from "react-query";
import { MessageType } from "@flyerhq/react-native-chat-ui";

import { endpoints, queryKeys } from "../../constants/constants";
import { Message } from "../../types/message";
import { useUser } from "../useUser";
import { Author, SelectedConversation } from "../../types/conversation";

const fetchConversation = async (
  conversationID: number,
  userID?: number,
  token?: string
): Promise<SelectedConversation> => {
  console.log("CzatKlik", `${endpoints.getConversationByID}/get-conversation-by-id?roomId=${conversationID}`, token)
  const response = await axios.get(
    `${endpoints.getConversationByID}/get-conversation-by-id?roomId=${conversationID}`,
    {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    }
  ); 
  const data: ConversationRes = response.data;

  const tenantAuthor: Author = {
    id: data.tenantID.toString(),
    firstName: data.messages[0].authorFirstName ? data.messages[0].authorFirstName : data.tenantEmail,
    lastName: data.messages[0].authorFirstName && data.messages[0].authorLastName ? data.messages[0].authorLastName : "",
  };

  const ownerAuthor: Author = {
    id: data.ownerID.toString(),
    firstName: data.ownerFirstName ? data.ownerFirstName : "",
    lastName:  data.ownerLastName ? data.ownerLastName : "",
  };
  // const image = `https://scontent-frx5-1.xx.fbcdn.net/v/t39.30808-1/262427974_4735820343143988_5239449481639743539_n.jpg?stp=c0.54.200.200a_dst-jpg_p200x200&_nc_cat=105&ccb=1-7&_nc_sid=7206a8&_nc_ohc=6YGgU2kKkCIAX_Q6Jdx&_nc_ht=scontent-frx5-1.xx&oh=00_AfCquUWK2QkphGQzmhW9XY6uWY6igzMdM7cFBxWqsWxh4w&oe=63C91A30`
  // const image = `https://20.203.135.11:5072/image?dataId=1000000003&queryValid=83692C5C1E69005D57E127E2854D35A1`
  // const image = `https://avatars.githubusercontent.com/u/14123304?v=4`
  const messages: MessageType.Any[] = [];
  for (let m of data.messages) {
    // console.log("AJM", m)
    // const image = m.imageUrl;
    // console.log("AJM2", image)
    const message: MessageType.Any = {
      id: m.id.toString(),
      author: m.senderID.toString() === ownerAuthor.id ? {...ownerAuthor, imageUrl:image} 
      : {...tenantAuthor, imageUrl:m.imageUrl},
      createdAt: new Date(m.createdAt).getTime(),
      text: m.text,
      type: "text",
    };
    messages.push(message);
  }

  const conversation: SelectedConversation = {
    id: data.id,
    receiverID: userID === data.ownerID ? data.tenantID : data.ownerID,
    messages,
    author: userID === data.ownerID ? ownerAuthor : tenantAuthor,
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
