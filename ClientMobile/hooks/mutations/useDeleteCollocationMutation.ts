import axios from "axios";
import { useMutation, useQueryClient } from "react-query";

import { endpoints, queryKeys } from "../../constants/constants";
import { CollocateAccount } from "../../types/collocation";
import { useUser } from "../useUser";

const deleteCollocation = (propertyID: number, token?: string) =>
  axios.delete(`${endpoints.deleteProperty}${propertyID}`, {
    headers: {
      Authorization: `Bearer ${token}`,
    },
  });

export const useDeleteCollocationMutation = () => {
  const queryClient = useQueryClient();
  const { user } = useUser();

  return useMutation(
    ({ collocationID }: { collocationID: number }) =>
      deleteCollocation(collocationID, user?.accessToken),
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
