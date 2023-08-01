// See https://aka.ms/new-console-template for more information
using Intotech.ReflectiveTools.SourceGenerators.ModelsToTypescript;
using Intotech.Warrior;
using Intotech.Wheelo.Bll.Models.Gaf;
using Intotech.Wheelo.Bll.Models.Social;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Bll.Porsche;
using Intotech.Wheelo.Bll.Porsche.Interfaces;
using Intotech.Wheelo.Bll.Porsche.User;
using Intotech.Wheelo.Chat.Tests.Persistence.Seed;
using Intotech.Wheelo.Common.Interfaces.Models;
using Intotech.Wheelo.Social.Tests.Persistence.Seed;
using Intotech.Wheelo.Tests.Persistence.Seed;
using System.Reflection;
using Intotech.Wheelo.Proxies.IntotechWheeloApi;
using Intotech.Wheelo.Proxies.IntotechWheeloApi.Models;
using Toci.Driver.Database.Persistence.Models;
using Intotech.Common;
using Intotech.Wheelo.Common.Translations.Translation;

Console.WriteLine("Warrior is seeding your dbs....");


TranslationRendererRunner runner = new TranslationRendererRunner();

runner.Run("C:\\Users\\stasx\\Documents\\GitHub\\intotech_wheelo\\Toci.Driver.Bll.Porsche.Interfaces\\Intotech.Wheelo.Common\\Translations\\");


//Accountmode accountmode = new Accountmode() { Idaccount = 2, Mode = 1 };

//Role? role = new Role() { Name = "vasia", Id = 7};

//Account account = new() { Id = 0, Name = "Vasyl", Email = "Grzesiek221@gmail.com", Accountmode = accountmode, IdroleNavigation = role };

//Accountmetadatum accountmetadatum = new() { Id = 1, Idaccount = 2, Pesel = "0013102301203", Phone = "+48531933123", IdaccountNavigation = account };

//object[] details = new object[] { account, accountmetadatum };

//ErrorLoggerDefault logger = new ErrorLoggerDefault();
//    logger.Log("", LogLevels.Debug, details);


// ? 

/*AccountProxy ap = new AccountProxy();
 
AccountRegisterResponseDto registerResult = ap.Register(new AccountRegisterDto() { email = "glockajulia@gmail.com", firstName = "Julia", lastName = "Głocka", password = "Beatka123()" });
int a = 0;
*/

//new SeedRole().Insert();

//UsersCollocationLogic uc = new UsersCollocationLogic();

//uc.DeleteByColumnId("Idaccount", 1000000014);
//new SocialSeedManager().SeedAllDb();

//new WheeloMainSeedManager().SeedAllDb();

//

//Service serv = new Service();
//serv.Listen();


//GoogleMapsClient googleMapsClient = new GoogleMapsClient(); //ChIJ0eZpEy9FBEcRieu3xGIT0wc

//GoogleService googleService = new GoogleService();

//var doopa = googleService.GetLocationByPlaceId("ChIJ0eZpEy9FBEcRieu3xGIT0wc");

//GooglePlaceGeoModel model = googleMapsClient.CallGoogleApiPlaceId("ChIJ0eZpEy9FBEcRieu3xGIT0wc");

//int i = 0;

//IGafManager gafManager = new GafManager();


//FacebookUserDto fbDto = new FacebookUserService().GetUserByToken("EAAWrqCc0xQYBAMCl0748zmQscSwuU7b6TkFL2aeIrIMyt0DiA3gxQVAVKMI2UGYmvbC6CzbuVwYYrUoY3nazXHZAVVKSQiXkBN96QeD834ZASn3YJXDs26spCHZBPvwuwuMFunPqrkeHxupc0mZCJ6NMpyPF4l4HnKJjOg0635pE8LUdGyE9njwFLjscfp0ZD");
//GoogleUserDto dto = new GoogleUserService().GetUserByToken("ya29.a0AeTM1ifhnlv61CrcLF13LfTZ32IuaoUnSvMvCqriiwLgX8sIGJmsyLFI9DRUxyyZc4OidrA83Dqs0MfF-BShtIsjxIFom6grHJpJs_msP5XZa_Y5mN_j2gHKlSLCKFleODI235_Qv-gT8Z6NbZGaF4VBxY32aCgYKAYMSARMSFQHWtWOm1x2JEJ44V7OR78PwhocQ4Q0163");

//Console.WriteLine(dto.verified_email);

//new SeedAccount().Insert();

//new SeedTrip().Insert();

//sa.Insert();
//new SeedFriendSuggestion().Insert();



//new ProfessionsTxtParser().Insert();

//new SeedTrip().Insert();
//new SeedTripParticipants().Insert();
//TypeScriptModelsGenerator typeScriptModelsGenerator = new TypeScriptModelsGenerator();

//typeScriptModelsGenerator.Generate(Assembly.GetAssembly(typeof(Tripparticipant)));

//TypeScriptGenerator tsg = new TypeScriptGenerator();

//tsg.GenerateTsModels(Assembly.GetAssembly(typeof(Dummy)));
//new SeedFriends().Insert();
Console.WriteLine("Warrior is done !");