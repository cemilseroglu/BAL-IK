using BAL_IK.Data.Interfaceler.Personeller;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static BAL_IK.Model.RequestClass.PersonelIslemleriRequest;
using static BAL_IK.Model.ResponseClass.PersonelIslemleriResponse;

namespace BAL_IK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonelController : ControllerBase
    {
        private readonly IPersonellerServis _pService;

        public PersonelController(IPersonellerServis pService)
        {
            _pService = pService;
        }
        [HttpPost("PersonelEkleme")]
        public  PersonelEkleResponse PersonelEkleme(PersonelEkle pr)
        {
            return _pService.PersonelEkleme(pr);
        }
        [HttpPost("PersonelGuncelleme")]
        public PersonelGuncelleResponse PersonelGuncelleme(PersonelGuncelle pr)
        {
            return _pService.PersonelGuncelleme(pr);
        }
        [HttpGet("PersonelGetir")]
        public PersonelResp PersonelGetirme(string guid)
        {
            return _pService.PersonelGetir(guid);
        }
        [HttpPost("HarcamaEkleme")]
        public  PersonelHarcamaEkle HarcamaEkleme(HarcamaEkle pr)
        {
            return _pService.HarcamaEkleme(pr);
        }
    }
}
