using Intotech.Wheelo.Common.ImageService;
using Intotech.Wheelo.Common.Interfaces.ModelMapperInterfaces;
using Intotech.Wheelo.Common.Interfaces.Models;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Models.ModelMappers;

public class VFriendsToFriendsDto : IAccountIsfaToDto<Vfriend, FriendsDto>
{
    public virtual FriendsDto Map(Vfriend dbModel, int accountId)
    {
        int accId = dbModel.Idaccount.Value;
        string name = dbModel.Name;
        string surname = dbModel.Surname;

        if (dbModel.Idaccount.Value == accountId)
        {
            accId = dbModel.Friendidaccount.Value;
            name = dbModel.Friendname;
            surname = dbModel.Friendsurname;
        }

        FriendsDto result = new FriendsDto()
        {
            idAccount = accId,
            Latitudefrom = dbModel.Latitudefrom.Value,
            Latitudeto = dbModel.Latitudeto.Value,
            Longitudefrom = dbModel.Longitudefrom.Value,
            Longitudeto = dbModel.Longitudeto.Value,
            Fromhour = dbModel.Fromhour.Value.ToString(),// TimeUtils.GetCorrectTime(dbModel.Fromhour.Value.Hour) + ":" + TimeUtils.GetCorrectTime(dbModel.Fromhour.Value.Minute),
            Tohour = dbModel.Tohour.Value.ToString(), //TimeUtils.GetCorrectTime(dbModel.Tohour.Value.Hour) + ":" + TimeUtils.GetCorrectTime(dbModel.Tohour.Value.Minute),
            Name = name,
            Surname = surname,
            Image = ImageServiceUtils.GetImageUrl(accId),
            Driver = dbModel.Driverpassenger.Value
        };

        return result;
    }

    public virtual List<FriendsDto> Map(List<Vfriend> associationsList, int accountId)
    {
        List<FriendsDto> result = new List<FriendsDto>();

        foreach (Vfriend item in associationsList)
        {
            result.Add(Map(item, accountId));
        }

        return result;
    }
}