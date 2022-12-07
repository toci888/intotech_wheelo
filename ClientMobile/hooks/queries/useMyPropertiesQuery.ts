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
    `${endpoints.getPropertiesByUserID}${userID}`,
    {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    }
  );

  const data: Collocation[] = response.data;
  return data;
};

export const useMyPropertiesQuery = () => {
  const { user } = useUser();

  return useQuery(queryKeys.myProperties, () =>
    fetchProperties(user?.ID, user?.accessToken)
  );
};
