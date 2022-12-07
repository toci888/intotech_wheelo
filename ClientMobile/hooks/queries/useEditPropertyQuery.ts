import axios from "axios";
import { useQuery } from "react-query";

import { endpoints, queryKeys } from "../../constants/constants";
import { Collocation } from "../../types/property";

const fetchProperty = async (propertyID: number): Promise<Collocation> => {
  const response = await axios.get(`${endpoints.getPropertyByID}${propertyID}`);

  const data: Collocation = response.data;
  return data;
};

export const useEditPropertyQuery = (propertyID: number) =>
  useQuery(queryKeys.editProperty, () => fetchProperty(propertyID));
