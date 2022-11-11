import { Address } from './Address';
import { Coordinates } from './coordinates';

export type GeogLocModel = {
  Coordinates: Coordinates,
  Address: Address;
}

export function createGeogLocModel(
  Coordinates: Coordinates,
  Address: Address
): GeogLocModel {
  return {
    Coordinates,
    Address
  };
}
