export type Coordinates = {
    Lattitude: number;
    Longitude: number;
};

export function createCoordinates(
  lat: number,
  lng: number
):
  | { type: 'Success'; coordinates: Coordinates }
  | { type: 'Error'; message: string } {

  if (lat > 90 || lat < -90) {
    return {type: 'Error', message: 'Wartość lat jest nieprawidłowa'};
  } else if (lng > 180 || lng < -180) {
    return {type: 'Error', message: 'Wartość lng jest nieprawidłowa'};
  } else {
    return {type: 'Success', coordinates: {Lattitude: lat, Longitude: lng}};
  }
}
