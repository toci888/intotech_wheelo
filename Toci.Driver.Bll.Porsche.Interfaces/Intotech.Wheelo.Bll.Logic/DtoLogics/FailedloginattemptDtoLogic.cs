usignsad

asdasdasd

public class FailedloginattemptDtoLogic : DtoLogicBase<FailedloginattemptModelDto, Failedloginattempt, IFailedloginattemptLogic, FailedloginattemptDto, List<Failedloginattempt>, List<FailedloginattemptModelDto>>
{
    public FailedloginattemptDtoLogic(IFailedloginattemptLogic failedloginattemptlogic) 
        : base(failedloginattemptlogic, m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Failedloginattempt = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Failedloginattempt,FailedloginattemptDto> GetDtoModelField(FailedloginattemptDto dto)
    {
       return dto.Failedloginattempt;
    }

    protected override FailedloginattemptDto FillEntity(FailedloginattemptDto dto, DtoBase<Failedloginattempt> field)
    {
        dto.Failedloginattempt = (FailedloginattemptModelDto)field;

        return dto;
    }
}
