using BAL_IK.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_IK.Model
{
    public class Harcamalar
    {
        public int HarcamaID { get; set; }
        public int PersonelID { get; set; }
        public Personeller Personel { get; set; }
        public string HarcamaIsmi { get; set; }
        public decimal HarcamaTutari { get; set; }
    }

}
