using Microsoft.AspNetCore.Mvc;

namespace BAL_IK.UI.Areas.SirketYoneticisi
{
    [Area("SirketYoneticisi")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
