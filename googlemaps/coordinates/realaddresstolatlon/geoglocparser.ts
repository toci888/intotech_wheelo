import GeogLocModel from "./geoglocmodel";

export default class GeogLocDataParser
{
    Mapper = [
        {"route": (json, model: GeogLocModel) => { model.Street = json.long_name; return model; } },
        {"street_number": (json, model: GeogLocModel) => { model.HouseNumber = json.long_name; return model; } },
        {"postal_code": (json, model: GeogLocModel) => { model.PostCode = json.long_name; return model; } },
        {"locality": (json, model: GeogLocModel) => { model.City = json.long_name; return model; } },
    ];

    model: GeogLocModel = new GeogLocModel();

    ParseGeogLocResult(result: google.maps.GeocoderResult[])
    {
        result[0].address_components.forEach(element => {
            
            this.Mapper.forEach(mapEl => {

                if (mapEl[element.types[0]] !== undefined)
                {
                    this.model = mapEl[element.types[0]](element, this.model);
                }
            });
        });

        this.model.Latitude = result[0].geometry.location.lat();
        this.model.Longitude = result[0].geometry.location.lng()

        return this.model;
    }
}