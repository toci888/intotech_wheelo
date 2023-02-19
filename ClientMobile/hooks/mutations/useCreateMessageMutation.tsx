import { useQueryClient, useMutation } from "react-query";
import axios from "axios";

import { endpoints, queryKeys } from "../../constants/constants";
import { socket } from "../../constants/socket";
import { SelectedConversation, TransformedConversation, Author, } from "../../types/conversation";
import { MessageType, User } from "@flyerhq/react-native-chat-ui/lib/types";
import { useUser } from "../useUser";

const createMessage = (
  idRoom: number,
  roomId: string,
  idAccount: number,
  senderEmail: string,
  authorFirstName: string,
  authorLastName: string,
  text: string,
) => {
  console.log('responsxd', {
    idAccount,
    text,
    senderEmail,
    roomId,
    CreatedAt: new Date(),
    authorFirstName,
    authorLastName,
   })
  return socket.invoke('sendMessage',  {
    idAccount,
    text,
    senderEmail,
    roomId,
    CreatedAt: new Date(),
    authorFirstName,
    authorLastName,
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
      idAccount,
      senderEmail,
      receiverID,
      authorFirstName,
      authorLastName,
      text,
      imageUrl
    }: {
      idRoom: number,
      roomId: string;
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
        idRoom,
        roomId,
        idAccount,
        authorFirstName,
        authorLastName,
        imageUrl,
        text,
      ),
    {
      onMutate: async ({
        author,
        text,
        idRoom,
        roomId,
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
            (i) => i.idRoom === idRoom
          );
            console.log("MESSAGGGGEE", {
              createdAt: new Date().toString(),
              id: Date.now(),
              roomID: roomId,
              senderEmail: user?.email as string,
              text,
              authorFirstName,
              authorLastName,
              imageUrl,
              idAccount: idAccount
            })
          newConversations[index].messages.unshift({
            createdAt: Date.now(),
            id: Date.now(),
            roomID: roomId,
            senderEmail: user?.email as string,
            text,
            authorFirstName,
            authorLastName,
            imageUrl,
            idAccount: idAccount
          });
          console.log("MESSAGGGGEExd");
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
        { author, senderEmail, roomId, idAccount, text, authorFirstName, authorLastName }
      ) => {

        // createMessage(
        //   roomId,
        //   idAccount,
        //   senderEmail,
        //   authorFirstName,
        //   authorLastName,
        //   text
        // );
      },
      onSettled: () => {
        queryClient.invalidateQueries(queryKeys.conversations);
        queryClient.invalidateQueries(queryKeys.selectedConversation);
      },
    }
  );
};
