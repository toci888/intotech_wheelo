using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic;

public class EmailsregisterDtoLogic : DtoLogicBase<EmailsregisterModelDto, Emailsregister, IEmailsregisterLogic, EmailsregisterDto, List<Emailsregister>, List<EmailsregisterModelDto>>
{
    public EmailsregisterDtoLogic(IEmailsregisterLogic emailsregisterlogic) 
        : base(emailsregisterlogic, 
            (aDto, aModelDto) => { 
                aDto.Emailsregister = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Emailsregister,EmailsregisterModelDto> GetDtoModelField(EmailsregisterDto dto)
    {
       return dto.Emailsregister;
    }

    protected override EmailsregisterDto FillEntity(EmailsregisterDto dto, EmailsregisterModelDto  field)
    {
        dto.Emailsregister = field;

        return dto;
    }    protected override EmailsregisterDto FillEntity(EmailsregisterDto dto, List<EmailsregisterModelDto> field)
    {
        throw new NotImplementedException();
    }
}
