using BAL_IK.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_IK.Model
{
    public class Prim
    {
        [Required,Key]
        public int PrimId { get; set; }
        [Required]
        public int PrimTuruId { get; set; }
        public PrimTuru PrimTuru { get; set; }
        [Required]
        public int PersonelId { get; set; }
        public Personeller Personel { get; set; }
        public decimal PrimMiktari { get; set; }
        public DateTime PrimVerilisTarihi { get; set; } = DateTime.Now;
    }
}
