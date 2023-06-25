using System.Linq.Expressions;
using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Common.Interfaces.ModelMapperInterfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic.DtoLogics;

public class VfriendsuggestionDtoLogic : DtoLogicBase< VfriendsuggestionModelDto , Vfriendsuggestion , VfriendsuggestionLogic , VfriendsuggestionDto >
{
    public VfriendsuggestionDtoLogic(int id) 
        : base(new VfriendsuggestionLogic(), m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Vfriendsuggestion = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Vfriendsuggestion> GetDtoModelField(VfriendsuggestionDto dto)
    {
       return dto.Vfriendsuggestion;
    }

    protected override VfriendsuggestionDto FillEntity(VfriendsuggestionDto dto, DtoBase<Vfriendsuggestion> field)
    {
        dto.Vfriendsuggestion = (VfriendsuggestionModelDto)field;

        return dto;
    }
}
