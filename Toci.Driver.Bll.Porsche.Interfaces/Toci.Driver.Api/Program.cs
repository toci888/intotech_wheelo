using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Bll.Porsche.Association.SourceDestinationCollocating;
using Intotech.Wheelo.Bll.Porsche.Interfaces.Association.SourceDestinationCollocating;
using Intotech.Wheelo.Bll.Porsche.Interfaces.PersistenceAggregation;
using Intotech.Wheelo.Bll.Porsche.Interfaces.Services.AccountsIsfa;
using Intotech.Wheelo.Bll.Porsche.PersistenceAggregation;
using Intotech.Wheelo.Bll.Porsche.Services.AccountsIsfa;
using Toci.Driver.Bll.Porsche.Association;
using Toci.Driver.Bll.Porsche.Interfaces.Association;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5105); // to listen for incoming http connection on port 5001
    //options.ListenAnyIP(7105, configure => configure.UseHttps()); // to listen for incoming https connection on port 7001
});

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors(x => x.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader())); //Angular Localhost
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICarLogic, CarLogic>();
builder.Services.AddScoped<ICarsBrandLogic, CarsBrandLogic>();
builder.Services.AddScoped<ICarsModelLogic, CarsModelLogic>();
builder.Services.AddScoped<IFriendLogic, FriendLogic>();
builder.Services.AddScoped<IFriendSuggestionLogic, FriendSuggestionLogic>();
builder.Services.AddScoped<IGeographicRegionLogic, GeographicRegionLogic>();
builder.Services.AddScoped<IInvitationLogic, InvitationLogic>();
builder.Services.AddScoped<IAccountLogic, AccountLogic>();
builder.Services.AddScoped<IUsersCollocationLogic, UsersCollocationLogic>();
builder.Services.AddScoped<IUsersLocationLogic, UsersLocationLogic>();
builder.Services.AddScoped<IUsersWorkTimeLogic, UsersWorkTimeLogic>();
builder.Services.AddScoped<IVfriendLogic, VfriendLogic>();
builder.Services.AddScoped<IVfriendSuggestionLogic, VfriendSuggestionLogic>();
builder.Services.AddScoped<IVinvitationLogic, VinvitationLogic>();
builder.Services.AddScoped<IVusersCollocationLogic, VusersCollocationLogic>();
builder.Services.AddScoped<IAccountLogic, AccountLogic>();
builder.Services.AddScoped<IWorkTripLogic, WorkTripLogic>();
builder.Services.AddScoped<ITripLogic, TripLogic>();
builder.Services.AddScoped<ITripparticipantLogic, TripparticipantLogic>();
builder.Services.AddScoped<IVTripsParticipantsLogic, VTripsParticipantsLogic>();
builder.Services.AddScoped<IAccountsCarsLocationLogic, AccountsCarsLocationLogic>();

// -------
builder.Services.AddScoped<IAssociationCalculations, AssociationCalculations>();
builder.Services.AddScoped<IAccountCollocationMatch<IUsersLocationLogic, IUsersCollocationLogic>, AccountCollocationMatch>();
builder.Services.AddScoped<ICollocator<IWorkTripLogic, IUsersCollocationLogic>, Collocator>();
builder.Services.AddScoped<ITripManager, TripManager>();
builder.Services.AddScoped<IInstantOccasion, InstantOccasion>();
builder.Services.AddScoped<IFriendsSuggestionsService, FriendsSuggestionsService>();
builder.Services.AddScoped<IFriendsService, FriendsService>();
builder.Services.AddScoped<IInvitationService, InvitationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); // Angular Localhost

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


