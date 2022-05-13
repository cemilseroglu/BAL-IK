using BAL_IK.Data.Context;
using BAL_IK.Data.Interfaceler;
using BAL_IK.Model.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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
        public List<SirketYoneticisi> SirketYoneticisiListGetir()
        {
            return _sService.SirketYoneticileriGetir();
        }

        //[HttpGet("sirketlistele")]
        //public List<Sirket> SirketListGetir()
        //{
        //    return _sService.SirketleriGetir();
        //}
        
        [HttpPost]
        public int SirketYoneticisiEkle(SirketYoneticisi sy)
        {
            return _sService.SirketYoneticisiKaydet(sy);
            
        }      
    }
}
