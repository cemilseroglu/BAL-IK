using BAL_IK.Data.Interfaceler.SirketYoneticisi;
using BAL_IK.Data.Interfaceler.Site;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static BAL_IK.Model.RequestClass.LogIslemleriRequest;
using static BAL_IK.Model.RequestClass.SirketYoneticisiIslemleriRequest;

namespace BAL_IK.UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly ISiteLoginServis _loginService;
        private readonly ISirketYoneticisiServis _syService;

        public LoginController(ISiteLoginServis loginService, ISirketYoneticisiServis syService)
        {
            _loginService = loginService;
            this._syService = syService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(LogKullanici req)
        {
            //TODO Yönlendirmeler yapılacak.
            var response = _loginService.LoginIslemi(req);
            if (response == null)
                return BadRequest();
            if (response.BasariliMi == false)
            {
                ViewBag.Mesaj = response.Mesaj;
                return View(req);
            }
            else if (response.KullaniciTuru == "siteYoneticisi")
            {
                HttpContext.Session.SetString("siteYoneticisi", response.GirisGuid);
                return RedirectToAction("Index", "Home", new { area = "SiteYoneticisi" });
            }
            else if (response.KullaniciTuru == "personel")
            {
                HttpContext.Session.SetString("personel", response.GirisGuid);
                return RedirectToAction("Index", "Personel", new { area = "Personel" });
            }
            else
            {
                HttpContext.Session.SetString("sirketYoneticisi", response.GirisGuid);

                var responseSy= _syService.SirketYoneticisiGetir(response.GirisGuid);
                if(responseSy.SirketId==null)
                {
                    return RedirectToAction("Index", "Sirket");
                }            

                return RedirectToAction("Index", "Home", new { area = "SirketYoneticisi" });  

            }

        }
        public IActionResult KayitOl()
        {
            return View();
        }
        [HttpPost]
        public IActionResult KayitOl(KayitKullaniciReq req)
        {
            var response = _loginService.KayitIslemi(req);
            ViewBag.Mesaj = response.Mesaj;
            return View();
        }
        public IActionResult Aktivasyon(string guid)
        {
            var response = _syService.SirketYoneticisiGetir(guid);
            SirketYoneticisiGuncelle sirketYoneticisi = new SirketYoneticisiGuncelle();
            sirketYoneticisi.SirketYoneticisiId = response.SirketYoneticisiId;
            sirketYoneticisi.AktifMi = true;
            var responseGuncel = _syService.SirketYoneticisiGuncelle(sirketYoneticisi);
            if (response.BasariliMi != true || responseGuncel.BasariliMi != true)
            {
                ViewBag.Mesaj = "Aktivasyon sırasında bir hata oluştu";
                ViewBag.Onay = false;
            }
            else
            {
                ViewBag.Mesaj = "Merhaba Sayın " + response.Ad + " hesabınız aktif edilmiştir. Giriş Yapabilirsiniz.";
                ViewBag.Onay = true;
            }
            return View();
        }
    }
}
