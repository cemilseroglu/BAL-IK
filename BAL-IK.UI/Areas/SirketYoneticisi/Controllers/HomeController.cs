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

        public IActionResult Index()
        {
            //var sirketYoneticisiGuid = HttpContext.Session.GetString("sirketYoneticisi");
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
