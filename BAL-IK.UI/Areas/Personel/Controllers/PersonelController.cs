using Microsoft.AspNetCore.Mvc;

namespace BAL_IK.UI.Areas.Personel.Controllers
{   
    [Area("Personel")]
    public class PersonelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
