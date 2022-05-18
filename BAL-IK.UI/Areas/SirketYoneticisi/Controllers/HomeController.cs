using BAL_IK.Data.Interfaceler.SirketYoneticisi;
using BAL_IK.UI.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAL_IK.UI.Areas.SirketYoneticisi
{
    [Area("SirketYoneticisi")]
    //[SirketYoneticisi]
    public class HomeController : Controller
    {
        private readonly ISirketYoneticisiServis _sirketYoneticisiServis;

        public HomeController(ISirketYoneticisiServis sirketYoneticisiServis)
        {
            _sirketYoneticisiServis = sirketYoneticisiServis;
        }
        public IActionResult Index()
        {
            //var sirketYoneticisiGuid = HttpContext.Session.GetString("sirketYoneticisi");
            return View();
        }       
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
            return View();
        }
        public IActionResult Duzenle()
        {
            return View();
        }
    }


}
