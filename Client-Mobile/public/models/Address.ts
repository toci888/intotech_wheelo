export class Address {
  PostCode!: string;
  City!: string;
  Street!: string;
  HouseNumber!: number;
}

export function createAddress(
  PostCode: string,
  City: string,
  Street: string,
  HouseNumber: number
): Address {
  return {
    PostCode,
    City,
    Street,
    HouseNumber,
  };
}
