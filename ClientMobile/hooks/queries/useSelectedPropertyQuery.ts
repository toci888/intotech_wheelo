import axios from "axios";
import { useQuery } from "react-query";

import { endpoints, queryKeys } from "../../constants/constants";
import { Collocation, CollocateAccount } from "../../types/collocation";
import { useUser } from "../useUser";

const fetchProperty = async (collocationID: number): Promise<CollocateAccount> => { 
  const { data } = await axios.get(`${endpoints.getCollocationByID}${collocationID}`);
  const collocateAccount: CollocateAccount = data.methodResult;

  return collocateAccount;
};

export const useSelectedCollocationQuery = (collocationID: number) => {
  const { user } = useUser();
  
  const queryInfo = useQuery(queryKeys.selectedCollocation, () =>
    fetchProperty(collocationID)
  );

  const data = queryInfo?.data as CollocateAccount;
  if (data) if (user?.savedCollocations?.includes(data.idAccount)) data.areFriends = true;
  
  return {
    ...queryInfo,
    data,
  };
};
