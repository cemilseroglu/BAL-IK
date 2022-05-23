using BAL_IK.Data.Interfaceler.Personeller;
using BAL_IK.Model.ResponseClass;
using BAL_IK.UI.Filters;
using BAL_IK.UI.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
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


        public PersonelController(IPersonellerServis personelService, IWebHostEnvironment env)
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

        public async Task<IActionResult> Index()
        {
            var resmitatiller = await ResmiTatillerGetir();

            var personelGuid = HttpContext.Session.GetString("personel");
            var response = _personelService.PersonelGetir(personelGuid);
            TempData["isim"] = response.Ad;
            return View(resmitatiller);
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
            per.PersonelId = response.PersonelId;
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
            harcamaekle.HarcamaTutari = harcama.HarcamaTutari;
            harcamaekle.HarcamaIsmi = harcama.HarcamaIsmi;
            if (harcama.DosyaYolu != null)
            {
                harcamaekle.DosyaYolu = Tools.resimKaydet(harcama.DosyaYolu, _env);
            }
            var response = _personelService.HarcamaEkleme(harcamaekle);
            ViewBag.Mesaj = response.Mesaj;
            var resp = _personelService.HarcamalarıGetir();
            harcama.HarcamaListele = resp.HarcamaListele;
            return View(harcama);
        }
        #region
        public static async Task<GelenData> ResmiTatillerGetir()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.ubilisim.com/");
                var result = await client.GetAsync("resmitatiller");

                if (result.IsSuccessStatusCode)
                {
                    var data = await result.Content.ReadAsStringAsync();  //JSON formattan okuyacak hale getirdik.
                    var durum = JsonConvert.DeserializeObject<GelenData>(data);

                    return durum;

                }
                else
                    return null;
            }
        }

        public class GelenData
        {
            public bool success { get; set; }
            public string status { get; set; }
            public string pagecreatedate { get; set; }
            public List<ResmiTatiller> ResmiTatiller { get; set; }
        }

        public class ResmiTatiller
        {
            public string gun { get; set; }
            public string en { get; set; }
            public string haftagunu { get; set; }
            public string tarih { get; set; }
            public string uzuntarih { get; set; }

        }
    #endregion
       
    }


}

