using Intotech.Wheelo.Bll.Models;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Chat.Api.Hubs;
using Intotech.Wheelo.Chat.Bll.Persistence;
using Intotech.Wheelo.Chat.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Chat.Dodge;
using Intotech.Wheelo.Chat.Dodge.Interfaces;
using Intotech.Wheelo.Chat.Jaguar;
using Intotech.Wheelo.Chat.Jaguar.Interfaces;
using Intotech.Wheelo.Common.Interfaces.CachingService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Intotech.Wheelo.Common.CachingService;
using Intotech.Wheelo.Notifications;
using Intotech.Wheelo.Notifications.Interfaces;
using Intotech.Common.Database.DbSetup;
using Intotech.Wheelo.Chat.Tests.Persistence.Seed;
using Intotech.Common;
using Intotech.Wheelo.Chat.Database.Persistence.Models;
using Intotech.Common.Database.Interfaces;
using Intotech.Common.Bll.Interfaces;
using Intotech.Common.Database;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSignalR(e => {
    e.MaximumReceiveMessageSize = 10240000;
    e.HandshakeTimeout = TimeSpan.FromSeconds(30);
    e.ClientTimeoutInterval = TimeSpan.FromMinutes(10);
});
builder.Services.AddControllers();

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5130); // to listen for incoming http connection on port 5001
    //http://20.100.196.118:5105
    //IPAddress.Parse(20.100.196.118"),
    //options.ListenAnyIP(7105, configure => configure.UseHttps()); // to listen for incoming https connection on port 7001
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

builder.Services.AddScoped<IMessagesService, MessagesService>();
builder.Services.AddScoped<IChatUserService, ChatUserService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IConversationService, ConversationService>();
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<ICachingService, CachingService>();
builder.Services.AddScoped<IChatNotificationsService, ChatNotificationsService>();
builder.Services.AddScoped<INotificationManager, NotificationManager>();
builder.Services.AddScoped<INotificationClient, NotificationClient>();

IDbHandleManager<ModelBase> dbHandleManager = new DbHandleManager<ModelBase>(() => new IntotechWheeloChatContext());

builder.Services.AddSingleton(dbHandleManager);


builder.Services.AddScoped<IMessageLogic, MessageLogic>();
builder.Services.AddScoped<IRoomLogic, RoomLogic>();
builder.Services.AddScoped<IConnecteduserLogic, ConnecteduserLogic>();
builder.Services.AddScoped<IUseractivityLogic, UseractivityLogic>();
builder.Services.AddScoped<IRoomsaccountLogic, RoomsaccountLogic>();
builder.Services.AddScoped<IAccountLogic, AccountLogic>();
builder.Services.AddScoped<IConversationinvitationLogic, ConversationinvitationLogic>();
builder.Services.AddScoped<IMessageLogic, MessageLogic>();
builder.Services.AddScoped<IPushtokenLogic, PushtokenLogic>();

//builder.Services.AddAuthentication(sharedopt => sharedopt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, (configureOptions) => { });
// .AddPolicyScheme("User", "User", configureOptions => { });


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
        ValidIssuer = "http://intotech.com.pl",
        ValidAudience = "http://intotech.com.pl",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Int0t3chWheelo!@#SuperSecr3tByGh05tr1d3r"))
    };
    cfg.Events = new JwtBearerEvents
    {
        OnMessageReceived = ctx => {
            if (ctx.Request.Query.ContainsKey("access_token"))
            {
                ctx.Token = ctx.Request.Query["access_token"]; // "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6ImJhcnRla0BnZy5wbCIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWUiOiJXb2p0ZWsgUnVjaGHFgmEiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBZG1pbiIsImV4cCI6MTY3MzcyNDM4MywiaXNzIjoiaHR0cDovL2ludG90ZWNoLmNvbS5wbCIsImF1ZCI6Imh0dHA6Ly9pbnRvdGVjaC5jb20ucGwifQ.iBZx7ZfDiqs81MhKl4ioiAg4_kTMAOOja_UGTvX-xZo"; 
            }

            return Task.CompletedTask;
    }
    };
});
/*
 "JwtKey": "Int0t3chWheelo!@#SuperSecr3tByGh05tr1d3r",
    "JwtExpireDays": 2,
    "JwtIssuer": "http://intotech.com.pl"
 */


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    string solutionDirectory = EnvironmentUtils.GetSolutionDirectory();

    DbSetupEntity dbSetupEntity = new DbSetupEntity("beatka", "Intotech.Wheelo.Chat")
    {
        //ParentProjectFolderPath = "intotech_wheelo",
        ProjectName = "Intotech.Wheelo.Chat.Database.Persistence",
        SqlFilePath = Path.Combine(solutionDirectory, EnvironmentUtils.IsDockerEnv ? "../src/Toci.Driver.Bll.Porsche.Interfaces/Wheelo.Chat.sql" : "intotech_wheelo/Toci.Driver.Bll.Porsche.Interfaces\\Wheelo.Chat.sql")
    };

    DbSetupFacade dbSetup = new DbSetupFacade(dbSetupEntity);

    dbSetup.RunAll(true);

    /*DbSetupManager dbSm = new DbSetupManager("Host=localhost;Database=postgres;Username=postgres;Password=beatka",
        "Host=localhost;Database=Intotech.Wheelo.Chat;Username=postgres;Password=beatka", "Intotech.Wheelo.Chat", "..\\Toci.Driver.Bll.Porsche.Interfaces\\Wheelo.Chat.sql");

    dbSm.SetupDatabase();

    DbScaffoldManager dbScaffoldManager = new DbScaffoldManager("Host=localhost;Database=Intotech.Wheelo.Chat;Username=postgres;Password=beatka",
        "Intotech.Wheelo.Chat.Database.Persistence", "Dev\\intotech_wheelo");

    dbScaffoldManager.RunScaffold();*/

    new ChatSeedManager().SeedAllDb();
}

app.UseHttpsRedirection();

app.MapControllers();

app.UseCors();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<ChatHub>("/wheeloChat");
    //endpoints.MapHub<BroadcastHub>("/wheeloBroadcast");
});

app.Run();
