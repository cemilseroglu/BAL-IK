using BAL_IK.Data.Interfaceler.SirketYoneticisi;
using BAL_IK.UI.Filters;
using BAL_IK.UI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BAL_IK.Model.RequestClass.SirketYoneticisiIslemleriRequest;

namespace BAL_IK.UI.Areas.SirketYoneticisi
{
    [Area("SirketYoneticisi")]
    [SirketYoneticisi]
    public class HomeController : Controller
    {
        private readonly ISirketYoneticisiServis _sirketYoneticisiServis;

        public HomeController(ISirketYoneticisiServis sirketYoneticisiServis)
        {
            _sirketYoneticisiServis = sirketYoneticisiServis;
        }
        public IActionResult Index()
        {
            var sirketYoneticisiGuid = HttpContext.Session.GetString("sirketYoneticisi");
            var response = _sirketYoneticisiServis.SirketYoneticisiGetir(sirketYoneticisiGuid);
            TempData["isim"] = response.Ad;
            SirketYoneticisiAnaSayfaWM wm = new SirketYoneticisiAnaSayfaWM();
            wm.GelenVeriler = _sirketYoneticisiServis.sirketVerileri(sirketYoneticisiGuid);
             wm.Personeller= _sirketYoneticisiServis.PersonelleriGetir(sirketYoneticisiGuid);
            wm.Harcamalar=_sirketYoneticisiServis.HarcamalariGetir(sirketYoneticisiGuid);


            return View(wm);

        }
        [HttpPost]

        public IActionResult Index(string guid)
        {
            var response = _sirketYoneticisiServis.SirketYoneticisiGetir(guid);
            if (response == null)
                return BadRequest();
            if (response.BasariliMi == false)
            {
                ViewBag.Mesaj = response.Mesaj;
                return View(guid);
            }
            return View();
        }
        public IActionResult Ayarlar()
        {
            var sirketYoneticisiGuid = HttpContext.Session.GetString("sirketYoneticisi");
            var response = _sirketYoneticisiServis.SirketYoneticisiGetir(sirketYoneticisiGuid);
            return View(response);
        }
        public IActionResult Duzenle()
        {
            var sirketYoneticisiGuid = HttpContext.Session.GetString("sirketYoneticisi");
            var response = _sirketYoneticisiServis.SirketYoneticisiGetir(sirketYoneticisiGuid);
            SirketYoneticisiGuncelle syg = new SirketYoneticisiGuncelle();
            syg.SirketYoneticisiId = response.SirketYoneticisiId;
            syg.Ad = response.Ad;
            syg.Soyad = response.Soyad;
            syg.Eposta = response.Eposta;
            return View(syg);
        }
        [HttpPost]
        public IActionResult Duzenle(SirketYoneticisiGuncelle guncelle)
        {
            var response = _sirketYoneticisiServis.SirketYoneticisiGuncelle(guncelle);
            ViewBag.Mesaj = response.Mesaj;
            return View();
        }
        public IActionResult Izinler()
        {
            return View();
        }

        public IActionResult SirketYorum()
        {
            var guid = HttpContext.Session.GetString("sirketYoneticisi");
            YorumEkleWM wM = new YorumEkleWM();
            wM.YorumResponse = _sirketYoneticisiServis.sirketYorumGetir(guid);
            return View(wM);
        }

        [HttpPost]
        public IActionResult SirketYorum(YorumEkleWM wM)
        {
            var guid = HttpContext.Session.GetString("sirketYoneticisi");
            YorumEkleRequest ekleReq=new YorumEkleRequest();
            ekleReq.SirketYoneticisiGuid = guid;
            ekleReq.YorumIcerik = wM.YorumResponse.YorumIcerik;
            ekleReq.YorumBaslik = wM.YorumResponse.YorumBaslik;
            var ekleResponse = _sirketYoneticisiServis.sirketYorum(ekleReq);
            if(ekleResponse.BasariliMi==false)
            {
                YorumGuncelleRequest guncelleReq = new YorumGuncelleRequest();
                guncelleReq.YorumIcerik = wM.YorumResponse.YorumIcerik;
                guncelleReq.YorumBaslik = wM.YorumResponse.YorumBaslik;
                guncelleReq.YorumId = wM.YorumResponse.YorumId;
                
                var guncelleResp = _sirketYoneticisiServis.sirketYorumGuncelle(guncelleReq);
            }
            wM.YorumResponse = _sirketYoneticisiServis.sirketYorumGetir(guid);
            return View(wM);
        }




        public IActionResult CikisYap()
        {
            HttpContext.Session.Remove("sirketYoneticisi");

            return RedirectToAction("Index", "Home", new { Area = "" });
        }

    }

}
