using BAL_IK.Data.Interfaceler.Site;
using BAL_IK.Model.ResponseClass;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static BAL_IK.Model.RequestClass.LogIslemleriRequest;
using static BAL_IK.Model.ResponseClass.LogIslemleriResponse;

namespace BAL_IK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ISiteLoginServis _logServis;

        public LoginController(ISiteLoginServis logServis)
        {
            _logServis = logServis;
        }
        [HttpPost]
        public LoginKullanici LogIslemi(LogKullanici log)
        {
            return _logServis.LoginIslemi(log);
        }
        [HttpPost("KayitIslemi")]
        public KayitKullaniciResp KayitIslemi(KayitKullaniciReq req)
        {            
            return _logServis.KayitIslemi(req);
        }
    }
}
