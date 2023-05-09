using Intotech.Wheelo.Bll.Models;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Bll.Porsche.Association.SourceDestinationCollocating;
using Intotech.Wheelo.Bll.Porsche.Interfaces.Association.SourceDestinationCollocating;
using Intotech.Wheelo.Bll.Porsche.Interfaces.Services.AccountsIsfa;
using Intotech.Wheelo.Bll.Porsche.Services.AccountsIsfa;
using Intotech.Wheelo.Bll.Porsche;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Text;
using Toci.Driver.Bll.Porsche.Association;
using Toci.Driver.Bll.Porsche.Interfaces.Association;
using Intotech.Wheelo.Bll.Porsche.Interfaces;
using Intotech.Wheelo.Bll.Porsche.Interfaces.User;
using Intotech.Wheelo.Bll.Porsche.User;
using System.Text.Json;
using Intotech.Wheelo.Common.Interfaces.Emails;
using Intotech.Wheelo.Common.Emails;
using Intotech.Wheelo.Bll.Persistence.Interfaces.SubServices;
using Intotech.Wheelo.Bll.Persistence.SubServices;
using Intotech.Wheelo.Bll.Porsche.Interfaces.WorkTripAssociating;
using Intotech.Wheelo.Bll.Porsche.WorkTripAssociating;
using Intotech.Wheelo.Common.Interfaces.ModelMapperInterfaces;
using Intotech.Wheelo.Bll.Models.ModelMappers;
using Intotech.Wheelo.Bll.Models.Gaf;
using Intotech.Wheelo.Notifications.Interfaces;
using Intotech.Wheelo.Notifications;
using Intotech.Wheelo.Bll.Porsche.Driver;
using Intotech.Wheelo.Bll.Porsche.Interfaces.Driver;
using Intotech.Wheelo.Common.Interfaces.Models;
using Microsoft.IdentityModel.Tokens;
using Toci.Driver.Database.Persistence.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Intotech.Wheelo.Chat.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Chat.Bll.Persistence;
using Intotech.Common.Database.DbSetup;
using Intotech.Wheelo.Seed.Common.Wheelo.Main;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5105); // to listen for incoming http connection on port 5001
    //http://20.100.196.118:5105
    //IPAddress.Parse(20.100.196.118"),
    //options.ListenAnyIP(7105, configure => configure.UseHttps()); // to listen for incoming https connection on port 7001
});

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors(x => x.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader())); //Angular Localhost
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<AuthenticationSettings, AuthenticationSettings>();
builder.Services.AddScoped<ICarLogic, CarLogic>();
builder.Services.AddScoped<ICarsBrandLogic, CarsBrandLogic>();
builder.Services.AddScoped<ICarsModelLogic, CarsModelLogic>();
builder.Services.AddScoped<IFriendLogic, FriendLogic>();
builder.Services.AddScoped<IFriendSuggestionLogic, FriendSuggestionLogic>();
builder.Services.AddScoped<IGeographicRegionLogic, GeographicRegionLogic>();
builder.Services.AddScoped<IInvitationLogic, InvitationLogic>();
builder.Services.AddScoped<IAccountscollocationLogic, UsersCollocationLogic>();
builder.Services.AddScoped<IUsersLocationLogic, UsersLocationLogic>();
builder.Services.AddScoped<IUsersWorkTimeLogic, UsersWorkTimeLogic>();
builder.Services.AddScoped<IVfriendLogic, VfriendLogic>();
builder.Services.AddScoped<IVfriendSuggestionLogic, VfriendSuggestionLogic>();
builder.Services.AddScoped<IVinvitationLogic, VinvitationLogic>();
builder.Services.AddScoped<IVusersCollocationLogic, VusersCollocationLogic>();
builder.Services.AddScoped<IWorkTripLogic, WorkTripLogic>();
builder.Services.AddScoped<ITripLogic, TripLogic>();
builder.Services.AddScoped<ITripparticipantLogic, TripparticipantLogic>();
builder.Services.AddScoped<IVTripsParticipantsLogic, VTripsParticipantsLogic>();
builder.Services.AddScoped<IAccountsCarsLocationLogic, AccountsCarsLocationLogic>();
builder.Services.AddScoped<IUserExtraDataLogic, UserExtraDataLogic>();
builder.Services.AddScoped<ISimpleAccountLogic, SimpleAccountLogic>();
builder.Services.AddScoped<IAccountRoleLogic, AccountRoleLogic>();
builder.Services.AddScoped<IAccountLogic, AccountLogic>();
builder.Services.AddScoped<IOccupationLogic, OccupationLogic>();
builder.Services.AddScoped<IAccountMetadataLogic, AccountMetadataLogic>();
builder.Services.AddScoped<IVacollocationsgeolocationLogic, VacollocationsgeolocationLogic>();
builder.Services.AddScoped<IVcollocationsgeolocationLogic, VcollocationsgeolocationLogic>();
builder.Services.AddScoped<IVaccountscollocationsworktripLogic, VaccountscollocationsworktripLogic>();
builder.Services.AddScoped<IWorktripgenLogic, WorktripgenLogic>();
builder.Services.AddScoped<IVaworktripgengeolocationLogic, VaworktripgengeolocationLogic>();
builder.Services.AddScoped<IVacollocationsgeolocationLogic, VacollocationsgeolocationLogic>();
builder.Services.AddScoped<IVacollocationsgeolocationToAccountCollocationDto, VacollocationsgeolocationToAccountCollocationDto>();
builder.Services.AddScoped<IAccountmodeLogic, AccountmodeLogic>();
builder.Services.AddScoped<IFailedloginattemptLogic, FailedloginattemptLogic>();
builder.Services.AddScoped<IResetpasswordLogic, ResetpasswordLogic>();
builder.Services.AddScoped<IPushtokenLogic, PushtokenLogic>();
builder.Services.AddScoped<IOccupationSmokerCratLogic, OccupationSmokerCratLogic>();
builder.Services.AddScoped<IAccountChatLogic, AccountChatLogic>();

