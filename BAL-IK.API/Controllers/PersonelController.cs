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
        public PersonelEkleResponse PersonelEkleme(PersonelEkle pr)
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
        public PersonelHarcamaEkle HarcamaEkleme(HarcamaEkle pr)
        {
            return _pService.HarcamaEkleme(pr);
        }
        [HttpGet("HarcamalarıGetir")]
        public HarcamaListelemeResponse HarcamaGetir()
        {
            return _pService.HarcamalarıGetir();
        }
        [HttpGet("IzinleriGetir")]
        public IzinlerResponse IzinleriGetir(string guid)
        {
            return _pService.IzinleriGetir(guid);
        }
        [HttpGet("VardiyalariGetir")]
        public VardiyalarResponse VardiyalariGetir(string guid)
        {
            return _pService.VardiyalariGetir(guid);
        }
        [HttpGet("MolalariGetir")]
        public MolalarResponse MolalariGetir(string guid)
        {
            return _pService.MolalariGetir(guid);
        }
        [HttpPost("IzinEkle")]
        public EkleizinResponse Ekleizin(Ekleizin izinEkle)
        {
            return _pService.Ekleizin(izinEkle);
        }
        [HttpGet("IzinTurleriGetir")]
        public IzinTurlerResponse IzinTurleriGetir()
        {
            return _pService.IzinTurleriGetir();
        }

    }
}
