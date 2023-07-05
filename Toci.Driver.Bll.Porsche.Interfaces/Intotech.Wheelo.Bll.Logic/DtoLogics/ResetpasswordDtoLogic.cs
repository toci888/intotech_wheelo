usignsad

asdasdasd

public class ResetpasswordDtoLogic : DtoLogicBase<ResetpasswordModelDto, Resetpassword, IResetpasswordLogic, ResetpasswordDto, List<Resetpassword>, List<ResetpasswordModelDto>>
{
    public ResetpasswordDtoLogic(IResetpasswordLogic resetpasswordlogic) 
        : base(resetpasswordlogic, m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Resetpassword = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Resetpassword,ResetpasswordDto> GetDtoModelField(ResetpasswordDto dto)
    {
       return dto.Resetpassword;
    }

    protected override ResetpasswordDto FillEntity(ResetpasswordDto dto, DtoBase<Resetpassword> field)
    {
        dto.Resetpassword = (ResetpasswordModelDto)field;

        return dto;
    }
}
