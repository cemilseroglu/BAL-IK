using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_IK.Model.Entities
{
    public class MaasBilgisi
    {
        [Required,Key]
        public int MaasId { get; set; }
        [Required]
        public int PersonelId { get; set; }
        public Personeller Personel { get; set; }
        public DateTime VerilisTarihi { get; set; }
        public decimal MaasTutari { get; set; }
    }
}
