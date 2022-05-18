using BAL_IK.UI.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BAL_IK.UI.Areas.SirketYoneticisi.Controllers
{
    [Area("SiteYoneticisi")]
    //[SiteYoneticisi]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var siteyoneticisiGuid = HttpContext.Session.GetString("siteyoneticisi");

            return View();
        }

        public IActionResult Ayarlar()
        {
            return View();
        }
    }
}
