import { GeogLocModel } from '../models/geoglocmodel';

export class GeogLocDataParser {
  constructor() {}

  Mapper = [
    {
      route: (json, model: GeogLocModel) => {
        model.Street = json.long_name;

        return model;
      },
    },
    {
      street_number: (json, model: GeogLocModel) => {
        model.HouseNumber = json.long_name;

        return model;
      },
    },
    {
      postal_code: (json, model: GeogLocModel) => {
        model.PostCode = json.long_name;

        return model;
      },
    },
    {
      locality: (json, model: GeogLocModel) => {
        model.City = json.long_name;
        
        return model;
      },
    },
  ];

  model: GeogLocModel = new GeogLocModel();

  ParseGeogLocResult(result: any) {
    result.result.address_components.forEach((element) => {
      this.Mapper.forEach((mapEl) => {
        if (mapEl[element.types[0]] !== undefined) {
          this.model = mapEl[element.types[0]](element, this.model);
        }
      });
    });

    console.log("geometry", result.result.geometry);

    this.model.Latitude = result.result.geometry.location.lat;
    this.model.Longitude = result.result.geometry.location.lng;

    return this.model;
  }
}
