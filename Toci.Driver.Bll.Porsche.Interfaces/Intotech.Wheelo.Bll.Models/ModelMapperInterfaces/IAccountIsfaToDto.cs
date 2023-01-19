using Intotech.Wheelo.Common.Interfaces.Models;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Common.Interfaces.ModelMapperInterfaces;

public interface IAccountIsfaToDto<TAccountSource, TAccountDto>
{
    TAccountDto Map(TAccountSource dbModel, int accountId);

    List<TAccountDto> Map(List<TAccountSource> associationsList, int accountId);
}