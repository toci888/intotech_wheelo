import axios from "axios";
import { useQuery } from "react-query";

import { endpoints, queryKeys } from "../../constants/constants";
import { Collocation, CollocateAccount } from "../../types/property";
import { useUser } from "../useUser";

const fetchProperty = async (propertyID: number): Promise<CollocateAccount> => {
  const response = await axios.get(`${endpoints.getPropertyByID}${propertyID}`);

  const data: CollocateAccount = response.data;
  return data;
};

export const useSelectedPropertyQuery = (propertyID: number) => {
  const { user } = useUser();
  const queryInfo = useQuery(queryKeys.selectedProperty, () =>
    fetchProperty(propertyID)
  );

  const data = {accountid: 1} as CollocateAccount//queryInfo?.data; // TODO!
  if (data) if (user?.savedProperties?.includes(data.accountid)) data.areFriends = true;

  return {
    ...queryInfo,
    data,
  };
};