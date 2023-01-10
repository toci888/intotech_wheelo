import axios from "axios";
import { useQuery } from "react-query";

import { endpoints, queryKeys } from "../../constants/constants";
import { TransformedConversation } from "../../types/conversation";
import { Message } from "../../types/message";
import { getStateAbbreviation } from "../../utils/getStateAbbreviation";
import { useUser } from "../useUser";

const fetchConversations = async (
  userID?: number,
  token?: string
): Promise<TransformedConversation[]> => {
  if (!userID) return [];

  console.log("BEFOREE", `${endpoints.getConversationsByUserID}/get-conversations-by-user-id?userId=${userID}`, token, userID)
  const response = await axios.get(
    `${endpoints.getConversationsByUserID}/get-conversations-by-user-id?userId=${userID}`,
    {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    }
  );

  const conversations: ConversationsRes[] = response.data;
  console.log("CONVVV", conversations)
  
  const data: TransformedConversation[] = [];
  for (let i of conversations) {
    // recipientName represents the person other than curr user in the conversation
    let recipientName = i.messages[0] && i.messages[0].authorFirstName && i.messages[0].authorLastName
                        ? `${i.messages[0].authorFirstName} ${i.messages[0].authorLastName}`
                        : "Nie podano imienia oraz nazwiska";
    if (i.messages[0]) {
      data.push({
        id: i.id,
        // collocationID: i.propertyID,
        recipientName,
        messages: i.messages,
      });
    }
    // data.push({
    //   id: i.id,
    //   // collocationID: i.propertyID,
    //   recipientName,
    //   messages: [{
    //     id: 2,
    //     createdAt: "x",
    //     senderID: 2,
    //     roomID: 2,
    //     text: "x",
    //     authorFirstName: "x",
    //     authorLastName: "x",
    //   }]
    //   //i.messages,
    // });
  }
  console.log("DATAGGG", data)
  return data;
};

export const useConversationsQuery = () => {
  const { user } = useUser();

  return useQuery(
    queryKeys.conversations,
    () => fetchConversations(user?.id, user?.accessToken),
    {
      retry: false,
    }
  );
};

type ConversationsRes = {
  id: number;
  CreatedAt: string;
  tenantID: number;
  ownerID: number;
  propertyID: number;
  propertyName: string;
  street: string;
  city: string;
  state: string;
  ownerFirstName: string;
  ownerLastName: string;
  ownerEmail: string;
  tenantFirstName: string;
  tenantLastName: string;
  tenantEmail: string;
  messages: Message[];
};
