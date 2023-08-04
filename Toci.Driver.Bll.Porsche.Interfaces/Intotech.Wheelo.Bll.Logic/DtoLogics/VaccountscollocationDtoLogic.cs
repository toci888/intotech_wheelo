using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Toci.Driver.Database.Persistence.Models;
using Intotech.Wheelo.Bll.Logic.Interfaces.DtoLogics;


namespace Intotech.Wheelo.Bll.Logic;


public class VaccountscollocationDtoLogic : DtoLogicBase<VaccountscollocationModelDto, Vaccountscollocation, IVaccountscollocationLogic, VaccountscollocationDto, List<Vaccountscollocation>, List<VaccountscollocationModelDto>>, IVaccountscollocationDtoLogic
{
    public VaccountscollocationDtoLogic(IVaccountscollocationLogic vaccountscollocationlogic) 
        : base(vaccountscollocationlogic, 
            (aDto, aModelDto) => { 
                aDto.Vaccountscollocation = aModelDto;
                return aDto;
            })
    {
    }

    protected override VaccountscollocationModelDto GetDtoModelField(VaccountscollocationDto dto)
    {
       return dto.Vaccountscollocation;
    }

    protected override VaccountscollocationDto FillEntity(VaccountscollocationDto dto, VaccountscollocationModelDto  field)
    {
        dto.Vaccountscollocation = field;

        return dto;
    }    protected override VaccountscollocationDto FillEntity(VaccountscollocationDto dto, List<VaccountscollocationModelDto> field)
    {
        throw new NotImplementedException();
    }
}
