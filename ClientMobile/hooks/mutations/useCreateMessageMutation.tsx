import { useQueryClient, useMutation } from "react-query";
import axios from "axios";

import { endpoints, queryKeys } from "../../constants/constants";
import { socket } from "../../constants/socket";
import { SelectedConversation, TransformedConversation, Author, } from "../../types/conversation";
import { MessageType } from "@flyerhq/react-native-chat-ui/lib/types";
import { useUser } from "../useUser";

const createMessage = (
  conversationID: number,
  senderID: string,
  receiverID: number,
  authorFirstName: string,
  authorLastName: string,
  text: string,
  token?: string
) => {
  return socket.invoke('sendMessage',  {
    senderID,
    text,
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
      senderID,
      receiverID,
      authorFirstName,
      authorLastName,
      text,
      imageUrl
    }: {
      conversationID: number;
      author: Author;
      senderID: string;
      receiverID: number;
      authorFirstName: string,
      authorLastName: string,
      text: string;
      imageUrl: string;
    }) =>
      createMessage(
        conversationID,
        senderID,
        receiverID,
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
        receiverID,
        senderID,
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
            roomID: receiverID,
            senderID,
            text,
            authorFirstName,
            authorLastName,
            imageUrl
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
        { author, conversationID, receiverID, senderID, text, authorFirstName, authorLastName }
      ) => {
        // // socket.invoke("sendMessage", {
        // //   senderID,
        // //   conversationID,
        // //   receiverID,
        // //   text,
        // //   senderName: `${author.firstName} ${author.lastName}`,
        // // });
        createMessage(
          conversationID,
          senderID,
          receiverID,
          authorFirstName,
          authorLastName,
          text,
        );
      },
      onSettled: () => {
        queryClient.invalidateQueries(queryKeys.conversations);
        queryClient.invalidateQueries(queryKeys.selectedConversation);
      },
    }
  );
};
