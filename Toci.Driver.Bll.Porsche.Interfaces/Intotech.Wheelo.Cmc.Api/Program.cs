using Intotech.Common;
using Intotech.Common.Database.DbSetup;
using Intotech.Wheelo.Bll.Bentley;
using Intotech.Wheelo.Bll.Bentley.Interfaces;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Seed.Common.Wheelo.Dictionaries;

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

    /*8string solutionDirectory = EnvironmentUtils.GetSolutionDirectory();

    DbSetupEntity dbSetupEntity = new DbSetupEntity("beatka", "Intotech.Wheelo.Dictionaries")
    {
        //ParentProjectFolderPath = "Toci.Driver.Bll.Porsche.Interfaces",
        ProjectName = "Intotech.Wheelo.Dictionaries.Database.Persistence",
        SqlFilePath = Path.Combine(solutionDirectory, EnvironmentUtils.IsDockerEnv ? "SQL/dictionaries.sql" : "SQL\\dictionaries.sql")
    };

    DbSetupFacade dbSetup = new DbSetupFacade(dbSetupEntity, "intotech_wheelo/Toci.Driver.Bll.Porsche.Interfaces");

    bool res = dbSetup.RunAll(true);*/

    new DictionariesSeedManager().SeedAllDb();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
