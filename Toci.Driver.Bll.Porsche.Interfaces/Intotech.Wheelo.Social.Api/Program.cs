using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Social.Bll.Lamborgini;
using Intotech.Wheelo.Social.Bll.Lamborgini.Interfaces;
using Intotech.Wheelo.Social.Bll.Persistence;
using Intotech.Wheelo.Social.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Social.Bll.Pontiac;
using Intotech.Wheelo.Social.Bll.Pontiac.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAccountLogic, AccountLogic>();
builder.Services.AddScoped<IGroupmemberLogic, GroupmemberLogic>();
builder.Services.AddScoped<IGroupLogic, GroupLogic>();


builder.Services.AddScoped<IAccountBll, AccountBll>();

builder.Services.AddScoped<IGroupManager, GroupManager>(); 

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
