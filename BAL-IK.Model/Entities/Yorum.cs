using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_IK.Model.Entities
{
    public class Yorum
    {
        [Required,Key]
        public int YorumId { get; set; }
        [Required,MaxLength(30)]
        public string YorumBaslik { get; set; }
        [Required,MaxLength(3000)]
        public string YorumIcerik { get; set; }
        [Required]
        public int SirketId { get; set; } // BİRE-BİR!!!!
        public Sirket Sirket { get; set; } 
        public DateTime OlusturulmaTarihi { get; set; }=DateTime.Now;
    }
}
