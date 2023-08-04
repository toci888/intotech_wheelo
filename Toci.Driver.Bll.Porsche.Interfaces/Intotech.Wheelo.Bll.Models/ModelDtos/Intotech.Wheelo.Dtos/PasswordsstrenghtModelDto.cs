using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Common.Bll.Interfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;


public class PasswordsstrenghtModelDto : DtoModelBase
{
    public int Id { get; set; }
    public int Idaccount { get; set; }
    public int Level { get; set; }
}
