using BAL_IK.Data.Interfaceler;
using BAL_IK.UI.Filters;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using static BAL_IK.Model.RequestClass.SiteYoneticisiIslemleriRequest;

namespace BAL_IK.UI.Areas.SirketYoneticisi.Controllers
{
    [Area("SiteYoneticisi")]
    [SiteYoneticisi]
    public class HomeController : Controller
    {
        private readonly ISiteYoneticisiService _siteyoneticisiService;
        private readonly IWebHostEnvironment _env;

        public HomeController(ISiteYoneticisiService siteyoneticisiService , IWebHostEnvironment env)
        {
            _siteyoneticisiService = siteyoneticisiService;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            var siteyoneticisiGuid = HttpContext.Session.GetString("siteYoneticisi");
            var resmitatiller = await ResmiTatillerGetir();
            return View(resmitatiller);
        }

        public IActionResult Profil()
        {
            var siteyoneticisiGuid = HttpContext.Session.GetString("siteYoneticisi");
            var response = _siteyoneticisiService.SiteYoneticisiGetir(siteyoneticisiGuid);
            return View(response);
        }

        public IActionResult Duzenle()
        {
            var siteyoneticisiGuid = HttpContext.Session.GetString("siteYoneticisi");
            var response = _siteyoneticisiService.SiteYoneticisiGetir(siteyoneticisiGuid);
            SiteYoneticisiGuncelle sygun = new SiteYoneticisiGuncelle();
            sygun.SiteYoneticisiId = response.SiteYoneticisiId;
            sygun.Ad = response.Ad;
            sygun.Soyad = response.Soyad;
            sygun.Eposta = response.Eposta;
            sygun.DogumTarihi = response.DogumTarihi;
            return View(sygun);
        }

        [HttpPost]
        public IActionResult Duzenle(SiteYoneticisiGuncelle sy)
        {
            var response = _siteyoneticisiService.SiteYoneticisiGuncelleme(sy);
            return RedirectToAction("Profil","Home");
        }



#region ResmiTatillerAPI
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
    }
    #endregion
}
