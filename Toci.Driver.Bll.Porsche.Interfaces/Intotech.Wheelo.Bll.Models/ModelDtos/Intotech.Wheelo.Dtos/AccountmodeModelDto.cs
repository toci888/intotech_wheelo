using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Common.Bll.Interfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;


public class AccountmodeModelDto : DtoModelBase
{
    public int Idaccount { get; set; }
    public int Mode { get; set; }
    public int Id { get; set; }
}
