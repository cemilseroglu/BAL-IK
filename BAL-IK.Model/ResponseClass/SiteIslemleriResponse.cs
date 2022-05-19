using BAL_IK.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_IK.Model.ResponseClass
{
    public class SiteIslemleriResponse
    {
        public class YorumlarResponse : BaseResponse
        {
            public List<YorumResponse> Yorumlar { get; set; }
        }
        public class YorumResponse : BaseResponse
        {
            public int YorumId { get; set; }
            public string YorumBaslik { get; set; }
            public string YorumIcerik { get; set; }
            public int SirketId { get; set; }
            public DateTime OlusturulmaTarihi { get; set; }
        }
    }
}

