using Intotech.Common.Bll.ComplexResponses;
using Intotech.Wheelo.Bll.Models.OldModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Bll.Porsche.Interfaces.User
{
    public interface IAccountMetadataService
    {
        ReturnedResponse<AccountMetadataDto> Create(AccountMetadataDto accountMetaDto);

        ReturnedResponse<AccountMetadataDto> Update(AccountMetadataDto accountMetaDto);
    }
}
