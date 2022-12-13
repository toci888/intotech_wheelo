using Intotech.Wheelo.Common.Google;
using Intotech.Wheelo.Common.Interfaces.Models;
using Intotech.Wheelo.Integration.Bll.Skoda.Google;
using Intotech.Wheelo.Integration.Bll.Skoda.Google.Converters;
using Intotech.Wheelo.Integration.Bll.Skoda.Interfaces.Google;
using Intotech.Wheelo.Integration.Bll.Skoda.Interfaces.Google.Converters;
using Intotech.Wheelo.Integration.Bll.Skoda.Interfaces.Google.Models;
using Intotech.Wheelo.Integration.Bll.Skoda.Interfaces.Google.Models.LatLng;
using Intotech.Wheelo.Integration.Bll.Skoda.Interfaces.Services;
using Intotech.Wheelo.Integration.Bll.Skoda.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5108); // to listen for incoming http connection on port 5001
    //http://20.100.196.118:5105
    //IPAddress.Parse(20.100.196.118"),
    //options.ListenAnyIP(7105, configure => configure.UseHttps()); // to listen for incoming https connection on port 7001
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IGoogleMapsClient<string, GooglePlaceGeoModel>, GooglePlaceGeoModelClient>();
builder.Services.AddScoped<IGoogleMapsClient<string, GooglePredictionsGeoModel>, GooglePredictionsGeoModelClient>();
builder.Services.AddScoped<IGoogleMapsClient<string, GoogleLatLngGeoModel>, GoogleLatLngGeoModelClient>();
builder.Services.AddScoped<IGooglePlaceToGeographicLocationConverter<GooglePlaceGeoModel, GeographicLocation>, GooglePlaceToGeographicLocationConverter>();
builder.Services.AddScoped<IGooglePlaceToGeographicLocationConverter<GooglePredictionsGeoModel, GeographicLocation[]>, GoogleAutocompleteToGeographicLocationConverter>();
builder.Services.AddScoped<IGooglePlaceToGeographicLocationConverter<GoogleLatLngGeoModel, GeographicLocation>, GoogleLatLngToGeographicLocationConveter>();


builder.Services.AddScoped<IGoogleMapsService, GoogleMapsService> ();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.UseDeveloperExceptionPage();

app.MapControllers();

app.Run();
