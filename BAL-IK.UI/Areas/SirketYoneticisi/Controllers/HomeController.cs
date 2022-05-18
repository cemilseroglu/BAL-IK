using BAL_IK.Data.Interfaceler.SirketYoneticisi;
using BAL_IK.UI.Filters;
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
            return View();

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
    }


}
