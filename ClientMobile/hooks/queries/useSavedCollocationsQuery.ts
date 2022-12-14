import axios from "axios";
import { useQuery } from "react-query";

import { endpoints, queryKeys } from "../../constants/constants";
import { Collocation } from "../../types/collocation";
import { useUser } from "../useUser";

const fetchProperties = async (
  userID?: number,
  token?: string
): Promise<Collocation[]> => {
  if (!userID) return [];

  const response = await axios.get(
    endpoints.getSavedPropertiesByUserID(userID),
    {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    }
  );

  const data: Collocation[] = response.data;
  for (let i of data) i.methodResult.accountsCollocated[0].areFriends = true;

  return data;
};

export const useSavedCollocationsQuery = () => {
  const { user } = useUser();

  return useQuery(
    queryKeys.savedProperties,
    () => fetchProperties(user?.ID, user?.accessToken),
    {
      retry: false,
    }
  );
};
