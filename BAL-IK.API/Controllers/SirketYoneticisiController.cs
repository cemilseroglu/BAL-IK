using BAL_IK.Data.Interfaceler.SirketYoneticisi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BAL_IK.Model.RequestClass.SirketYoneticisiIslemleriRequest;
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

        [HttpPost("SirketYoneticisiGuncelleme")]

        public SirketYoneticisiGuncel SirketYoneticisiGuncelleme(SirketYoneticisiGuncelle req)
        {
            return _sService.SirketYoneticisiGuncelle(req);
        }
        [HttpGet("SirketYoneticisiGetir")]
        public SirketYoneticisiResponse SirketYoneticiGetir(string guid)
        {
            return _sService.SirketYoneticisiGetir(guid);
        }

    }
}
