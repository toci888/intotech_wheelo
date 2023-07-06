using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic;

public class SimpleaccountDtoLogic : DtoLogicBase<SimpleaccountModelDto, Simpleaccount, ISimpleaccountLogic, SimpleaccountDto, List<Simpleaccount>, List<SimpleaccountModelDto>>
{
    public SimpleaccountDtoLogic(ISimpleaccountLogic simpleaccountlogic) 
        : base(simpleaccountlogic, 
            (aDto, aModelDto) => { 
                aDto.Simpleaccount = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Simpleaccount,SimpleaccountModelDto> GetDtoModelField(SimpleaccountDto dto)
    {
       return dto.Simpleaccount;
    }

    protected override SimpleaccountDto FillEntity(SimpleaccountDto dto, SimpleaccountModelDto  field)
    {
        dto.Simpleaccount = field;

        return dto;
    }    protected override SimpleaccountDto FillEntity(SimpleaccountDto dto, List<SimpleaccountModelDto> field)
    {
        throw new NotImplementedException();
    }
}
