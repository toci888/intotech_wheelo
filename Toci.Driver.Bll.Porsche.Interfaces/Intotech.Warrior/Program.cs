// See https://aka.ms/new-console-template for more information
using Intotech.Wheelo.Social.Tests.Persistence.Seed;
using Intotech.Wheelo.Tests.Persistence.Seed;


Console.WriteLine("Warrior is seeding your dbs....");

new WheeloMainSeedManager().SeedAllDb();
new SocialSeedManager().SeedAllDb();

Console.WriteLine("Warrior is done !");