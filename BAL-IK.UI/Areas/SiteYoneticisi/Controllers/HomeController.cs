using BAL_IK.Data.Interfaceler;
using BAL_IK.Model.Entities;
using BAL_IK.UI.Filters;
using BAL_IK.UI.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using static BAL_IK.Model.RequestClass.SiteYoneticisiIslemleriRequest;

namespace BAL_IK.UI.Areas.SirketYoneticisi.Controllers
{
    [Area("SiteYoneticisi")]
    [SiteYoneticisi]
    public class HomeController : Controller
    {
        private readonly ISiteYoneticisiService _siteyoneticisiService;
        private readonly IWebHostEnvironment _env;

        public HomeController(ISiteYoneticisiService siteyoneticisiService, IWebHostEnvironment env)
        {
            _siteyoneticisiService = siteyoneticisiService;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            var siteyoneticisiGuid = HttpContext.Session.GetString("siteYoneticisi");
            SiteYoneticisiIndexWM wm = new SiteYoneticisiIndexWM();
            wm.resmiTatiller = await Tools.ResmiTatillerGetir();
            wm.personelSayisiResponse = _siteyoneticisiService.PersonelSayisiGetir();
            wm.sirketSayisi = _siteyoneticisiService.SirketSayisiGetir();
            wm.sirketYoneticisiSayisi = _siteyoneticisiService.SirketYoneticisiSayisiGetir();
            wm.askiyaAlinacaklarListesi = _siteyoneticisiService.AskiyaAlinacakSirketleriListele();  // Üyelik bitiş tarihine 1 hafta ve daha az kalanları listeler.
            wm.askiyaAl = _siteyoneticisiService.UyelikAskiyaAlma();
            return View(wm);
        }

        public IActionResult Profil()
        {
            var siteyoneticisiGuid = HttpContext.Session.GetString("siteYoneticisi");
            var response = _siteyoneticisiService.SiteYoneticisiGetir(siteyoneticisiGuid);
            return View(response);
        }

        public IActionResult Duzenle()
        {
            var siteyoneticisiGuid = HttpContext.Session.GetString("siteYoneticisi");
            var response = _siteyoneticisiService.SiteYoneticisiGetir(siteyoneticisiGuid);
            SiteYoneticisiGuncelle sygun = new SiteYoneticisiGuncelle();
            sygun.SiteYoneticisiId = response.SiteYoneticisiId;
            sygun.Ad = response.Ad;
            sygun.Soyad = response.Soyad;
            sygun.Eposta = response.Eposta;
            sygun.DogumTarihi = response.DogumTarihi;
            return View(sygun);
        }

        [HttpPost]
        public IActionResult Duzenle(SiteYoneticisiGuncelle sy)
        {
            var response = _siteyoneticisiService.SiteYoneticisiGuncelleme(sy);
            return RedirectToAction("Profil", "Home");
        }

        public IActionResult SirketAyarlari()
        {
            var response = _siteyoneticisiService.SirketleriListele();
            return View(response);
        }

        public IActionResult SirketDurumuGuncelleme(int id)
        {
            var response = _siteyoneticisiService.SirketGetir(id);
            SirketGuncelle sdgun = new SirketGuncelle();
            sdgun.SirketId = id;
            sdgun.SirketAdresi = response.SirketAdresi;
            sdgun.Durum = response.Durum;
            sdgun.SirketAdi = response.SirketAdi;
            sdgun.KayitTarihi = response.KayitTarihi;
            sdgun.UyelikBitisTarihi = response.UyelikBitisTarihi;
            sdgun.OdemePlani = (Model.RequestClass.OdemePlani)response.OdemePlani;
            sdgun.SirketLogoURL = response.SirketLogoURL;
            sdgun.SirketEmail = response.SirketEmail;
            sdgun.Durum = response.Durum;
            return View(sdgun);
        }
        [HttpPost]
        public IActionResult SirketDurumuGuncelleme(SirketGuncelle s)
        {
            var responseKarsilastirma = _siteyoneticisiService.SirketGetir(s.SirketId);
            var response = _siteyoneticisiService.SirketGuncelleme(s);
            if (s.Durum != responseKarsilastirma.Durum)
            {
                if (s.Durum == Durum.Pasif)
                {
                    Data.Servisler.Tools.MailGonder(s.SirketEmail, "Şirketinizin durumu değiştirilmiştir.", "Şirketinizin durumu pasif olarak değiştirilmiştir.");

                }
                else if (s.Durum == Durum.Aktif)
                {
                    Data.Servisler.Tools.MailGonder(s.SirketEmail, "Şirketinizin durumu değiştirilmiştir.", "Şirketinizin durumu aktif olarak değiştirilmiştir.Artık rahatlıkla giriş yapabilirsiniz.");
                }
                else if (s.Durum == Durum.Askıda)
                {
                    Data.Servisler.Tools.MailGonder(s.SirketEmail, "Şirketiniz askıye alınmıştır!", "Şirketiniz askıya alınmıştır.Lütfen teknik ekiple görüşünüz.");
                }
            }
            else
            {
                Data.Servisler.Tools.MailGonder(s.SirketEmail, "Şirketinizin bilgileri değiştirilmiş olabilir!", "Eğer bilginiz dahilinde değilse lütfen bize ulaşın!");
            }
            return RedirectToAction("SirketAyarlari", "Home");
        }

