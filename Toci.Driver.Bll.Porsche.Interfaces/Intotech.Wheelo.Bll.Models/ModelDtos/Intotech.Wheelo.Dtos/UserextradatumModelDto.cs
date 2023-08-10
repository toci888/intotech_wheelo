using Intotech.Common.Bll.ChorDtoBll.Dto;
using Toci.Driver.Database.Persistence.Models;


namespace Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;

public class UserextradatumModelDto : DtoCollectionBase<Userextradatum, UserextradatumModelDto, List<Userextradatum>, List<UserextradatumModelDto>>
{
    public int Id { get; set; }
    public int Idaccount { get; set; }
    public string Token { get; set; }
    public string Method { get; set; }
    public string Tokendatajson { get; set; }
    public int Origin { get; set; }
    public DateTime Createdat { get; set; }
}
