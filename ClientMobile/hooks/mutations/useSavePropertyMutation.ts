import { useQueryClient, useMutation } from "react-query";
import axios from "axios";

import { useUser } from "../useUser";
import { endpoints, queryKeys } from "../../constants/constants";
import { CollocateAccount } from "../../types/property";

const saveOrUnsaveProperty = (
  propertyID: number,
  op: "add" | "remove",
  userID?: number,
  token?: string
) =>
  axios.patch(
    `${endpoints.alterSavedPropertiesByUserID(userID as number)}`,
    {
      propertyID,
      op,
    },
    {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    }
  );

export const useSavePropertyMutation = () => {
  const { user } = useUser();
  const queryClient = useQueryClient();

  return useMutation(
    ({ propertyID, op }: { propertyID: number; op: "add" | "remove" }) =>
      saveOrUnsaveProperty(propertyID, op, user?.ID, user?.accessToken),
    {
      onMutate: async ({ propertyID, op }) => {
        await queryClient.cancelQueries(queryKeys.savedProperties);
        await queryClient.cancelQueries(queryKeys.searchCollocations);
        await queryClient.cancelQueries(queryKeys.selectedProperty);

        const prevSavedProperties: CollocateAccount[] | undefined =
          queryClient.getQueryData(queryKeys.savedProperties);
        const prevSearchedProperties: CollocateAccount[] | undefined =
          queryClient.getQueryData(queryKeys.searchCollocations);
        const prevSelectedProperty: CollocateAccount | undefined =
          queryClient.getQueryData(queryKeys.selectedProperty);

        if (prevSelectedProperty?.accountid === propertyID) {
          const newSelectedProperty = { ...prevSelectedProperty };

          newSelectedProperty.areFriends = !newSelectedProperty.areFriends;
          queryClient.setQueryData(
            queryKeys.selectedProperty,
            newSelectedProperty
          );
        }

        if (op === "remove") {
          if (prevSavedProperties) {
            const newSavedProperties = prevSavedProperties.filter(
              (i) => i.accountid !== propertyID
            );
            queryClient.setQueryData(
              queryKeys.savedProperties,
              newSavedProperties
            );
          }

          if (prevSearchedProperties)
            for (let i of prevSearchedProperties) {
              if (i.accountid === propertyID) i.areFriends = false;
            }
        } else if (op === "add") {
          if (prevSearchedProperties) {
            for (let i of prevSearchedProperties) {
              if (i.accountid === propertyID) i.areFriends = true;
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
          queryKeys.selectedProperty,
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
