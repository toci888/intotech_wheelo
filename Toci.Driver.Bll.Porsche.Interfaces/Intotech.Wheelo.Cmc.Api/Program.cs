using Intotech.Wheelo.Bll.Bentley;
using Intotech.Wheelo.Bll.Bentley.Interfaces;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Bll.Persistence.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IColourLogic, ColourLogic>();
builder.Services.AddScoped<ICarsbrandLogic, CarsbrandLogic>();
builder.Services.AddScoped<ICarsmodelLogic, CarsmodelLogic>();
builder.Services.AddScoped<IOccupationLogic, OccupationLogic>();


builder.Services.AddScoped<IColourManager, ColourManager>();
builder.Services.AddScoped<ICarsBrandsModelManager, CarsBrandModelManager>();
builder.Services.AddScoped<IOccupationsService, OccupationsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    //new SeedCarsModelsParser().Insert();
    ////new SeedCars().Insert();
    //new CarsXmlParser().Insert();
    //new ColourTxtParser().Insert();
    //new ProfessionsTxtParser().Insert();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
