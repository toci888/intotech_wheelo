// See https://aka.ms/new-console-template for more information
using Intotech.ReflectiveTools.SourceGenerators.ModelsToTypescript;
using Intotech.Warrior;
using Intotech.Wheelo.Bll.Models.Gaf;
using Intotech.Wheelo.Bll.Models.Social;
using Intotech.Wheelo.Bll.Porsche;
using Intotech.Wheelo.Bll.Porsche.Interfaces;
using Intotech.Wheelo.Bll.Porsche.User;
using Intotech.Wheelo.Social.Tests.Persistence.Seed;
using Intotech.Wheelo.Tests.Persistence.Seed;
using System.Reflection;
using Toci.Driver.Database.Persistence.Models;


Console.WriteLine("Warrior is seeding your dbs....");

//IGafManager gafManager = new GafManager();


//FacebookUserDto fbDto = new FacebookUserService().GetUserByToken("EAAWrqCc0xQYBAMCl0748zmQscSwuU7b6TkFL2aeIrIMyt0DiA3gxQVAVKMI2UGYmvbC6CzbuVwYYrUoY3nazXHZAVVKSQiXkBN96QeD834ZASn3YJXDs26spCHZBPvwuwuMFunPqrkeHxupc0mZCJ6NMpyPF4l4HnKJjOg0635pE8LUdGyE9njwFLjscfp0ZD");
//GoogleUserDto dto = new GoogleUserService().GetUserByToken("ya29.a0AeTM1ifhnlv61CrcLF13LfTZ32IuaoUnSvMvCqriiwLgX8sIGJmsyLFI9DRUxyyZc4OidrA83Dqs0MfF-BShtIsjxIFom6grHJpJs_msP5XZa_Y5mN_j2gHKlSLCKFleODI235_Qv-gT8Z6NbZGaF4VBxY32aCgYKAYMSARMSFQHWtWOm1x2JEJ44V7OR78PwhocQ4Q0163");

//Console.WriteLine(dto.verified_email);

//new SeedAccount().Insert();

//new SeedTrip().Insert();

//sa.Insert();
//new SeedFriendSuggestion().Insert();

new WheeloMainSeedManager().SeedAllDb();

//new SocialSeedManager().SeedAllDb();

//new ProfessionsTxtParser().Insert();

//new SeedTrip().Insert();
//new SeedTripParticipants().Insert();
//TypeScriptModelsGenerator typeScriptModelsGenerator = new TypeScriptModelsGenerator();

//typeScriptModelsGenerator.Generate(Assembly.GetAssembly(typeof(Tripparticipant)));

//TypeScriptGenerator tsg = new TypeScriptGenerator();

//tsg.GenerateTsModels(Assembly.GetAssembly(typeof(Dummy)));
//new SeedFriends().Insert();
Console.WriteLine("Warrior is done !");