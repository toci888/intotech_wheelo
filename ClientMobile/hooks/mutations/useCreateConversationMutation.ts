import { useNavigation } from "@react-navigation/native";
import { useMutation, useQueryClient } from "react-query";

import { queryKeys } from "../../constants/constants";
import { createRoom, sendMessage } from "../../constants/socket";
import { RoomsDto } from "../../types/conversation";

const createConversation = (
  userId: number, 
  accountIds: number[]
) => {
  return createRoom(userId, accountIds);
};

export const useCreateConversationMutation = () => {
  const queryClient = useQueryClient();
  const { navigate } = useNavigation();

  return useMutation(
    ({
      userId,
      accountIds,
    }: {
      userId: number; 
      accountIds: number[];
    }) =>
      createConversation(userId, accountIds),
      {
        onSuccess: (
          data: RoomsDto
        ) => {

          queryClient.invalidateQueries(queryKeys.contactedProperties);
          queryClient.invalidateQueries(queryKeys.conversations);
          
          // sendMessage(user)

          navigate("Chat", {
            screen: "Messages",
            params: {
                roomId: data.roomId,
                recipientName: data.roomName
            },
            initial: false,
          });
        },
      }
  );
};
