// See https://aka.ms/new-console-template for more information
using Intotech.ReflectiveTools.SourceGenerators.ModelsToTypescript;
using Intotech.Warrior;
using Intotech.Wheelo.Bll.Models.Social;
using Intotech.Wheelo.Social.Tests.Persistence.Seed;
using Intotech.Wheelo.Tests.Persistence.Seed;
using System.Reflection;
using Toci.Driver.Database.Persistence.Models;


Console.WriteLine("Warrior is seeding your dbs....");

//SeedAccount sa = new SeedAccount();

//new SeedTrip().Insert();

//sa.Insert();
//new SeedFriendSuggestion().Insert();

new WheeloMainSeedManager().SeedAllDb();

new SocialSeedManager().SeedAllDb();
//new SeedTrip().Insert();
//new SeedTripParticipants().Insert();
//TypeScriptModelsGenerator typeScriptModelsGenerator = new TypeScriptModelsGenerator();

//typeScriptModelsGenerator.Generate(Assembly.GetAssembly(typeof(Tripparticipant)));

//TypeScriptGenerator tsg = new TypeScriptGenerator();

//tsg.GenerateTsModels(Assembly.GetAssembly(typeof(Dummy)));
//new SeedFriends().Insert();
Console.WriteLine("Warrior is done !");