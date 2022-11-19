// See https://aka.ms/new-console-template for more information
using Intotech.ReflectiveTools.SourceGenerators.ModelsToTypescript;
using Intotech.Warrior;
using Intotech.Wheelo.Bll.Models.Social;
using Intotech.Wheelo.Social.Tests.Persistence.Seed;
using Intotech.Wheelo.Tests.Persistence.Seed;
using System.Reflection;
using Toci.Driver.Database.Persistence.Models;


//Console.WriteLine("Warrior is seeding your dbs....");

//new WheeloMainSeedManager().SeedAllDb();
new SocialSeedManager().SeedAllDb();


TypeScriptGenerator tsg = new TypeScriptGenerator();

tsg.GenerateTsModels(Assembly.GetAssembly(typeof(Dummy)));

Console.WriteLine("Warrior is done !");