using BAL_IK.Data.Interfaceler.Site;
using BAL_IK.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using static BAL_IK.Model.ResponseClass.SiteIslemleriResponse;

namespace BAL_IK.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISiteLoginServis _Servis;

        public HomeController(ILogger<HomeController> logger, ISiteLoginServis _Servis)
        {
            _logger = logger;
            this._Servis = _Servis;
        }

        public IActionResult Index()
        {
            YorumlarResponse response = new YorumlarResponse();
            response = _Servis.YorumlariGetir();          
            return View(response);
        }

        public IActionResult YorumDetay(int SirketId)
        {
            var response = _Servis.YorumlariGetir();
            YorumResponse yorum=response.Yorumlar.FirstOrDefault(x=>x.SirketId==SirketId);
          
            return View(yorum);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
