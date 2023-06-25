using Intotech.Common.Bll.ChorDtoBll.Dto;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;

public class AccountmetadatumModelDto : DtoBase<Accountmetadatum, AccountmetadatumModelDto>
{
    public int Id { get; set; }
    public int Idaccount { get; set; }
    public int Gender { get; set; }
    public string Pesel { get; set; }
    public string Phone { get; set; }
    public int Idgeographicregion { get; set; }
    public int Idoccupation { get; set; }
    public Boolean Issmoker { get; set; }
    public Boolean Iswithanimals { get; set; }
    public string Metajson { get; set; }
    public DateTime Createdat { get; set; }
}
