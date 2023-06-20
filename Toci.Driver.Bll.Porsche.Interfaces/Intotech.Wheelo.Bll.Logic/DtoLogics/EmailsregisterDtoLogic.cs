﻿using System.Linq.Expressions;
using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Common.Interfaces.ModelMapperInterfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic.DtoLogics;

public class EmailsregisterDtoLogic : DtoLogicBase< EmailsregisterModelDto , Emailsregister , EmailsregisterLogic , EmailsregisterDto >
{
    public EmailsregisterDtoLogic(int id) 
        : base(new EmailsregisterLogic(), m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Emailsregister = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Emailsregister> GetDtoModelField(EmailsregisterDto dto)
    {
       return dto.Emailsregister;
    }

    protected override EmailsregisterDto FillEntity(EmailsregisterDto dto, DtoBase<Emailsregister> field)
    {
        dto.Emailsregister = (EmailsregisterModelDto)field;

        return dto;
    }
}
