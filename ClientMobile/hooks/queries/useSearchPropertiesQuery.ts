import axios from "axios";
import { useQuery } from "react-query";
import { endpoints, queryKeys } from "../../constants/constants";
import { useApiClient } from "../../services/useApiClient";
import { SearchScreenParams } from "../../types";

import { Collocation } from "../../types/collocation";
import { useUser } from "../useUser";

const fetchProperties = async (startAndEndLocation: SearchScreenParams, userId?: number): Promise<Collocation> => {
  if (!startAndEndLocation.startLocation || !startAndEndLocation.endLocation) 
    return {} as Collocation;

  const response = await axios.post(`${endpoints.addWorkTrip}`, {
    startLocation: startAndEndLocation.startLocation,
    endLocation: startAndEndLocation.endLocation,
    startLocationTime: startAndEndLocation.startLocationTime,
    endLocationTime: startAndEndLocation.endLocationTime,
    idAccount: userId ? userId : 1000000045,
    acceptableDistance: 800
  });  
  
  const data = response.data as Collocation;

  console.log("przystanek dane", data)
  data.isSuccess?
  console.log("liczba markerów:", data.methodResult.accountsCollocated.length)
  : console.log("Brak markerów")
  return data;
};

export const useSearchPropertiesQuery = (startAndEndLocation: SearchScreenParams) => {
  const { user } = useUser();
  const queryInfo = useQuery(
    queryKeys.searchCollocations,
    () => fetchProperties(startAndEndLocation, user?.ID),
    {
      enabled: false,
    }
  );

  const data = queryInfo?.data;

  if (data && data.isSuccess !== false)
    for (let accountCollocated of data.methodResult.accountsCollocated) {
      accountCollocated.areFriends = false;
      if (user?.savedProperties?.includes(accountCollocated.idAccount)) accountCollocated.areFriends = true;
    }

  return {
    ...queryInfo,
    data,
  };
};
