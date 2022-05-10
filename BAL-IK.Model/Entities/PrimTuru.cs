using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_IK.Model.Entities
{
    public class PrimTuru
    {
        public int PrimTuruId { get; set; }
        public string PrimTur { get; set; }
        public List<Prim> Primler { get; set; }
    }
}
