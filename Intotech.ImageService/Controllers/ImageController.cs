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
        byte[] result = Convert.FromBase64String(imageBase64.Replace("data:image/jpeg;base64,", ""));
        
        Response.Headers.Add("Content-Type", "image/jpeg");
        
        return base.File(result, "image/jpeg");
    }
}