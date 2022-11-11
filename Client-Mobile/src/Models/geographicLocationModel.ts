import { Address } from './address';
import { Coordinates } from './coordinates';

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
