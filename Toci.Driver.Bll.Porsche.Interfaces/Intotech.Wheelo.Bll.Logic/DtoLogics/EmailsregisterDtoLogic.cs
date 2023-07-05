usignsad

asdasdasd

public class EmailsregisterDtoLogic : DtoLogicBase<EmailsregisterModelDto, Emailsregister, IEmailsregisterLogic, EmailsregisterDto, List<Emailsregister>, List<EmailsregisterModelDto>>
{
    public EmailsregisterDtoLogic(IEmailsregisterLogic emailsregisterlogic) 
        : base(emailsregisterlogic, m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Emailsregister = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Emailsregister,EmailsregisterDto> GetDtoModelField(EmailsregisterDto dto)
    {
       return dto.Emailsregister;
    }

    protected override EmailsregisterDto FillEntity(EmailsregisterDto dto, DtoBase<Emailsregister> field)
    {
        dto.Emailsregister = (EmailsregisterModelDto)field;

        return dto;
    }
}
