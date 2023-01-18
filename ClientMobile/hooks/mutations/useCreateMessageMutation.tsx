import { useQueryClient, useMutation } from "react-query";
import axios from "axios";

import { endpoints, queryKeys } from "../../constants/constants";
import { socket } from "../../constants/socket";
import { SelectedConversation, TransformedConversation, Author, } from "../../types/conversation";
import { MessageType, User } from "@flyerhq/react-native-chat-ui/lib/types";
import { useUser } from "../useUser";

const createMessage = (
  conversationID: number,
  idAccount: number,
  senderEmail: string,
  authorFirstName: string,
  authorLastName: string,
  text: string,
) => {
  return socket.invoke('sendMessage',  {
    idAccount,
    text,
    senderEmail,
    ID: conversationID, //to delete
    CreatedAt: new Date(),
    authorFirstName,
    authorLastName,
    RoomID: conversationID
   });
}

export const useCreateMessageMutation = () => {
  const queryClient = useQueryClient();
  const { user } = useUser();

  return useMutation(
    ({
      conversationID,
      author,
      idAccount,
      senderEmail,
      receiverID,
      authorFirstName,
      authorLastName,
      text,
      imageUrl
    }: {
      conversationID: number;
      author: User;
      idAccount: number;
      senderEmail: string,
      receiverID: number;
      authorFirstName: string,
      authorLastName: string,
      text: string;
      imageUrl: string;
    }) =>
      createMessage(
        conversationID,
        idAccount,
        authorFirstName,
        authorLastName,
        imageUrl,
        text
      ),
    {
      onMutate: async ({
        author,
        text,
        conversationID,
        idAccount,
        authorFirstName,
        authorLastName,
        imageUrl
      }) => {
        await queryClient.cancelQueries(queryKeys.conversations);
        await queryClient.cancelQueries(queryKeys.selectedConversation);

        const prevConversations: TransformedConversation[] | undefined =
          queryClient.getQueryData(queryKeys.conversations);
        const prevSelectedConversation: SelectedConversation | undefined =
          queryClient.getQueryData(queryKeys.selectedConversation);

        const textMessage: MessageType.Text = {
          author: author,
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
            (i) => i.id === conversationID
          );

          newConversations[index].messages.unshift({
            createdAt: new Date().toString(),
            id: Date.now(),
            roomID: conversationID,
            senderEmail: user?.email as string,
            text,
            authorFirstName,
            authorLastName,
            imageUrl,
            idAccount: idAccount
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
        { author, senderEmail, conversationID, idAccount, text, authorFirstName, authorLastName }
      ) => {

        createMessage(
          conversationID,
          idAccount,
          senderEmail,
          authorFirstName,
          authorLastName,
          text
        );
      },
      onSettled: () => {
        queryClient.invalidateQueries(queryKeys.conversations);
        queryClient.invalidateQueries(queryKeys.selectedConversation);
      },
    }
  );
};
