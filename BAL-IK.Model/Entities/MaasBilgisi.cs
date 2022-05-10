using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_IK.Model.Entities
{
    public class MaasBilgisi
    {
        public int MaasID { get; set; }
        public int PersonelID { get; set; }
        public Personeller Personel { get; set; }
        public DateTime VerilisTarihi { get; set; }
        public decimal MaasTutari { get; set; }
    }
}
