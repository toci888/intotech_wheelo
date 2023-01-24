import axios from "axios";
import { useQuery } from "react-query";

import { endpoints, queryKeys } from "../../constants/constants";
import { ReturnedResponse } from "../../types";
import { CollocateAccount, Collocation } from "../../types/collocation";
import { useUser } from "../useUser";

const fetchFriends = async (
  userID?: number,
  token?: string
): Promise<CollocateAccount[]> => {
  if (!userID) return [];

  const response = await axios.get(
    endpoints.getFriendsByUserID(userID),
    {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    }
  );
  const data: CollocateAccount[] = response.data.methodResult;
  
  for (let i of data) i.relationshipStatus = true;
  
  return data;
};

export const useFriendsQuery = () => {
  const { user } = useUser();

  return useQuery(
    queryKeys.savedProperties,
    () => fetchFriends(user?.id, user?.accessToken),
    {
      retry: false,
    }
  );
};
