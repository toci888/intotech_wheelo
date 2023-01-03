import axios from "axios";

import { endpoints } from "../constants/constants";
import { GoogleMaps, Location } from "../types/locationIQ";

export const getSuggestedLocations = async (text: string) => {
  try {
    const urlPlaceId = `${endpoints.autoComplete}?query=${text}`
    const {data} = await axios.get<GoogleMaps[]>(urlPlaceId);
    if (data) return data;

    return [];
  } catch (error) {
    console.error(error);
    return [];
  }
};

export const getLocationByPlaceId = async (placeId: string) => {
  try {
    const url = `${endpoints.recognizePlaceId}?placeId=${placeId}`
    const {data} = await axios.get<Location>(url);

    if (data) return data;

    return [];
  } catch (error) {
    console.error(error);
    return [];
  }
};

export const searchLocations = async (text: string) => {
  try {
    const url = `https://api.locationiq.com/v1/search.php?key=pk.95fe8bb8ddbbc10ed656fe23d485c8f0&q&q=Tampa&format=json&dedupe=1&addressdetails=1&matchquality=1&normalizeaddress=1&normalizecity=1`;
    const { data } = await axios.get<Location[]>(url);
    if (data) return data;

    return [];
  } catch (error) {
    console.error(error);
    return [];
  }
};
