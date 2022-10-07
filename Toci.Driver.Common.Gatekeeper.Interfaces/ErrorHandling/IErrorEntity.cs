using System.Collections.Generic;

namespace Toci.Driver.Common.Gatekeeper.Interfaces.ErrorHandling
{
    public interface IErrorEntity
    {
        List<string> ApplicationErrorMessage { get; set; }

        List<string> UserErrorMessage { get; set; }
    }
}