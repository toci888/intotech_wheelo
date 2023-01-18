import axios from "axios";
import { useMutation, useQueryClient } from "react-query";
import { StackActions, useNavigation } from "@react-navigation/native";

import { endpoints, queryKeys } from "../../constants/constants";
import { CreateProperty, Collocation } from "../../types/collocation";
import { useUser } from "../useUser";

const createProperty = (obj: CreateProperty, token?: string) =>
  axios.post<Collocation>(endpoints.createProperty, obj, {
    headers: {
      Authorization: `Bearer ${token}`,
    },
  });

export const useCreatePropertyMutation = () => {
  const queryClient = useQueryClient();
  const { dispatch } = useNavigation();
  const { user } = useUser();

  return useMutation(
    (obj: CreateProperty) => createProperty(obj, user?.accessToken),
    {
      onError() {
        alert("Unable to create property");
      },
      onSuccess(data: { data: Collocation }) {
        queryClient.invalidateQueries(queryKeys.myProperties);
        dispatch(
          StackActions.replace("EditProperty", { propertyID: data.data.methodResult.sourceAccount.idAccount })
        );
      },
    }
  );
};
