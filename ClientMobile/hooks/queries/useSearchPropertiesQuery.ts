import axios from "axios";
import { useQuery } from "react-query";
import { endpoints, queryKeys } from "../../constants/constants";
import { Location } from "../../types/locationIQ";

import { Collocation } from "../../types/property";
import { useUser } from "../useUser";

const fetchProperties = async (startLocation: Location, endLocation: Location): Promise<Collocation> => {
  if (!startLocation || !endLocation) return {} as Collocation;

  const response = await axios.post(`${endpoints.addWorkTrip}`, {
    "idaccount": 49,
    "searchid": "",
    "latitudefrom": startLocation.lat,
    "longitudefrom": startLocation.lon,
    "latitudeto": endLocation.lat,
    "longitudeto": endLocation.lon,
    "iFromHour": 8,
    "iToHour": 16,
    "iFromMinute": 0,
    "iToMinute": 0,
    "acceptabledistance": 800
  });

  console.log({
    "idaccount": 49,
    "searchid": "",
    "latitudefrom": startLocation.lat,
    "longitudefrom": startLocation.lon,
    "latitudeto": endLocation.lat,
    "longitudeto": endLocation.lon,
    "iFromHour": 8,
    "iToHour": 16,
    "iFromMinute": 0,
    "iToMinute": 0,
    "acceptabledistance": 800
  })

  // console.log(endpoints.addWorkTrip, {
  //   "idaccount": 50,
  //   "latitudefrom": startLocation.lat,
  //   "longitudefrom": startLocation.lon,
  //   "latitudeto": endLocation.lat,
  //   "longitudeto": endLocation.lon,
  //   "iFromHour": 8,
  //   "iToHour": 16,
  //   "iFromMinute": 0,
  //   "iToMinute": 0,
  // })

  // const response = await axios.post(`${endpoints.addWorkTrip}`, {
  //   "idaccount": 50,
  //   "latitudefrom": 52.24802984098752,
  //   "longitudefrom": 21.08828642005573,
  //   "latitudeto": 52.20878607141056,
  //   "longitudeto": 21.0188489021064,
  //   "streetfrom": "string",
  //   "streetto": "string",
  //   "cityfrom": "string",
  //   "cityto": "string",
  //   "iFromHour": 8,
  //   "iToHour": 16,
  //   "iFromMinute": 0,
  //   "iToMinute": 0,
  //   "acceptabledistance": 800
  // });
  

  const data: Collocation = response.data;
  // console.log("przystanek 1", endpoints.addWorkTrip)
  console.log("przystanek dane", data)
  console.log("liczba elementow", data.methodResult.accountsCollocated.length)
  return data;
};

export const useSearchPropertiesQuery = (startLocation: Location, endLocation: Location) => {
  const { user } = useUser();
  const queryInfo = useQuery(
    queryKeys.searchProperties,
    () => fetchProperties(startLocation, endLocation),
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