AuthenticationSettings authenticationSettings = new AuthenticationSettings();

// -------
builder.Services.AddScoped<IAssociationCalculations, AssociationCalculations>();
builder.Services.AddScoped<ITripService, TripService>();
builder.Services.AddScoped<IInstantOccasion, InstantOccasion>();
builder.Services.AddScoped<IFriendsSuggestionsService, FriendsSuggestionsService>();
builder.Services.AddScoped<IFriendsService, FriendsService>();
builder.Services.AddScoped<IInvitationService, InvitationService>();
builder.Services.AddScoped<IGafManager, GafManager>();
builder.Services.AddScoped<IDriverCarService, DriverCarService>();
builder.Services.AddScoped<IWheeloAccountService, WheeloAccountService>();
builder.Services.AddScoped<IAccountMetadataService, AccountMetadataService>();
builder.Services.AddScoped<IAssociationMapDataSubService, AssociationMapDataSubService>();
builder.Services.AddScoped<IWorkTripGenAssociationService, WorkTripGenAssociationService>();
builder.Services.AddScoped<IPassStrLoginAttFailService, PassStrLoginAttFailService>();
builder.Services.AddScoped<IUserMetaService, UserMetaService>();
builder.Services.AddScoped<IGafManager, GafManager>();
builder.Services.AddScoped<GafServiceBase<FacebookUserDto>, FacebookUserService>();
builder.Services.AddScoped<GafServiceBase<GoogleUserDto>, GoogleUserService>();
builder.Services.AddScoped<IVacollocationsgeolocationToAccountCollocationDto, VacollocationsgeolocationToAccountCollocationDto>();
builder.Services.AddScoped<IAccountIsfaToDto<Vfriend, FriendsDto>, VFriendsToFriendsDto>();
builder.Services.AddScoped<INotificationManager, NotificationManager>();
builder.Services.AddScoped<INotificationClient, NotificationClient>();

//builder.Services.AddScoped<IEmailManager, EmailManager>();

builder.Services.AddSingleton(authenticationSettings);

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = "Bearer";
    option.DefaultScheme = "Bearer";
    option.DefaultChallengeScheme = "Bearer";
}).AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = false;
    cfg.SaveToken = true;
    cfg.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = authenticationSettings.JwtIssuer,
        ValidAudience = authenticationSettings.JwtIssuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey))
    };
}); ; //.AddPolicyScheme();

builder.Services.AddControllers().AddJsonOptions(options => {
    options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    new WheeloMainSeedManager().SeedAllDb();

    app.UseSwagger();
    app.UseSwaggerUI();

    DbSetupEntity dbSetupEntity = new DbSetupEntity("localhost", "beatka", "Intotech.Wheelo")
    {
        ParentProjectFolderPath = "Toci.Driver.Bll.Porsche.Interfaces",
        ProjectName = "Toci.Driver.Database.Persistence",
        SqlFilePath = "..\\..\\SQL\\wheelo.sql"
    };

    DbSetupFacade dbSetup = new DbSetupFacade(dbSetupEntity);

    bool res = dbSetup.RunAll(true);

    
}



app.Configuration.GetSection("Authentication").Bind(authenticationSettings);

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); // Angular Localhost

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseDeveloperExceptionPage();

app.Run();


