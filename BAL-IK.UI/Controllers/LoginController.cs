using BAL_IK.Data.Interfaceler.Site;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static BAL_IK.Model.RequestClass.LogIslemleriRequest;
namespace BAL_IK.UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly ISiteLoginServis _loginService;

        public LoginController(ISiteLoginServis loginService)
        {
            _loginService = loginService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(LogKullanici req)
        {
            //TODO Yönlendirmeler yapılacak.
            var response=_loginService.LoginIslemi(req);
            if(response==null)
                return BadRequest();
            if(response.BasariliMi==false)
            {
                ViewBag.Mesaj=response.Mesaj;
                return View(req);
            }
            else if(response.KullaniciTuru== "siteYoneticisi")
            {
                HttpContext.Session.SetString("siteYoneticisi", response.GirisGuid);
                return View(req);//site yöneticisi ındexe yonlendirilecek
            }
            else if (response.KullaniciTuru == "personel")
            {
                HttpContext.Session.SetString("personel", response.GirisGuid);
                return RedirectToAction("Index", "Personel", new { area = "Personel" });
            }
            else 
            {
                HttpContext.Session.SetString("sirketYoneticisi", response.GirisGuid);
                return View(req);
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
    }
}