        public IActionResult Tanimlamalar()
        {
            return View();
        }

        public IActionResult IzinTuru()
        {
            //var response = _siteyoneticisiService.IzinTurleriListele();
            SiteYoneticisiIzinTurleriWM wm = new SiteYoneticisiIzinTurleriWM()
            {
                IzinTurleriListesi = _siteyoneticisiService.IzinTurleriListele(),
            };
            if (wm == null)
            {
                return ViewBag.Mesaj = "Listelenecek herhangi bir izin türü yok.";
            }
            else
            {
                return View(wm);
            }
        }

        [HttpPost]
        public IActionResult IzinTuruEkle(SiteYoneticisiIzinTurleriWM wm)
        {
            var response = _siteyoneticisiService.IzinTurleriEkle(wm.IzinTuruEkleReq);
            wm.IzinTurleriListesi = _siteyoneticisiService.IzinTurleriListele();
            return RedirectToAction("IzinTuru", "Home");
        }

        public IActionResult IzinTuruGuncelleme(int id)
        {
            var response = _siteyoneticisiService.IzinTuruGetir(id);
            IzinTuruGuncelle itgun = new IzinTuruGuncelle();
            itgun.IzinTur = response.IzinTur;
            itgun.IzinTurId = id;

            return View(itgun);
        }

        [HttpPost]
        public IActionResult IzinTuruGuncelleme(IzinTuruGuncelle it)
        {
            var response = _siteyoneticisiService.IzinTurleriGuncelleme(it);
            return RedirectToAction("IzinTuru", "Home");
        }




        public IActionResult ZimmetTuru()
        {
            //var response = _siteyoneticisiService.IzinTurleriListele();
            SiteYoneticisiZimmetTurleriWM wm = new SiteYoneticisiZimmetTurleriWM()
            {
                ZimmetTurleriListesi = _siteyoneticisiService.ZimmetTurleriListele(),
            };
            if (wm == null)
            {
                return ViewBag.Mesaj = "Listelenecek herhangi bir izin türü yok.";
            }
            else
            {
                return View(wm);
            }
        }

        [HttpPost]
        public IActionResult ZimmetTuruEkle(SiteYoneticisiZimmetTurleriWM wm)
        {
            var response = _siteyoneticisiService.ZimmetTurleriEkle(wm.ZimmetTuruEkleReq);
            wm.ZimmetTurleriListesi = _siteyoneticisiService.ZimmetTurleriListele();
            return RedirectToAction("ZimmetTuru", "Home");
        }

        public IActionResult ZimmetTuruGuncelleme(int id)
        {
            var response = _siteyoneticisiService.ZimmetTuruGetir(id);
            ZimmetTuruGuncelle ztgun = new ZimmetTuruGuncelle();
            ztgun.ZimmetTur = response.ZimmetTur;
            ztgun.ZimmetTurId = id;

            return View(ztgun);
        }

        [HttpPost]
        public IActionResult ZimmetTuruGuncelleme(ZimmetTuruGuncelle zt)
        {
            var response = _siteyoneticisiService.ZimmetTurleriGuncelleme(zt);
            return RedirectToAction("ZimmetTuru", "Home");
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("siteYoneticisi");

            return RedirectToAction("Index", "Home", new { Area = "" });
        }



    }    
}
