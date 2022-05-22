using BAL_IK.Data.Interfaceler.SirketYoneticisi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BAL_IK.Model.RequestClass.SirketYoneticisiIslemleriRequest;
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
        [HttpPost("HarcamaOnay")]
        public string HarcamaOnayi(int id,bool durum)
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
        public PersonelleriGetirResponse PersonelleriGetir()
        {
            return _sService.PersonelleriGetir();
        }



    }
}
