usignsad

asdasdasd

public class NotuserDtoLogic : DtoLogicBase<NotuserModelDto, Notuser, INotuserLogic, NotuserDto, List<Notuser>, List<NotuserModelDto>>
{
    public NotuserDtoLogic(INotuserLogic notuserlogic) 
        : base(notuserlogic, m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Notuser = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Notuser,NotuserDto> GetDtoModelField(NotuserDto dto)
    {
       return dto.Notuser;
    }

    protected override NotuserDto FillEntity(NotuserDto dto, DtoBase<Notuser> field)
    {
        dto.Notuser = (NotuserModelDto)field;

        return dto;
    }
}
