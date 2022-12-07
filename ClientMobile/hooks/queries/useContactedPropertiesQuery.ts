import axios from "axios";
import { useQuery } from "react-query";

import { endpoints, queryKeys } from "../../constants/constants";
import { Collocation } from "../../types/property";
import { useUser } from "../useUser";

const fetchProperties = async (
  userID?: number,
  token?: string
): Promise<Collocation[]> => {
  if (!userID) return [];

  const response = await axios.get(
    endpoints.getContactedPropertiesByUserID(userID),
    {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    }
  );

  const data: Collocation[] = response.data;

  return data;
};

export const useContactedPropertiesQuery = () => {
  const { user } = useUser();
  const queryInfo = useQuery(
    queryKeys.contactedProperties,
    () => fetchProperties(user?.ID, user?.accessToken),
    {
      retry: false,
    }
  );

  const data = queryInfo?.data;
  if (data)
    for (let property of data) {
      property.liked = false;
      if (user?.savedProperties?.includes(property.ID)) property.liked = true;
    }

  return {
    ...queryInfo,
    data,
  };
};
