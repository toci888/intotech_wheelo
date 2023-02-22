import { useQueryClient, useMutation } from "react-query";

import { queryKeys } from "../../constants/constants";
import { sendMessage } from "../../constants/socket";
import { Author, SelectedConversation, TransformedConversation } from "../../types/conversation";
import { MessageType } from "@flyerhq/react-native-chat-ui/lib/types";

const createMessage = (
  author: Author,
  roomId: string,
  text: string,
) => {
  return sendMessage(author.id, roomId, text);
}

export const useCreateMessageMutation = () => {
  const queryClient = useQueryClient();

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
          const index = newConversations.findIndex((i) => i.idRoom === idRoom);
          console.log('index roomu:', index)
          if (index >= 0) {
            console.log('stary room wiadomosc: ', text)
            newConversations[index].messages.unshift({
              createdAt: new Date().toDateString(), // todo?
              idAccount: author.id,
              roomId: roomId,
              senderEmail: author.senderEmail,
              id: Date.now(), //TODO!
              text
            });
            
            queryClient.setQueryData(queryKeys.conversations, newConversations);
          }
        } else {
          console.log("NOWY ROOM. Dane wiadomossci", {
            idAccount: author.id,
            roomId: roomId,
            senderEmail: author.senderEmail,
            text
          })
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
