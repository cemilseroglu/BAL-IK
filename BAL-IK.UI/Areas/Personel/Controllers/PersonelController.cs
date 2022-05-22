using BAL_IK.Data.Interfaceler.Personeller;
using BAL_IK.Model.ResponseClass;
using BAL_IK.UI.Filters;
using BAL_IK.UI.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static BAL_IK.Model.RequestClass.PersonelIslemleriRequest;
using static BAL_IK.Model.ResponseClass.PersonelIslemleriResponse;

namespace BAL_IK.UI.Areas.Personel.Controllers
{   
    [Area("Personel")]
   // [Personel]
    public class PersonelController : Controller
    {

        private readonly IPersonellerServis _personelService;
        private readonly IWebHostEnvironment _env;
     

        public PersonelController(IPersonellerServis personelService , IWebHostEnvironment env)
        {
            this._personelService = personelService;
            this._env = env;
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
            HarcamaListelemeResponse harcamaListesi = new HarcamaListelemeResponse();
            harcamaListesi = _personelService.HarcamalarıGetir();
            var personelGuid = HttpContext.Session.GetString("personel");
            var response = _personelService.PersonelGetir(personelGuid);
            HarcamaViewModel harcama = new HarcamaViewModel();
            harcama.PersonelId = response.PersonelId;
            var resp = _personelService.HarcamalarıGetir();
            harcama.HarcamaListele = resp.HarcamaListele;
         
            return View(harcama);
        }
        [HttpPost]
        public IActionResult Harcamalar(HarcamaViewModel harcama)
        {
            var harcamaListesi = _personelService.HarcamalarıGetir();
            HarcamaEkle harcamaekle = new HarcamaEkle();
            harcamaekle.PersonelId = harcama.PersonelId;
                harcamaekle.HarcamaTutari=harcama.HarcamaTutari;
            harcamaekle.HarcamaIsmi=harcama.HarcamaIsmi;
            if (harcama.DosyaYolu != null)
            {
                harcamaekle.DosyaYolu = Tools.resimKaydet(harcama.DosyaYolu, _env);
            }
            var response= _personelService.HarcamaEkleme(harcamaekle);
            ViewBag.Mesaj = response.Mesaj;
            var resp = _personelService.HarcamalarıGetir();
            harcama.HarcamaListele = resp.HarcamaListele;
            return View(harcama);
        }
        

    }
}
