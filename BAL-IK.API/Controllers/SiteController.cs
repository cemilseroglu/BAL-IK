using BAL_IK.Data.Interfaceler.Site;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static BAL_IK.Model.ResponseClass.SiteIslemleriResponse;

namespace BAL_IK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiteController : ControllerBase
    {
        private readonly ISiteLoginServis _logServis;

        public SiteController(ISiteLoginServis logServis)
        {
            _logServis = logServis;
        }

        [HttpGet("YorumlariGetir")]
        public YorumlarResponse YorumGetir()
        {
            return _logServis.YorumlariGetir();
        }

    }
}
