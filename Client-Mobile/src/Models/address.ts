export class Address {
  PostCode!: string;
  City!: string;
  Street!: string;
  HouseNumber!: number;
}

export function createAddress(
  data: any
): Address {
  return ParseGeogLocResult(data);
}

function ParseGeogLocResult(data: any): Address {

  const Mapper = [
    {'route': (json: any, model: Address) => { model.Street = json.long_name; return model; } },
    {'street_number': (json: any, model: Address) => { model.HouseNumber = json.long_name; return model; } },
    {'postal_code': (json: any, model: Address) => { model.PostCode = json.long_name; return model; } },
    {'locality': (json: any, model: Address) => { model.City = json.long_name; return model; } },
  ];

  let address = new Address();

  data.address_components.forEach((element: any) => {
    Mapper.forEach((mapEl: any) => {
      if (mapEl[element.types[0]] !== undefined)
      {
        address = mapEl[element.types[0]](element, address);
      }
    });
  });

  return address;
}
