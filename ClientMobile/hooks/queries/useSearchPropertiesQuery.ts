import axios from "axios";
import { useQuery } from "react-query";
import { endpoints, queryKeys } from "../../constants/constants";

import { Property } from "../../types/property";
import { useUser } from "../useUser";

const fetchProperties = async (boundingBox?: number[]): Promise<Property> => {
  if (!boundingBox) return {} as Property;

  const response = await axios.post(`${endpoints.addWorkTrip}`, {
    "idaccount": 50,
    "latitudefrom": 52.24802984098752,
    "longitudefrom": 21.08828642005573,
    "latitudeto": 52.20878607141056,
    "longitudeto": 21.0188489021064,
    "streetfrom": "string",
    "streetto": "string",
    "cityfrom": "string",
    "cityto": "string",
    "iFromHour": 8,
    "iToHour": 16,
    "iFromMinute": 0,
    "iToMinute": 0,
    "acceptabledistance": 800
  });
  

  const data: Property = response.data;
  console.log("przystanek 1", endpoints.addWorkTrip)
  // console.log("przystanek 1", data)
  return data;
};

export const useSearchPropertiesQuery = (boundingBox: number[]) => {
  const { user } = useUser();
  const queryInfo = useQuery(
    queryKeys.searchProperties,
    () => fetchProperties(boundingBox),
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
