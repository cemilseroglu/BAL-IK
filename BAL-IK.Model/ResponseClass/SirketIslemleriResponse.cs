using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_IK.Model.ResponseClass
{
    public class SirketIslemleriResponse
    {
        public class SirketEkleResponse:BaseResponse
        {
            public int SirketId { get; set; }
        }
    }
}
