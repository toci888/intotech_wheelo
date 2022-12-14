import { useQueryClient, useMutation } from "react-query";
import axios from "axios";

import { useUser } from "../useUser";
import { endpoints, queryKeys } from "../../constants/constants";
import { CollocateAccount } from "../../types/collocation";

const saveOrUnsaveCollocation = (
  collocationID: number,
  op: "add" | "remove",
  userID?: number,
  token?: string
) =>
  axios.patch(
    `${endpoints.alterSavedPropertiesByUserID(userID as number)}`,
    {
      collocationID,
      op,
    },
    {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    }
  );

export const useSaveCollocationMutation = () => {
  const { user } = useUser();
  const queryClient = useQueryClient();

  return useMutation(
    ({ collocationID, op }: { collocationID: number; op: "add" | "remove" }) =>
      saveOrUnsaveCollocation(collocationID, op, user?.ID, user?.accessToken),
    {
      onMutate: async ({ collocationID, op }) => {
        await queryClient.cancelQueries(queryKeys.savedProperties);
        await queryClient.cancelQueries(queryKeys.searchCollocations);
        await queryClient.cancelQueries(queryKeys.selectedCollocation);

        const prevSavedProperties: CollocateAccount[] | undefined =
          queryClient.getQueryData(queryKeys.savedProperties);
        const prevSearchedProperties: CollocateAccount[] | undefined =
          queryClient.getQueryData(queryKeys.searchCollocations);
        const prevSelectedProperty: CollocateAccount | undefined =
          queryClient.getQueryData(queryKeys.selectedCollocation);

        if (prevSelectedProperty?.idAccount === collocationID) {
          const newSelectedProperty = { ...prevSelectedProperty };

          newSelectedProperty.areFriends = !newSelectedProperty.areFriends;
          queryClient.setQueryData(
            queryKeys.selectedCollocation,
            newSelectedProperty
          );
        }

        if (op === "remove") {
          if (prevSavedProperties) {
            const newSavedProperties = prevSavedProperties.filter(
              (i) => i.idAccount !== collocationID
            );
            queryClient.setQueryData(
              queryKeys.savedProperties,
              newSavedProperties
            );
          }

          if (prevSearchedProperties)
            for (let i of prevSearchedProperties) {
              if (i.idAccount === collocationID) i.areFriends = false;
            }
        } else if (op === "add") {
          if (prevSearchedProperties) {
            for (let i of prevSearchedProperties) {
              if (i.idAccount === collocationID) i.areFriends = true;
            }
          }
        }

        queryClient.setQueryData(
          queryKeys.searchCollocations,
          prevSearchedProperties
        );

        return {
          prevSavedProperties,
          prevSearchedProperties,
          prevSelectedProperty,
        };
      },
      onError: (err, vars, context) => {
        queryClient.setQueryData(
          queryKeys.savedProperties,
          context?.prevSavedProperties
        );
        queryClient.setQueryData(
          queryKeys.searchCollocations,
          context?.prevSearchedProperties
        );
        queryClient.setQueryData(
          queryKeys.selectedCollocation,
          context?.prevSelectedProperty
        );
      },
      onSettled: () => {
        queryClient.invalidateQueries(queryKeys.savedProperties);
        queryClient.invalidateQueries(queryKeys.searchCollocations);
      },
    }
  );
};
