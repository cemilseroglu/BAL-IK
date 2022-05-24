using BAL_IK.Data.Interfaceler.Sirket;
using BAL_IK.Data.Interfaceler.SirketYoneticisi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static BAL_IK.Model.RequestClass.PersonelIslemleriRequest;
using static BAL_IK.Model.RequestClass.SirketIslemleriRequest;
using static BAL_IK.Model.ResponseClass.PersonelIslemleriResponse;
using static BAL_IK.Model.ResponseClass.SirketIslemleriResponse;

namespace BAL_IK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SirketController : ControllerBase
    {
        private readonly ISirketServis _sService;
        private readonly ISirketYoneticisiServis sirketYoneticisi;

        public SirketController(ISirketServis sService,ISirketYoneticisiServis sirketYoneticisi)
        {
            this._sService = sService;
            this.sirketYoneticisi = sirketYoneticisi;
        }
        [HttpPost("SirketEkle")]
        public SirketEkleResponse SirketEkle(SirketEkleRequest sirket)
        {
            return _sService.SirketEkle(sirket);
        }


        [HttpPost]
        public EkleizinResponse Eklemeizin(Ekleizin izin)
        {
            return sirketYoneticisi.Ekleizin(izin);
        }
        [HttpGet]
        public ListelemeizinResponse Listeleizin()
        {
            return sirketYoneticisi.Listeleizin();
        }
    }
}
