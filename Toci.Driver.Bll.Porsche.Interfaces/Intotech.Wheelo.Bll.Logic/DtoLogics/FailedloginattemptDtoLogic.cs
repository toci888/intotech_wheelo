using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic;

public class FailedloginattemptDtoLogic : DtoLogicBase<FailedloginattemptModelDto, Failedloginattempt, IFailedloginattemptLogic, FailedloginattemptDto, List<Failedloginattempt>, List<FailedloginattemptModelDto>>
{
    public FailedloginattemptDtoLogic(IFailedloginattemptLogic failedloginattemptlogic) 
        : base(failedloginattemptlogic, 
            (aDto, aModelDto) => { 
                aDto.Failedloginattempt = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Failedloginattempt,FailedloginattemptModelDto> GetDtoModelField(FailedloginattemptDto dto)
    {
       return dto.Failedloginattempt;
    }

    protected override FailedloginattemptDto FillEntity(FailedloginattemptDto dto, FailedloginattemptModelDto  field)
    {
        dto.Failedloginattempt = field;

        return dto;
    }    protected override FailedloginattemptDto FillEntity(FailedloginattemptDto dto, List<FailedloginattemptModelDto> field)
    {
        throw new NotImplementedException();
    }
}
