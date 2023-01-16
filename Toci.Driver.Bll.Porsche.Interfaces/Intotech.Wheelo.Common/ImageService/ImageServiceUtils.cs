using Intotech.Common;

namespace Intotech.Wheelo.Common.ImageService;

public static class ImageServiceUtils
{
    private const string Salt = "ItsForbiddenToLoadRandomImages";

    public static string GetImageUrl(int accountId)
    {
        string token = HashGenerator.Md5(string.Format("{0}_{1}", Salt, accountId));

        return "https://20.203.135.11:5072/image?dataId=" + accountId + "&queryValid=" + token;
    }
}