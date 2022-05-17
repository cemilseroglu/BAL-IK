using BAL_IK.Data.Interfaceler.Personeller;
using BAL_IK.UI.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static BAL_IK.Model.RequestClass.PersonelIslemleriRequest;

namespace BAL_IK.UI.Areas.Personel.Controllers
{   
    [Area("Personel")]
   // [Personel]
    public class PersonelController : Controller
    {

        private readonly IPersonellerServis _personelService;

        public PersonelController(IPersonellerServis personelService)
        {
            this._personelService = personelService;
        }
      [HttpPost]
        public IActionResult Index(string guid)
        {
            
            var response = _personelService.PersonelGetir(guid);
           
            if (response == null)
                return BadRequest();
            if (response.BasariliMi == false)
            {
                var personelGuid = HttpContext.Session.GetString("personel");
                ViewBag.Mesaj = response.Mesaj;
                return View(guid);
            }
            return View();
        }
    
        public IActionResult Index()
        {

           

           //var personelGuid= HttpContext.Session.GetString("personel");

           return View();
        }

        public IActionResult Ayarlar()
        {
            return View();
        }
        public IActionResult Duzenle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Duzenle(PersonelGuncelle pr)
        {
            var response = _personelService.PersonelGuncelleme(pr);
            ViewBag.Mesaj = response.Mesaj;
            return View();
        }

    }
}
