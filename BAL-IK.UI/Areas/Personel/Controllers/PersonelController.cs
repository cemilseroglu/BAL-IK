using BAL_IK.UI.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BAL_IK.UI.Areas.Personel.Controllers
{   
    [Area("Personel")]
    [Personel]
    public class PersonelController : Controller
    {
        public IActionResult Index()
        {
           var personelGuid= HttpContext.Session.GetString("personel");
         
            return View();
        }
    }
}
