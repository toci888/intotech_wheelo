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
builder.Services.AddScoped<ICarsBrandLogic, CarsBrandLogic>();
builder.Services.AddScoped<ICarsModelLogic, CarsModelLogic>();


builder.Services.AddScoped<IColourManager, ColourManager>();
builder.Services.AddScoped<ICarsBrandsModelManager, CarsBrandModelManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
