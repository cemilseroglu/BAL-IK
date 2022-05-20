using BAL_IK.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_IK.Model
{
    public class Harcamalar
    {
        [Required,Key]
        public int HarcamaId { get; set; }
        [Required]
        public int PersonelId { get; set; }
        public Personeller Personel { get; set; }
        [Required,MaxLength(100)]
        public string HarcamaIsmi { get; set; }
        public decimal HarcamaTutari { get; set; }
        public DateTime OlusturulmaZamani { get; set; } = DateTime.Now;
        public string DosyaYolu { get; set; }
        public bool OnayDurumu { get; set; } = false;
    }

}
