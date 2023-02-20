import { useQueryClient, useMutation } from "react-query";

import { queryKeys } from "../../constants/constants";
import { socket } from "../../constants/socket";
import { Author, SelectedConversation, TransformedConversation } from "../../types/conversation";
import { MessageType, User } from "@flyerhq/react-native-chat-ui/lib/types";
import { useUser } from "../useUser";

const createMessage = (
  author: User,
  roomId: string,
  text: string,
) => {
  console.log('dataaxd', 'sendMessage',  {
    author,
    roomId,
    text,
  })
  return socket.invoke('sendMessage',  {
    author,
    roomId,
    text,
  });
}

export const useCreateMessageMutation = () => {
  const queryClient = useQueryClient();
  const { user } = useUser();

  return useMutation(
    ({
      idRoom,
      roomId,
      author,
      text,
    }: {
      idRoom: number,
      roomId: string;
      author: Author;
      text: string;
    }) =>
      createMessage(
        author,
        roomId,
        text,
      ),
    {
      onMutate: async ({
        author,
        text,
        idRoom,
        roomId,
      }) => {
        await queryClient.cancelQueries(queryKeys.conversations);
        await queryClient.cancelQueries(queryKeys.selectedConversation);

        const prevConversations: TransformedConversation[] | undefined =
          queryClient.getQueryData(queryKeys.conversations);
        const prevSelectedConversation: SelectedConversation | undefined =
          queryClient.getQueryData(queryKeys.selectedConversation);

        const textMessage: MessageType.Text = {
          author,
          createdAt: Date.now(),
          id: Date.now().toString(),
          text: text,
          type: "text",
        };

        if (prevSelectedConversation) {
          const newSelectedConversation = { ...prevSelectedConversation };
          newSelectedConversation.messages.unshift(textMessage);

          queryClient.setQueryData(
            queryKeys.selectedConversation,
            newSelectedConversation
          );
        }

        if (prevConversations) {
          const newConversations = [...prevConversations];
          const index = newConversations.findIndex(
            (i) => i.idRoom === idRoom
          );
          newConversations[index].messages.unshift({
            author,
            id: Date.now(),
            text
          });
          
          queryClient.setQueryData(queryKeys.conversations, newConversations);
        }

        return {
          prevConversations,
          prevSelectedConversation,
        };
      },
      onError: (err, vars, context) => {
        queryClient.setQueryData(
          queryKeys.conversations,
          context?.prevConversations
        );
        queryClient.setQueryData(
          queryKeys.selectedConversation,
          context?.prevSelectedConversation
        );
      },
      onSuccess: (
        _,
        { author, roomId, text }
      ) => {
        console.log("Wiadomość wysłana poprawnie");
      },
      onSettled: () => {
        queryClient.invalidateQueries(queryKeys.conversations);
        queryClient.invalidateQueries(queryKeys.selectedConversation);
      },
    }
  );
};
