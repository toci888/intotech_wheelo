import { Apartment } from "./apartment";
import { Review } from "./review";
import { Pet } from "./pet";
import { Score } from "./score";
import { TempApartment } from "./tempApartment";
import { Driver } from "../types";

// export class response<T> {
//   methodResult!: {
//     T: T
//   };
//   errorMessage!: string;
//   isSuccess!: boolean;
//   errorCode!: number;
// }

export type Collocation = {
  methodResult: {
    accountsCollocated: CollocateAccount[],
    sourceAccount: CollocateAccount
  },
  errorMessage: string,
  isSuccess: boolean,
  errorCode: number
}

export type CollocateAccount = {
  idAccount: number,
  image: string[],
  name: string,
  surname: string,
  latitudefrom: number,
  longitudefrom: number,
  latitudeto: number,
  longitudeto: number,
  fromhour: string,
  tohour: string
  areFriends: boolean;
  phoneNumber: string;
  isDriver: Driver;
}

export type CreateProperty = {
  unitType: string;
  propertyType: string;
  street: string;
  city: string;
  state: string;
  zip: number;
  lat: number;
  lng: number;
  userID: number;
  apartments: {
    unit?: string;
    bedrooms: number;
    bathrooms: number;
    active: boolean;
    availableOn: Date;
  }[];
};

export type EditPropertyObj = {
  ID?: number;
  unitType?: "single" | "multiple";
  apartments: TempApartment[];
  description: string;
  images: string;
  includedUtilities: string[];
  petsAllowed: string;
  laundryType: string;
  parkingFee: number;
  amenities: string[];
  name: string;
  firstName: string;
  lastName: string;
  email: string;
  callingCode?: string;
  countryCode?: string;
  phoneNumber: string;
  website: string;
  onMarket: boolean;
};
