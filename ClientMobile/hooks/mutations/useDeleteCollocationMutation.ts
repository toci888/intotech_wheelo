import axios from "axios";
import { useMutation, useQueryClient } from "react-query";

import { endpoints, queryKeys } from "../../constants/constants";
import { CollocateAccount } from "../../types/collocation";
import { commonAlert } from "../../utils/handleError";
import { useUser } from "../useUser";

const deleteCollocation = (friendID: number, userId?: number, token?: string) => {
//http://20.203.135.11:5105/api/Friends/unfriend?accountId=1&idFriendToRemove=2
  console.log('usuwanie',`${endpoints.deleteFriend}?accountId=${userId}&idFriendToRemove=${friendID}`);
  return axios.delete(`${endpoints.deleteFriend}?accountId=${userId}&idFriendToRemove=${friendID}`, {
    headers: {
      Authorization: `Bearer ${token}`,
    },
  });
}

export const useDeleteCollocationMutation = () => {
  const queryClient = useQueryClient();
  const { user } = useUser();

  return useMutation(
    ({ collocationID }: { collocationID: number }) =>
      deleteCollocation(collocationID, user?.id, user?.accessToken),
    {
      onMutate: async ({ collocationID }) => {
        await queryClient.cancelQueries(queryKeys.myProperties);

        const prevProperties: CollocateAccount[] | undefined = queryClient.getQueryData(
          queryKeys.myProperties
        );

        if (prevProperties) {
          const filtered = prevProperties.filter((i) => i.idAccount !== collocationID);

          queryClient.setQueryData(queryKeys.myProperties, filtered);
        }

        return { prevProperties };
      },
      onSuccess: (data) => {
        commonAlert('udalo sie usunac');
        console.log('removee data', data.data)
      },
      onError: (err, newTodo, context) => {
        if (context?.prevProperties)
          queryClient.setQueryData(
            queryKeys.myProperties,
            context?.prevProperties
          );
      },
      onSettled: () => {
        queryClient.invalidateQueries(queryKeys.myProperties);
      },
    }
  );
};
