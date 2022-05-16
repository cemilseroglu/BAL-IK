using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_IK.Model.ResponseClass
{
    public class LogIslemleriResponse
    {
        public class LoginKullanici:BaseResponse
        {
            public string KullaniciTuru { get; set; }
            public string GirisGuid { get; set; }
        }
        public class KayitKullaniciResp:BaseResponse
        {

        }
    }
}
