using BAL_IK.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_IK.Model
{
    public class Prim
    {
        public int PrimId { get; set; }
        public int PrimTuruId { get; set; }
        public PrimTuru PrimTuru { get; set; }
        public int PersonelId { get; set; }
        public Personeller Personel { get; set; }
        public decimal PrimMiktari { get; set; }
        public DateTime PrimVerilisTarihi { get; set; }
    }
}
