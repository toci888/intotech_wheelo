using System.Linq.Expressions;
using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Common.Interfaces.ModelMapperInterfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic.DtoLogics;

public class FriendsuggestionDtoLogic : DtoLogicBase< FriendsuggestionModelDto , Friendsuggestion , FriendsuggestionLogic , FriendsuggestionDto >
{
    public FriendsuggestionDtoLogic(int id) 
        : base(new FriendsuggestionLogic(), m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Friendsuggestion = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Friendsuggestion> GetDtoModelField(FriendsuggestionDto dto)
    {
       return dto.Friendsuggestion;
    }

    protected override FriendsuggestionDto FillEntity(FriendsuggestionDto dto, DtoBase<Friendsuggestion> field)
    {
        dto.Friendsuggestion = (FriendsuggestionModelDto)field;

        return dto;
    }
}
