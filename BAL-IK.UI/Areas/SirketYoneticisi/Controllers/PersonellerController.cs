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
            wmZimmet.Personeller = _syServis.PersonelleriGetir(sirketYoneticisiGuid).Personeller;
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

        public IActionResult VardiyaTur()
        {
            var sirketYoneticisiGuid = HttpContext.Session.GetString("sirketYoneticisi");
            VardiyaTurSirketYoneticisiVM wm = new VardiyaTurSirketYoneticisiVM();
            wm.VardiyaTurRequestVM.SirketYoneticisiGuid = sirketYoneticisiGuid;
            wm.VardiyaTurleri = _syServis.VardiyaTurleriGetir(sirketYoneticisiGuid).VardiyaTurleri;
            return View(wm);
        }
        [HttpPost]
        public IActionResult VardiyaTur(VardiyaTurSirketYoneticisiVM wm)
        {
            var sirketYoneticisiGuid = HttpContext.Session.GetString("sirketYoneticisi");
            wm.VardiyaTurRequestVM.SirketYoneticisiGuid = sirketYoneticisiGuid;
            var response = _syServis.VardiyaTurEkle(wm.VardiyaTurRequestVM);
            wm.VardiyaTurleri = _syServis.VardiyaTurleriGetir(sirketYoneticisiGuid).VardiyaTurleri;
            ViewBag.Sonuc = response.Mesaj;
           return View(wm);
        }
        public IActionResult MolaTur()
        {
            var sirketYoneticisiGuid = HttpContext.Session.GetString("sirketYoneticisi");
            MolaTurSirketYoneticiWM wm = new MolaTurSirketYoneticiWM();
            wm.MolaTurleri = _syServis.MolaTurleriGetir(sirketYoneticisiGuid).MolaTurleri;
            return View(wm);
        }
        [HttpPost]
        public IActionResult MolaTur(MolaTurSirketYoneticiWM wm)
        {
            var sirketYoneticisiGuid = HttpContext.Session.GetString("sirketYoneticisi");
            wm.MolaTur.SirketYoneticisiGuid = sirketYoneticisiGuid;
            var response = _syServis.MolaTurEkle(wm.MolaTur);
            ViewBag.Sonuc = response.Mesaj;
            wm.MolaTurleri = _syServis.MolaTurleriGetir(sirketYoneticisiGuid).MolaTurleri;
            return View(wm);
        }              
        public IActionResult CalisanMolaVardiya()
        {
            var sirketYoneticisiGuid = HttpContext.Session.GetString("sirketYoneticisi");
            CalisaVardiyaEkleWM wm=new CalisaVardiyaEkleWM();
            wm.MolaTurleri = _syServis.MolaTurleriGetir(sirketYoneticisiGuid).MolaTurleri;
            wm.VardiyaTurleri = _syServis.VardiyaTurleriGetir(sirketYoneticisiGuid).VardiyaTurleri;
            wm.Personeller = _syServis.PersonelleriGetir(sirketYoneticisiGuid).Personeller;
            return View(wm);
        }
        [HttpPost]
        public IActionResult CalisanMolaVardiya(CalisaVardiyaEkleWM wm)
        {
            CalisanVardiyaMolaEkleRequest req = new CalisanVardiyaMolaEkleRequest();
            req.VardiyaTurId = wm.VardiyaTurId;
            req.MolaTurIds = wm.MolaTurIds;
            req.PersonelId = wm.PersonelId;
            var response = _syServis.CalisanVardiyaEkle(req);
            ViewBag.Sonuc = response.Mesaj;
            return RedirectToAction("CalisanMolaVardiya");
        }
      
    }
}
