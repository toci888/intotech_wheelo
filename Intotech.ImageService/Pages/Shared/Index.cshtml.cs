using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Intotech.ImageService.Pages
{
    public class IndexModel : PageModel
    {
        public byte[] ImageBase64 { get; set; } //string


    }
}