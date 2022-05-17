using BAL_IK.Data.Interfaceler.Sirket;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static BAL_IK.Model.RequestClass.SirketIslemleriRequest;
using static BAL_IK.Model.ResponseClass.SirketIslemleriResponse;

namespace BAL_IK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SirketController : ControllerBase
    {
        private readonly ISirketServis _sService;

        public SirketController(ISirketServis sService)
        {
            this._sService = sService;
        }
        [HttpPost("SirketEkle")]
        public SirketEkleResponse SirketEkle(SirketEkleRequest sirket )
        {
            return _sService.SirketEkle( sirket );
        }
       
    }
}
