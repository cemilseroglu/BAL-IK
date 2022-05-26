using BAL_IK.Data.Interfaceler.SirketYoneticisi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BAL_IK.Model.RequestClass.PersonelIslemleriRequest;
using static BAL_IK.Model.RequestClass.SirketYoneticisiIslemleriRequest;

using static BAL_IK.Model.ResponseClass.PersonelIslemleriResponse;

using static BAL_IK.Model.ResponseClass.SirketIslemleriResponse;

using static BAL_IK.Model.ResponseClass.SirketYoneticisiIslemleriResponse;

namespace BAL_IK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SirketYoneticisiController : ControllerBase
    {
        private readonly ISirketYoneticisiServis _sService;

        public SirketYoneticisiController(ISirketYoneticisiServis sService)
        {
            _sService = sService;
        }

        [HttpPost("SirketYoneticisiGuncelle")]
        public SirketYoneticisiGuncel SirketYoneticisiGuncelleme(SirketYoneticisiGuncelle req)
        {
            return _sService.SirketYoneticisiGuncelle(req);
        }
        [HttpGet("SirketYoneticisiGetir")]
        public SirketYoneticisiResponse SirketYoneticiGetir(string guid)
        {
            return _sService.SirketYoneticisiGetir(guid);
        }
        [HttpGet("HarcamalariGetir")]
        public HarcamalarResponse HarcamalariGetir(string guid)
        {
            return _sService.HarcamalariGetir(guid);
        }

        [HttpPost("PersonelEklemeIslemi")]
        public PersonelEkleResponse PersonelEkleme(PersonelEkle personelEkle)
        {
            return _sService.PersonelEklemeIslemi(personelEkle);
        }
        [HttpPost("PersonelGuncelleme")]
        public PersonelGuncelleResponse PersonelGuncelle(PersonelGuncelle pers)
        {
            return _sService.PersonelGuncelleme(pers);
        }
        [HttpPost("PersonelSil")]
        public PersonelSilResponse PersonelSilme(int pers)
        {
            return _sService.PersonelSil(pers);
        }
        [HttpPost("OzlukBelgesiEkle")]
        public OzlukBelgesiEkleResponse OzlukBelgesiEkle(OzlukBelgesiEkle ozlukBelgesi)
        {
            return _sService.OzlukBelgesiEkle(ozlukBelgesi);
        }
        [HttpPost("OzlukBelgesiGuncelle")]
        public OzlukBelgesiGuncelleResponse OzlukBelgesiGuncelle(OzlukBelgesiGuncelle ozluk)
        {
            return _sService.OzlukBelgesiGuncelle(ozluk);
        }
        [HttpPost("OzlukBelgesiSil")]
        public OzlukBelgesiSilResponse OzlukBelgesiSil(int ozlukBelgesiId)
        {
            return _sService.OzlukBelgesiSil(ozlukBelgesiId);
        }

        //[HttpGet("SirketYoneticisiIzinListele")]
        //public IzinListelemeResponse IzinListeleme()
        //{
        //    return _sService.IzinListele();
        //}
        [HttpPost]
        public EkleizinResponse Eklemeizin(Ekleizin izin)
        {
            return _sService.Ekleizin(izin);
        }
        [HttpGet]
        public ListelemeizinResponse Listeleizin()
        {
            return _sService.Listeleizin();
        }

        [HttpPost("HarcamaOnay")]
        public string HarcamaOnayi(int id, bool durum)
        {
            return _sService.HarcamaOnayla(id, durum);
        }
        [HttpGet("ZimmetleriGetir")]
        public ZimmetleriGetirResponse ZimmetGetir(string guid)
        {
            return _sService.ZimmetleriGetir(guid);
        }
        [HttpGet("ZimmetTurleriGetir")]
        public ZimmetTurleriResponse ZimmetTurleriniGetir()
        {
            return _sService.ZimmetTurleriniGetir();
        }
        [HttpPost("ZimmetEkle")]
        public ZimmetEkleResponse ZimmetEkle(ZimmetEkleRequest zimmet)
        {
            return _sService.ZimmetEkle(zimmet);
        }
        [HttpPost("ZimmetSil")]
        public ZimmetSilResponse ZimmetSil(int id)
        {
            return _sService.ZimmetSil(id);
        }
        [HttpPost("ZimmetGuncelle")]
        public ZimmetGuncelleResponse ZimmetGuncelle(ZimmetGuncelleRequest req)
        {
            return _sService.ZimmetGuncelle(req);
        }
        [HttpGet("PersonelleriGetir")]
        public PersonelleriGetirResponse PersonelleriGetir(string guid)
        {
            return _sService.PersonelleriGetir(guid);
        }
        [HttpPost("VardiyaTurEkle")]
        public VardiyaTurEkleResponse VardiyaTurEkle(VardiyaTurEkleRequest req)
        {
            return _sService.VardiyaTurEkle(req);
        }
        [HttpPost("VardiyaTurSil")]
        public VardiyaTurSilResponse VardiyaTurSil(int vardiyaTurId)
        {
            return _sService.VardiyaTurSil(vardiyaTurId);
        }
        [HttpGet("VardiyaTurleriGetir")]
        public VardiyaTurleriGetirResponse VardiyaTurlerGetir(string guid)
        {
            return _sService.VardiyaTurleriGetir(guid);
        }
        [HttpPost("CalisanVardiyaEkle")]
        public CalisanVardiyaMolaEkleResponse CalisanVardiyaEkle(CalisanVardiyaMolaEkleRequest req)
        {
            return _sService.CalisanVardiyaEkle(req);
        }
        [HttpGet("MolaTurleriGetir")]
        public MolaTurlerResponse MolaTurleriGetir(string guid)
        {
            return _sService.MolaTurleriGetir(guid);
        }
        [HttpPost("MolaTurEkle")]
        public MolaTurEkleResponse MolaTurEkle(MolaTurRequest req)
        {
            return _sService.MolaTurEkle(req);
        }
        [HttpPost("MolaTurSil")]
        public MolaTurSilResponse MolaTurSil(int id)
        {
            return _sService.MolaTurSil(id);
        }
    }
}
