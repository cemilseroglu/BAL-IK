using BAL_IK.Data.Context;
using BAL_IK.Data.Interfaceler;
using BAL_IK.Model.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using static BAL_IK.Model.RequestClass.SiteYoneticisiIslemleriRequest;
using static BAL_IK.Model.ResponseClass.SiteYoneticisiIslemleriResponse;

namespace BAL_IK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiteYoneticisiController : ControllerBase
    {
        private readonly ISiteYoneticisiService _sService;

        public SiteYoneticisiController(ISiteYoneticisiService sService) //buraya ISiteYoneticiInterface gelecek,listeleme,sirket ve sirketYoneticisi ekleme metotları olacak.
        {
            _sService = sService;
        }

        [HttpGet("SiteYoneticiListele")]
        public SiteYoneticileriniListeleResponse SiteYoneticiListele()
        {
            return _sService.SiteYoneticileriniListele();
        }



        [HttpPost("SirketYoneticisiEkle")]
        public SiteYoneticisiEkleResponse SirketYoneticisiEkle(SiteYoneticisiEkle sy)
        {
            return _sService.SiteYoneticisiKaydet(sy);

        }


        [HttpPost("SiteYoneticisiGuncelleme")]
        public SiteYoneticisiGuncelleResponse SiteYoneticisiGuncelleme(SiteYoneticisiGuncelle sy)
        {
            return _sService.SiteYoneticisiGuncelleme(sy);
        }

        [HttpGet("SiteYoneticisiGetir")]
        public SiteYoneticisiResp SiteYoneticisiGetir(string guid)
        {
            return _sService.SiteYoneticisiGetir(guid);
        }

        [HttpGet("SirketleriListele")]
        public SirketListeleResponse SirketleriListele()
        {
            return _sService.SirketleriListele();
        }

        [HttpGet("SirketGetir")]
        public SirketResp SirketGetir(int id)
        {
            return _sService.SirketGetir(id);
        }


        [HttpPost("SirketGuncelleme")]
        public SirketGuncelleResponse SirketGuncelleme(SirketGuncelle s)
        {
            return _sService.SirketGuncelleme(s);
        }

        [HttpGet("IzinTurleriListele")]
        public IzinTurleriListeleResponse IzinTurleriListele()
        {
            return _sService.IzinTurleriListele();
        }

        [HttpPost("IzinTurleriEkle")]
        public IzinTurleriEkleResponse IzinTurleriEkle(IzinTuruEkleReq ıt)
        {
            return _sService.IzinTurleriEkle(ıt);
        }

        [HttpPost("IzinTurleriGuncelleme")]
        public IzinTurleriGuncelleResponse IzinTurleriGuncelleme(IzinTuruGuncelle ıtgun)
        {
            return _sService.IzinTurleriGuncelleme(ıtgun);
        }


        [HttpGet("IzinTuruGetir")]
        public IzinTurleriResponse IzinTuruGetir(int id)
        {
            return _sService.IzinTuruGetir(id);
        }

        [HttpPost("IzinTuruSil")]
        public IzinTuruSilResponse IzinTuruSil(int id)
        {
            return _sService.IzinTuruSil(id);
        }

        [HttpGet("ZimmetTurleriListele")]
        public ZimmetTurleriListeleResponse ZimmetTurleriListele()
        {
            return _sService.ZimmetTurleriListele();
        }

        [HttpPost("ZimmetTurleriEkle")]
        public ZimmetTurleriEkleResponse ZimmetTurleriEkle(ZimmetTuruEkleReq zt)
        {
            return _sService.ZimmetTurleriEkle(zt);
        }

        [HttpPost("ZimmetTurleriGuncelleme")]
        public ZimmetTurleriGuncelleResponse ZimmetTurleriGuncelleme(ZimmetTuruGuncelle ztgun)
        {
            return _sService.ZimmetTurleriGuncelleme(ztgun);
        }


        [HttpGet("ZimmetTuruGetir")]
        public ZimmetTurleriResponse ZimmetTuruGetir(int id)
        {
            return _sService.ZimmetTuruGetir(id);
        }

        [HttpPost("ZimmetTuruSil")]
        public ZimmetTuruSilResponse ZimmetTuruSil(int id)
        {
            return _sService.ZimmetTuruSil(id);
        }

        [HttpGet("SirketSayisiGetir")]
        public SirketSayisiResponse SirketSayisiGetir()
        {
            return _sService.SirketSayisiGetir();
        }

        [HttpGet("SirketYoneticisiSayisiGetir")]
        public SirketYoneticisiSayisiResponse SirketYoneticisiSayisiGetir()
        {
            return _sService.SirketYoneticisiSayisiGetir();
        }

        [HttpGet("PersonelSayisiGetir")]
        public PersonelSayisiResponse PersonelSayisiGetir()
        {
            return _sService.PersonelSayisiGetir();
        }

        [HttpGet("AskiyaAlinacakSirketleriListele")]
        public AskiyaAlinacakSirketleriListeleResponse AskiyaAlinacakSirketleriListele()
        {
            return _sService.AskiyaAlinacakSirketleriListele();
        }

        [HttpGet("UyelikAskiyaAlma")]
        public UyelikAskiyaAlmaResponse UyelikAskiyaAlma()
        {
            return _sService.UyelikAskiyaAlma();
        }
    }
}
