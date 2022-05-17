using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAL_IK.UI.Areas.SirketYoneticisi
{
    [Area("SirketYoneticisi")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Ayarlar()
        {
            return View();
        }
    }
}
