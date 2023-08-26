using Intotech.Common;
using Intotech.Common.Database.DbSetup;
using Intotech.Common.Interfaces;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Common.Translations;
using Intotech.Wheelo.Social.Bll.Lamborgini;
using Intotech.Wheelo.Social.Bll.Lamborgini.Interfaces;
using Intotech.Wheelo.Social.Bll.Persistence;
using Intotech.Wheelo.Social.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Social.Bll.Pontiac;
using Intotech.Wheelo.Social.Bll.Pontiac.Interfaces;
//using Intotech.Wheelo.Social.Tests.Persistence.Seed;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5154);
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddScoped<IAccountRoleLogic, AccountRoleLogic>();
builder.Services.AddScoped<ICommentLogic, CommentLogic>();
builder.Services.AddScoped<ICommenttypeLogic, CommenttypeLogic>();
builder.Services.AddScoped<IGroupLogic, GroupLogic>();
builder.Services.AddScoped<IGroupmemberLogic, GroupmemberLogic>();
builder.Services.AddScoped<IGroupspostLogic, GroupspostLogic>();
builder.Services.AddScoped<IGroupspostscommentLogic, GroupspostscommentLogic>();
builder.Services.AddScoped<IMeetingskippedaccountLogic, MeetingskippedaccountLogic>();
builder.Services.AddScoped<IOrganizemeetingLogic, OrganizemeetingLogic>();
builder.Services.AddScoped<IUsercommentLogic, UsercommentLogic>();
builder.Services.AddScoped<IExpenseLogic, ExpenseLogic>();
builder.Services.AddScoped<ITranslationEngineI18n, WheeloTranslationEngineI18n>();



builder.Services.AddScoped<IAccountBll, AccountBll>();

builder.Services.AddScoped<IGroupManager, GroupManager>();
builder.Services.AddScoped<IOrganizeMeetingManager, OrganizeMeetingManager>();
builder.Services.AddScoped<IExpensesService, ExpensesService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    //DbSetupEntity dbSetupEntity = new DbSetupEntity("localhost", "beatka", "Intotech.Wheelo.Social")
    //{
    //    //ParentProjectFolderPath = "intotech_wheelo",
    //    ProjectName = "Intotech.Wheelo.Chat.Database.Persistence",
    //    SqlFilePath = "..\\..\\SQL\\social.sql"
    //};

    //DbSetupFacade dbSetup = new DbSetupFacade(dbSetupEntity);

    //dbSetup.RunAll(true);

    //DbSetupManager dbSm = new DbSetupManager("Host=localhost;Database=postgres;Username=postgres;Password=beatka",
    //    "Host=localhost;Database=Intotech.Wheelo.Social;Username=postgres;Password=beatka", "Intotech.Wheelo.Social", "..\\..\\SQL\\social.sql");

    //dbSm.SetupDatabase(false);

    //DbScaffoldManager dbScaffoldManager = new DbScaffoldManager("Host=localhost;Database=Intotech.Wheelo.Social;Username=postgres;Password=beatka",
    //    "Intotech.Wheelo.Social.Database.Persistence", "intotech_wheelo\\Toci.Driver.Bll.Porsche.Interfaces");

    //dbScaffoldManager.RunScaffold();

    //new SocialSeedManager().SeedAllDb();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
