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

builder.Services.AddScoped<IAccountRoleLogic, AccountRoleLogic>();
builder.Services.AddScoped<ICommentLogic, CommentLogic>();
builder.Services.AddScoped<ICommenttypeLogic, CommenttypeLogic>();
builder.Services.AddScoped<IGroupLogic, GroupLogic>();
builder.Services.AddScoped<IGroupmemberLogic, GroupmemberLogic>();
builder.Services.AddScoped<IGroupspostLogic, GroupspostLogic>();
builder.Services.AddScoped<IGroupspostscommentLogic, GroupspostscommentLogic>();
builder.Services.AddScoped<IMeetingskippedaccountLogic, MeetingskippedaccountLogic>();
builder.Services.AddScoped<IOrganizemeetingLogic, OrganizemeetingLogic>();
builder.Services.AddScoped<IUsercommentLogic, UsercommentLogic>();



builder.Services.AddScoped<IAccountBll, AccountBll>();

builder.Services.AddScoped<IGroupManager, GroupManager>();
builder.Services.AddScoped<IOrganizeMeetingManager, OrganizeMeetingManager>();

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
