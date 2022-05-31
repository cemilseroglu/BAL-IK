using BAL_IK.Data.Interfaceler.SirketYoneticisi;
using BAL_IK.UI.Filters;
using BAL_IK.UI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static BAL_IK.Model.RequestClass.SirketYoneticisiIslemleriRequest;
using static BAL_IK.Model.ResponseClass.PersonelIslemleriResponse;
using static BAL_IK.Model.RequestClass.PersonelIslemleriRequest;
using BAL_IK.Model.Entities;

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
        public IActionResult CalisanEkle()
        {

            return View();
        }
        [HttpPost]
        public IActionResult CalisanEkle(PersonelEkle req)
        {
            Personeller pers = new Personeller();
            pers.Ad = req.Ad;
            pers.Soyad = req.Soyad;
            pers.Cinsiyet = req.Cinsiyet;
            pers.DogumTarihi = req.DogumTarihi;
            pers.Eposta = req.Eposta;
            pers.IseBaslama = req.IseBaslama;
            pers.SirketId = req.SirketId;
            pers.TemelMaasBilgisi = req.TemelMaasBilgisi;
            var resp = _syServis.PersonelEklemeIslemi(req);
            return RedirectToAction("CalisanSayfasi");
        }
        public IActionResult CalisanSayfasi()
        {
            var resp = _syServis.PersonelleriGetir();

            return View(resp);
        }
        public IActionResult CalisanGuncelle(string guid)
        {
            var resp = _syServis.PersGetir(guid);
            PersonelGuncelle pers = new PersonelGuncelle();
            pers.PersonelId = resp.PersonelId;
            pers.Ad = resp.Ad;
            pers.Soyad = resp.Soyad;
            pers.DogumTarihi = resp.DogumTarihi;
            pers.Cinsiyet = resp.Cinsiyet;
            pers.Eposta = resp.Eposta;
            pers.AktifMi = resp.AktifMi;
            pers.TemelMaasBilgisi = resp.TemelMaasBilgisi;
            return View(pers);
        }

        [HttpPost]
        public IActionResult CalisanGuncelle(PersonelGuncelle pers)
        {
            var resp = _syServis.PersonelGuncelleme(pers);
            return RedirectToAction("CalisanSayfasi");
        }
        public IActionResult CalisanSil()
        {
            
            return View();
        }

        [HttpGet]
        public IActionResult CalisanSil(int personelId)
        {
            var resp = _syServis.PersonelSil(personelId);
            return RedirectToAction("CalisanSayfasi");
        }
        public IActionResult OzlukBelgesiEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult OzlukBelgesiEkle(OzlukBelgesiEkle req)
        {
            OzlukBelgesi ozluk = new OzlukBelgesi();
            ozluk.OzlukBelgesiAdi = req.OzlukBelgesiAdi;
            ozluk.OzlukBelgesiYolu = req.OzlukBelgesiYolu;
            ozluk.PersonelId = req.PersonelId;
            ozluk.SirketYoneticisiId = req.SirketYoneticisiId;
            ozluk.OlusturulmaZamani = req.OlusturulmaZamani;

            var resp = _syServis.OzlukBelgesiEkle(req);
            return RedirectToAction("OzlukBelgesiSayfasi");
        }
        public IActionResult OzlukBelgesiSayfasi(int ozlukBelgesiId)
        {
            var resp = _syServis.OzlukBelgesiGetir(ozlukBelgesiId);
            return View(resp);
        }
        public IActionResult OzlukBelgesiGuncelleme(int ozlukBelgesiId)
        {
            var resp = _syServis.OzlukBelgesiGetir(ozlukBelgesiId);
            OzlukBelgesiGuncelle ozluk = new OzlukBelgesiGuncelle();
            ozluk.OzlukBelgesiAdi = resp.OzlukBelgesiAdi;
            ozluk.OzlukBelgesiId = resp.OzlukBelgesiId;
            ozluk.OzlukBelgesiYolu = resp.OzlukBelgesiYolu;
            ozluk.OlusturulmaZamani = resp.OlusturulmaZamani;
            ozluk.PersonelId = resp.PersonelId;
            return View(ozluk);
        }
        [HttpPost]
        public IActionResult OzlukBelgesiGuncelleme(OzlukBelgesiGuncelle guncelle)
        {
            var resp = _syServis.OzlukBelgesiGuncelle(guncelle);
            return RedirectToAction("OzlukBelgesiSayfasi");
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
