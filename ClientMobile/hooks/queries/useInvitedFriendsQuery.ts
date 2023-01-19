import axios from "axios";
import { useQuery } from "react-query";

import { endpoints, queryKeys } from "../../constants/constants";
import { CollocateAccount } from "../../types/collocation";
import { useUser } from "../useUser";

const fetchProperties = async (
  userID?: number,
  token?: string
): Promise<CollocateAccount[]> => {
  if (!userID) return [];
  console.log("ssd", `${endpoints.getInvitedFriendsByUserID}?idAccount=${userID}`)
  const response = await axios.get(
    `${endpoints.getInvitedFriendsByUserID}?idAccount=${userID}`,
    {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    }
  );
  
  const data: CollocateAccount[] = response.data.methodResult;

  return data;
};

export const useInvitedFriendsQuery = () => {
  const { user } = useUser();
  const queryInfo = useQuery(
    queryKeys.contactedProperties,
    () => fetchProperties(user?.id, user?.accessToken),
    {
      retry: false,
    }
  );
  const data = queryInfo?.data;

  return {
    ...queryInfo,
    data,
  };
};
