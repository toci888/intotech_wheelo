export type Location = {
  place_id: string;
  lat: string;
  lon: string;
  boundingbox: string[];
  display_name: string;
  address: Address;
  location: string;
};

export type GoogleMaps = {
  place_id: string;
  display_name: string;
}

type Address = {
  name?: string;
  house_number?: string;
  road?: string;
  city?: string;
  state?: string;
  postcode?: string;
  country?: string;
  country_code?: string;
};
