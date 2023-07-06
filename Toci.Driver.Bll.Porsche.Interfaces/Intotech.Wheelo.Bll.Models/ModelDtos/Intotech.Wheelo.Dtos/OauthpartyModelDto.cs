using Intotech.Common.Bll.ChorDtoBll.Dto;
using Toci.Driver.Database.Persistence.Models;


namespace Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;

public class OauthpartyModelDto : DtoCollectionBase<Oauthparty, OauthpartyModelDto, List<Oauthparty>, List<OauthpartyModelDto>>
{
    public int Id { get; set; }
    public string Name { get; set; }
}
