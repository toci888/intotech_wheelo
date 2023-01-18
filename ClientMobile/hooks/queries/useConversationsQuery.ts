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

  console.log("BEFOREE", `${endpoints.getConversationsByUserEmail}/get-conversations-by-user-email ${email}`, token, email)
  const response = await axios.post(
    `${endpoints.getConversationsByUserEmail}`,
    {
      email
    },
    {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    }
  );
  const conversations: ConversationsRes[] = response.data.conversations;
  
  const data: TransformedConversation[] = [];
  for (let c of conversations) {
    if (c.messages[0]) {
      data.push({
        id: c.id,
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
  id: number;
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
