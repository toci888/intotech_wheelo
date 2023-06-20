using System.Linq.Expressions;
using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Common.Interfaces.ModelMapperInterfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic.DtoLogics;

public class OauthpartyDtoLogic : DtoLogicBase< OauthpartyModelDto , Oauthparty , OauthpartyLogic , OauthpartyDto >
{
    public OauthpartyDtoLogic(int id) 
        : base(new OauthpartyLogic(), m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Oauthparty = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Oauthparty> GetDtoModelField(OauthpartyDto dto)
    {
       return dto.Oauthparty;
    }

    protected override OauthpartyDto FillEntity(OauthpartyDto dto, DtoBase<Oauthparty> field)
    {
        dto.Oauthparty = (OauthpartyModelDto)field;

        return dto;
    }
}
