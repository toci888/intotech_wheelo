import axios from "axios";
import { useQuery } from "react-query";
import { endpoints, queryKeys } from "../../constants/constants";
import { useApiClient } from "../../services/useApiClient";
import { ReturnedResponse, SearchScreenParams } from "../../types";

import { Collocation } from "../../types/collocation";
import { useUser } from "../useUser";

const fetchProperties = async (startAndEndLocation: SearchScreenParams, userId?: number): Promise<ReturnedResponse<Collocation>> => {
  if (!startAndEndLocation.startLocation || !startAndEndLocation.endLocation) 
    return {} as ReturnedResponse<Collocation>;
  
    const { data } = await axios.post<ReturnedResponse<Collocation>>(`${endpoints.addWorkTrip}`, {
    startLocation: startAndEndLocation.startLocation,
    endLocation: startAndEndLocation.endLocation,
    startLocationTime: startAndEndLocation.startLocationTime,
    endLocationTime: startAndEndLocation.endLocationTime,
    idAccount: userId,
    acceptableDistance: startAndEndLocation.acceptableDistance,
    driverPassenger: startAndEndLocation.driverPassenger,
  } as SearchScreenParams);

  data.isSuccess? console.log("liczba markerów:", data.methodResult.accountsCollocated.length) : console.log("Brak markerów")
  return data;
};

export const useSearchPropertiesQuery = (startAndEndLocation: SearchScreenParams) => {
  const { user } = useUser();
  const queryInfo = useQuery(
    queryKeys.searchCollocations,
    () => fetchProperties(startAndEndLocation, user?.id),
    {
      enabled: false,
    }
  );

  const data = queryInfo?.data;

  if (data?.isSuccess === true)
    for (let accountCollocated of data.methodResult.accountsCollocated) {
      accountCollocated.relationshipStatus = false;
      if (user?.savedCollocations?.includes(accountCollocated.idAccount)) accountCollocated.relationshipStatus = true;
    }

  return {
    ...queryInfo,
    data,
  };
};
