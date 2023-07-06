using Intotech.Common.Bll.ChorDtoBll.Dto;
using Toci.Driver.Database.Persistence.Models;


namespace Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;

public class PasswordsstrenghtModelDto : DtoCollectionBase<Passwordsstrenght, PasswordsstrenghtModelDto, List<Passwordsstrenght>, List<PasswordsstrenghtModelDto>>
{
    public int Id { get; set; }
    public int Idaccount { get; set; }
    public int Level { get; set; }
}
