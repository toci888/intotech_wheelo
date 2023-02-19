import { useQueryClient, useMutation } from "react-query";
import axios from "axios";

import { useUser } from "../useUser";
import { endpoints, queryKeys } from "../../constants/constants";
import { CollocateAccount } from "../../types/collocation";
import { commonAlert } from "../../utils/handleError";

const saveOrUnsaveCollocation = (
  collocationID: number,
  op: "add" | "remove",
  userID?: number,
  token?: string
) =>
  axios.post(
    'http://40.82.192.15:5105/api/Invitations/invite-to-friends',
    // `${endpoints.alterSavedPropertiesByUserID(userID as number)}`, TODO!!
    {
      invitingAccountId: userID,
      invitedAccountId: collocationID
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
      saveOrUnsaveCollocation(collocationID, op, user?.id, user?.accessToken),
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

          newSelectedProperty.relationshipStatus = !newSelectedProperty.relationshipStatus;
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
              if (i.idAccount === collocationID) i.relationshipStatus = false;
            }
        } else if (op === "add") {
          if (prevSearchedProperties) {
            for (let i of prevSearchedProperties) {
              if (i.idAccount === collocationID) i.relationshipStatus = true;
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
      onSuccess: (
        { data },
        // { propertyName, ownerID, text, tenantID, senderName }
      ) => {
        console.log("UDALO SIE", data) //TODO
        commonAlert("udało się dodac")
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
