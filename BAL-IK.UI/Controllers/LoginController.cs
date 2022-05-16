using BAL_IK.Data.Interfaceler.Site;
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
                return NotFound();
            if(response.BasariliMi==false)
            {
                ViewBag.Mesaj=response.Mesaj;
                return View(req);
            }
            else if(response.KullaniciTuru== "siteYoneticisi")
            {
                ViewBag.Mesaj = "Giriş yapan kullanıcı bir site yöneticisidir. Guidi: "+response.GirisGuid;
                return View(req);
            }
            else if (response.KullaniciTuru == "personel")
            {
                ViewBag.Mesaj = "Giriş yapan kullanıcı bir personeldir. Guidi: " + response.GirisGuid;
                return View(req);
            }
            else 
            {
                ViewBag.Mesaj = "Giriş yapan kullanıcı bir sirket Yoneticisidir. Guidi: " + response.GirisGuid;
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
