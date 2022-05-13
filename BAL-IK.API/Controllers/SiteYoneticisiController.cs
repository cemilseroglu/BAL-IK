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

        [HttpGet]
        public SiteYoneticileriniListeleResponse SiteYoneticiListele()
        {
            return _sService.SiteYoneticileriniListele();
        }

        //[HttpGet("sirketlistele")]
        //public List<Sirket> SirketListGetir()
        //{
        //    return _sService.SirketleriGetir();
        //}

        [HttpPost]
        public SiteYoneticisiEkleResponse SirketYoneticisiEkle(SiteYoneticisiEkle sy)
        {
            return _sService.SiteYoneticisiKaydet(sy);

        }
    }
}
