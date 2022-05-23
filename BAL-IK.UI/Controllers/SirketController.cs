using BAL_IK.Data.Interfaceler.Sirket;
using BAL_IK.Data.Interfaceler.SirketYoneticisi;
using BAL_IK.UI.Filters;
using BAL_IK.UI.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static BAL_IK.Model.RequestClass.SirketIslemleriRequest;
using static BAL_IK.Model.RequestClass.SirketYoneticisiIslemleriRequest;

namespace BAL_IK.UI.Controllers
{
    [SirketYoneticisi]
    public class SirketController : Controller
    {
        private readonly ISirketYoneticisiServis _syServis;
        private readonly ISirketServis _sirketServis;
        private readonly IWebHostEnvironment env;

        public SirketController(ISirketYoneticisiServis syServis,ISirketServis sirketServis, IWebHostEnvironment env)
        {
            this._syServis = syServis;
            this._sirketServis = sirketServis;
            this.env = env;
        }
        public IActionResult Index()
        {          
            return View();          
        }
        [HttpPost]
        public IActionResult Index(SirketViewModel sirket)
        {  
            var sirketYoneticisiGuid = HttpContext.Session.GetString("sirketYoneticisi");
            var responseSirketYoneticisi = _syServis.SirketYoneticisiGetir(sirketYoneticisiGuid);
            SirketEkleRequest req=new SirketEkleRequest();
            req.SirketAdi = sirket.SirketAdi;
            req.SirketEmail= sirket.SirketEmail;
            req.SirketTelefonu=sirket.SirketTelefonu;
            req.SirketAdresi= sirket.SirketAdresi;
            if(sirket.SirketLogosu!=null)
                 req.SirketLogoURL = Tools.resimKaydet(sirket.SirketLogosu, env);
            if (sirket.OdemePlani == OdemePlani.Aylık)
                req.OdemePlani = Model.RequestClass.OdemePlani.Aylik;
            else
                req.OdemePlani = Model.RequestClass.OdemePlani.Yillik;
            var responseSirket = _sirketServis.SirketEkle(req);
            if(responseSirket.BasariliMi==false)
            {
                ViewBag.SMesaj = "Şirket Ekleme Esnasında Bir Hata Oluştu." + responseSirket.Mesaj;             
                            
            }
            if(responseSirketYoneticisi.BasariliMi==false)
            {
                ViewBag.SMesaj = "Şirket Ekleme Esnasında Bir Hata Oluştu." + responseSirketYoneticisi.Mesaj;             
                            
            }
            else
            {
                SirketYoneticisiGuncelle sirketYoneticisi = new SirketYoneticisiGuncelle();
                sirketYoneticisi.SirketYoneticisiId = responseSirketYoneticisi.SirketYoneticisiId;
                sirketYoneticisi.SirketId = responseSirket.SirketId;
                sirketYoneticisi.AktifMi = true;
                var responseGuncel = _syServis.SirketYoneticisiGuncelle(sirketYoneticisi);
                ViewBag.SMesaj = responseSirket.Mesaj+" Şirketinizin onaylandıktan sonra sisteme giriş yapabileceksiniz.";       
                if(responseGuncel.BasariliMi==false)
                {
                    ViewBag.SMesaj = responseGuncel.Mesaj;
                }
            }
            return View();
        }
    }
}
