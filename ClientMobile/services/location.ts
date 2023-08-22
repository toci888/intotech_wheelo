import axios from "axios";

import { endpoints } from "../constants/constants";
import { GoogleMaps, Location } from "../types/locationIQ";
import { handleError } from "../utils/handleError";

export const getSuggestedLocations = async (text: string) => {
  try {
    const urlPlaceId = `${endpoints.autoComplete}?query=${text}`
    const {data} = await axios.get<GoogleMaps[]>(urlPlaceId);
    if (data) return data;

    console.log("brak danych lokalizacji z backendu, prawdopodobnie google key wygasł");
    return [];
  } catch (error) {
    handleError(error);
    console.error(error);
    return [];
  }
};

export const getLocationByPlaceId = async (placeId: string) => {
  try {
    const url = `${endpoints.recognizePlaceId}?placeId=${placeId}`
    const {data} = await axios.get<Location>(url);

    if (data) return data;

    console.log("brak danych lokalizacji z backendu, prawdopodobnie google key wygasł");
    return [];
  } catch (error) {
    handleError(error);
    console.error(error);
    return [];
  }
};

export const searchLocations = async (text: string) => {
  try {
    const url = `${endpoints.autoComplete}?query=${text}`; //add property screen

    const { data } = await axios.get<Location[]>(url);
    if (data) return data;

    console.log("brak danych lokalizacji z backendu, prawdopodobnie google key wygasł");
    return [];
  } catch (error) {
    handleError(error);
    console.error(error);
    return [];
  }
};
