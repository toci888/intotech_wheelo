using System.Linq.Expressions;
using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Common.Interfaces.ModelMapperInterfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic.DtoLogics;

public class FailedloginattemptDtoLogic : DtoLogicBase< FailedloginattemptModelDto , Failedloginattempt , FailedloginattemptLogic , FailedloginattemptDto >
{
    public FailedloginattemptDtoLogic(int id) 
        : base(new FailedloginattemptLogic(), m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Failedloginattempt = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Failedloginattempt> GetDtoModelField(FailedloginattemptDto dto)
    {
       return dto.Failedloginattempt;
    }

    protected override FailedloginattemptDto FillEntity(FailedloginattemptDto dto, DtoBase<Failedloginattempt> field)
    {
        dto.Failedloginattempt = (FailedloginattemptModelDto)field;

        return dto;
    }
}
