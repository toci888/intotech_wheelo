import { Address } from './../models/Address';
import { Coordinates } from '../models/coordinates';
import { createGeogLocModel, GeogLocModel } from '../models/geogLocalizationModel';

export class GeogLocDataParser {

  Mapper = [
        {"route": (json, model: Address) => { model.Street = json.long_name; return model; } },
        {"street_number": (json, model: Address) => { model.HouseNumber = json.long_name; return model; } },
        {"postal_code": (json, model: Address) => { model.PostCode = json.long_name; return model; } },
        {"locality": (json, model: Address) => { model.City = json.long_name; return model; } },
  ];

  address = new Address();

  ParseGeogLocResult(data: any, coordinates: Coordinates) { //google.maps.places.PlacesDetailsResponse

    data.result.address_components.forEach((element) => {
      this.Mapper.forEach((mapEl) => {
        if (mapEl[element.types[0]] !== undefined)
        {
            this.address = mapEl[element.types[0]](element, this.address);
        }
      });
    });

    const GeogLocalization = createGeogLocModel(coordinates, this.address);

    return GeogLocalization;
  }
}
