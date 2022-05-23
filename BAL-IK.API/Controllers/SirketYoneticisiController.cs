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
        //[HttpPost("IzinEklemeee")]
        //public IzinEkleResponse IzinEkleme(IzinEkle izin)
        //{
        //    return _sService.IzinEkle(izin);
        //}
        //[HttpGet("IzinListele")]
        //public IzinListelemeResponse IzinListele()
        //{
        //    return _sService.IzinListele();
        //}
        //[HttpGet("SirketYoneticisiIzinListele")]
        //public IzinListelemeResponse IzinListeleme()
        //{
        //    return _sService.IzinListele();
        //}
     

    }
}
