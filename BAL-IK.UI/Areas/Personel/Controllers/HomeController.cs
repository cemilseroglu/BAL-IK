using Microsoft.AspNetCore.Mvc;

namespace BAL_IK.UI.Areas.Personel.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
