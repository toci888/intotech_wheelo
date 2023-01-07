using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Chat.Api.Hubs;
using Intotech.Wheelo.Chat.Bll.Persistence;
using Intotech.Wheelo.Chat.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Chat.Dodge;
using Intotech.Wheelo.Chat.Dodge.Interfaces;
using Intotech.Wheelo.Chat.Jaguar;
using Intotech.Wheelo.Chat.Jaguar.Interfaces;

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


builder.Services.AddScoped<IMessageLogic, MessageLogic>();
builder.Services.AddScoped<IRoomLogic, RoomLogic>();
builder.Services.AddScoped<IConnecteduserLogic, ConnecteduserLogic>();
builder.Services.AddScoped<IUseractivityLogic, UseractivityLogic>();
builder.Services.AddScoped<IRoomsaccountLogic, RoomsaccountLogic>();
builder.Services.AddScoped<IAccountLogic, AccountLogic>();
builder.Services.AddScoped<IConversationinvitationLogic, ConversationinvitationLogic>();
builder.Services.AddScoped<IMessageLogic, MessageLogic>();


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

app.UseCors();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<ChatHub>("/wheeloChat");
    //endpoints.MapHub<BroadcastHub>("/wheeloBroadcast");
});

app.Run();
