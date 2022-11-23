import { Address } from './Address';
import { Coordinates } from './Coordinates';

export type GeographicLocationModel = {
  Coordinates: Coordinates,
  Address: Address;
}

export function createGeographicLocationModel(
  Coordinates: Coordinates,
  Address: Address
): GeographicLocationModel {
  return {
    Coordinates,
    Address
  };
}
