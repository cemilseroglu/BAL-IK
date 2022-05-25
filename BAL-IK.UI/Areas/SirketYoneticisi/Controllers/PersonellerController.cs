using BAL_IK.Data.Interfaceler.SirketYoneticisi;
using BAL_IK.UI.Filters;
using BAL_IK.UI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static BAL_IK.Model.RequestClass.SirketYoneticisiIslemleriRequest;
using static BAL_IK.Model.ResponseClass.PersonelIslemleriResponse;
using static BAL_IK.Model.RequestClass.PersonelIslemleriRequest;


namespace BAL_IK.UI.Areas.SirketYoneticisi.Controllers
{
    [SirketYoneticisi]
    [Area("SirketYoneticisi")]
    public class PersonellerController : Controller
    {
        private readonly ISirketYoneticisiServis _syServis;

        public PersonellerController(ISirketYoneticisiServis _syServis)
        {
            this._syServis = _syServis;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult HarcamalarYonetim()
        {
            var sirketYoneticisiGuid = HttpContext.Session.GetString("sirketYoneticisi");
            var response = _syServis.HarcamalariGetir(sirketYoneticisiGuid);
            return View(response);
        }
        public IActionResult BelgeGoruntule(string belge)
        {
            ViewBag.belge = belge;
            return View();
        }

        public IActionResult ZimmetYonetim()
        {
            var sirketYoneticisiGuid = HttpContext.Session.GetString("sirketYoneticisi");
            ZimmetSirketYoneticisiViewModel wmZimmet =new ZimmetSirketYoneticisiViewModel();
            wmZimmet.Personeller = _syServis.PersonelleriGetir().Personeller;
            wmZimmet.ZimmetTurleri=_syServis.ZimmetTurleriniGetir().ZimmetTurleri;
            wmZimmet.Zimmetler = _syServis.ZimmetleriGetir(sirketYoneticisiGuid).Zimmetler;
            
            return View(wmZimmet);
        }
        [HttpPost]
        public IActionResult ZimmetYonetim(ZimmetSirketYoneticisiViewModel wmZimmet)
        {
            ZimmetEkleRequest req = new ZimmetEkleRequest();
            req.PersonelId = wmZimmet.PersonelId;
            req.ZimmetTuruId = wmZimmet.ZimmetTurId;
            var response = _syServis.ZimmetEkle(req);
            return RedirectToAction("ZimmetYonetim");
        }

        //public IActionResult CalisanEkle()
        //{
        //    PersonelEkleResponse personelEkle = new PersonelEkleResponse();
        //    var personelGuid = HttpContext.Session.GetString("personel");
        //    var response = _syServis.PersonelGetir(personelGuid);


        //    return View();
        //}
        [HttpPost]
        public IActionResult CalisanEkle(PersonelEkle req)
        {
            PersonelEkleResponse personelEkle = new PersonelEkleResponse();
            personelEkle = _syServis.PersonelEklemeIslemi(req);
            //_syServis.
            


            return View();
        }
    }
}
