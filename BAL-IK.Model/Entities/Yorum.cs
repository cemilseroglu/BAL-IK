using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_IK.Model.Entities
{
    public class Yorum
    {
        public int YorumId { get; set; }
        public string YorumBaslik { get; set; }
        public string YorumIcerik { get; set; }
        public int SirketId { get; set; } // BİRE-BİR!!!!
        public Sirket Sirket { get; set; } 
        public DateTime OlusturulmaTarihi { get; set; }
    }
}
