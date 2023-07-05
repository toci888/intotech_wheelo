using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic;

public class OauthpartyDtoLogic : DtoLogicBase<OauthpartyModelDto, Oauthparty, IOauthpartyLogic, OauthpartyDto, List<Oauthparty>, List<OauthpartyModelDto>>
{
    public OauthpartyDtoLogic(IOauthpartyLogic oauthpartylogic) 
        : base(oauthpartylogic, 
            (aDto, aModelDto) => { 
                aDto.Oauthparty = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Oauthparty,OauthpartyModelDto> GetDtoModelField(OauthpartyDto dto)
    {
       return dto.Oauthparty;
    }

    protected override OauthpartyDto FillEntity(OauthpartyDto dto, OauthpartyModelDto  field)
    {
        dto.Oauthparty = field;

        return dto;
    }    protected override OauthpartyDto FillEntity(OauthpartyDto dto, List<OauthpartyModelDto> field)
    {
        throw new NotImplementedException();
    }
}
