using System.Collections.Generic;

namespace Toci.Driver.Common.Gatekeeper.Interfaces.Internationalization
{
    public interface ITranslation
    {
        Dictionary<string, string> GetTranslations(int idLanguage, List<string> phrases);
    }
}