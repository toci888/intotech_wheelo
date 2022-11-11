import { Address } from './../models/Address';
import { Coordinates } from '../models/coordinates';
import { createGeogLocModel, GeogLocModel } from '../models/geogLocalizationModel';

export class GeogLocDataParser {

  Mapper = [
    {
      0: (json: any, model: Address) => {
        console.log("TUU", json);
        console.log("TUU", json['value']);
        console.log("model", model);
        model.Street = json['value'];

        return model;
      },
    },
    {
      12: (json: any, model: Address) => {
        model.HouseNumber = json.value;

        return model;
      },
    },
    {
      15: (json: any, model: Address) => {
        model.PostCode = json.value;

        return model;
      },
    },
    {
      22: (json: any, model: Address) => {
        model.City = json.value;
        
        return model;
      },
    },
  ];

  address = new Address();

  ParseGeogLocResult(result: any, coordinates: Coordinates) { //google.maps.places.PlacesDetailsResponse
    // console.log("RESULT:");
    // console.log(result);
    // console.log("coordinates");
    // console.log(coordinates);
    
    result.terms.forEach((element) => {
      this.Mapper.forEach((mapEl) => {
        if (mapEl[element.offset] !== undefined) {
          this.address = mapEl[element.offset](element, this.address);
        }
      });
    });

    const GeogLocalization = createGeogLocModel(coordinates, this.address);

    console.log("GeogLocalization");
    console.log(GeogLocalization);

    return GeogLocalization;
  }
}
