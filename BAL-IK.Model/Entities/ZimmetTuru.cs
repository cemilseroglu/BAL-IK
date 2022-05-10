using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_IK.Model.Entities
{
    public class ZimmetTuru
    {
        public int ZimmetTuruId { get; set; }
        public string ZimmetTur { get; set; }
        public List<Zimmetler> Zimmetler { get; set; }
    }
}
