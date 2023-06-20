using System.Linq.Expressions;
using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Common.Interfaces.ModelMapperInterfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic.DtoLogics;

public class VcarownerDtoLogic : DtoLogicBase< VcarownerModelDto , Vcarowner , VcarownerLogic , VcarownerDto >
{
    public VcarownerDtoLogic(int id) 
        : base(new VcarownerLogic(), m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Vcarowner = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Vcarowner> GetDtoModelField(VcarownerDto dto)
    {
       return dto.Vcarowner;
    }

    protected override VcarownerDto FillEntity(VcarownerDto dto, DtoBase<Vcarowner> field)
    {
        dto.Vcarowner = (VcarownerModelDto)field;

        return dto;
    }
}
