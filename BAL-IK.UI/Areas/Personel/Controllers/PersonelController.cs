using BAL_IK.Data.Interfaceler.Personeller;
using BAL_IK.UI.Filters;
using Microsoft.AspNetCore.Authentication.Cookies;
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
           var personelGuid= HttpContext.Session.GetString("personel");
            var response = _personelService.PersonelGetir(personelGuid);
            TempData["isim"] = response.Ad;
           return View();
        }

        public IActionResult Ayarlar()
        {

            var personelGuid = HttpContext.Session.GetString("personel");
            var response = _personelService.PersonelGetir(personelGuid);
            
            return View(response);
        }
        public IActionResult Duzenle()
        {
            var personelGuid = HttpContext.Session.GetString("personel");
            var response = _personelService.PersonelGetir(personelGuid);
            PersonelGuncelle per = new PersonelGuncelle();  
            per.PersonelId=response.PersonelId;
            per.Ad = response.Ad;
            per.Soyad = response.Soyad;
            per.Eposta = response.Eposta;
            return View(per);
        }
        [HttpPost]
        public IActionResult Duzenle(PersonelGuncelle pr)
        {
            var response = _personelService.PersonelGuncelleme(pr);
            ViewBag.Mesaj = response.Mesaj;
            return View();
        }
        [HttpGet]
        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("personel");
       
            return RedirectToAction("Index", "Home", new { Area = "" });
        }
        public IActionResult Harcamalar()
        {
            var personelGuid = HttpContext.Session.GetString("personel");
            var response = _personelService.PersonelGetir(personelGuid);
            HarcamaEkle per = new HarcamaEkle();
            per.PersonelId = response.PersonelId;
            return View(per);
        }
        [HttpPost]
        public IActionResult Harcamalar(HarcamaEkle pr)
        {
            var response= _personelService.HarcamaEkleme(pr);
            ViewBag.Mesaj = response.Mesaj;
            return View();
        }
    }
}
