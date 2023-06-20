using System.Linq.Expressions;
using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Common.Interfaces.ModelMapperInterfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic.DtoLogics;

public class ColourDtoLogic : DtoLogicBase< ColourModelDto , Colour , ColourLogic , ColourDto >
{
    public ColourDtoLogic(int id) 
        : base(new ColourLogic(), m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Colour = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Colour> GetDtoModelField(ColourDto dto)
    {
       return dto.Colour;
    }

    protected override ColourDto FillEntity(ColourDto dto, DtoBase<Colour> field)
    {
        dto.Colour = (ColourModelDto)field;

        return dto;
    }
}
