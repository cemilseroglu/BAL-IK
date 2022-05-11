using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_IK.Model.Entities
{
    public class Departmanlar
    {
        [Required,Key]
        public int DepartmanId { get; set; }
        [Required, MaxLength(50)]
        public string DepartmanAdi { get; set; }
        [Required, MaxLength(50)]
        public string DepartmanAdresi { get; set; }
        [Required]
        public int SirketId { get; set; }
        public Sirket Sirketi { get; set; }
        public List<Personeller> Personelleri { get; set; }
    }
}
