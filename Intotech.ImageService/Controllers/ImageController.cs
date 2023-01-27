using System.Collections.Specialized;
using Intotech.ImageService.Pages;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.ImageService.Bll;
using Microsoft.Extensions.Primitives;
using Org.BouncyCastle.Utilities;
//using static System.Net.Mime.MediaTypeNames;
using System.Drawing;

namespace Intotech.ImageService.Controllers;

[Controller]
//[Route("/")]
public class ImageController : Controller
{
    private const string QsDataId = "dataId";
    private const string QsType = "type";
    private const string QsQueryValid = "queryValid";
    private string DefaultImage = "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";

    protected ImageRetrieveLogic ImageRetrieveLogic;

    public ImageController()
    {
        ImageRetrieveLogic = new ImageRetrieveLogic(new AccountLogic()); // skipping di for now
    }
    // GET
    [Route("image")]
    public ActionResult Index()
    {
        NameValueCollection queryStringData = HttpUtility.ParseQueryString(Request.QueryString.Value);

        string dataId = queryStringData[QsDataId];
        
        int accountId = int.Parse(dataId);

        string imageBase64 = ImageRetrieveLogic.GetImageForUser(accountId, queryStringData[QsQueryValid]);

        byte[] result;

        if (string.IsNullOrEmpty(imageBase64))
        {
            result = Convert.FromBase64String(DefaultImage);
        }
        else
        {
            result = Convert.FromBase64String(imageBase64.Replace("data:image/jpeg;base64,", ""));
        }

        Response.Headers.Add("Content-Type", "image/jpeg");
        
        return base.File(result, "image/jpeg");
    }
}