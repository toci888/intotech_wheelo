import axios from "axios";
import { useQuery } from "react-query";
import { endpoints, queryKeys } from "../../constants/constants";
import { SearchScreenParams } from "../../types";
import { Location } from "../../types/locationIQ";

import { Collocation } from "../../types/property";
import { useUser } from "../useUser";

const fetchProperties = async (startAndEndLocation: SearchScreenParams): Promise<Collocation> => {
  if (!startAndEndLocation.startLocation || !startAndEndLocation.endLocation
    ) return {} as Collocation;

  const response = await axios.post(`${endpoints.addWorkTrip}`, {
    "idaccount": 49,
    "searchid": "",
    "latitudefrom": startAndEndLocation.startLocation.lat,
    "longitudefrom": startAndEndLocation.startLocation.lon,
    "latitudeto": startAndEndLocation.endLocation.lat,
    "longitudeto": startAndEndLocation.endLocation.lon,
    "iFromHour": Number(startAndEndLocation.startLocationTime.substring(0,2)),
    "iToHour": Number(startAndEndLocation.endLocationTime.substring(0,2)),
    "iFromMinute": Number(startAndEndLocation.startLocationTime.substring(3,5)),
    "iToMinute": Number(startAndEndLocation.endLocationTime.substring(3,5)),
    "acceptabledistance": 800
  });  

  const data: Collocation = response.data;
  // console.log("przystanek 1", endpoints.addWorkTrip)
  // console.log("przystanek dane", data)
  console.log("liczba elementow", data.methodResult.accountsCollocated.length)
  return data;
};

export const useSearchPropertiesQuery = (startAndEndLocation: SearchScreenParams) => {
  const { user } = useUser();
  const queryInfo = useQuery(
    queryKeys.searchProperties,
    () => fetchProperties(startAndEndLocation),
    {
      enabled: false,
    }
  );

  const data = queryInfo?.data;
  // if (data)
  //   for (let property of data) {
  //     property.liked = false;
  //     if (user?.savedProperties?.includes(property.ID)) property.liked = true;
  //   }

  return {
    ...queryInfo,
    data,
  };
};
