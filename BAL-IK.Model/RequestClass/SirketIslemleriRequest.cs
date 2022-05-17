using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_IK.Model.RequestClass
{
    public class SirketIslemleriRequest
    {
        public class SirketEkleRequest
        {            
            public string SirketAdi { get; set; }
            public string SirketAdresi { get; set; }
            public string SirketTelefonu { get; set; }
            public string SirketEmail { get; set; }
            public string SirketLogoURL { get; set; }
            public OdemePlani OdemePlani { get; set; }                
          
        }
    }

    public enum OdemePlani
    {
        Aylik, Yillik
    }
}
