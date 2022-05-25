using BAL_IK.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_IK.Model
{
    public class Vardiyalar
    {
        [Required,Key]
        public int VardiyaId { get; set; }
        public int PersonelId { get; set; }
        public Personeller Personel { get; set; }
        public int VardiyaTurId { get; set; }
        public VardiyaTur VardiyaTur { get; set; }     
    }
   
}
