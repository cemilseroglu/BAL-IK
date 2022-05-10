using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_IK.Model.Entities
{
    public class SirketYoneticisi : BasePerson
    {
        [Required]
        public int SirketYoneticisiId { get; set; }
        public int SirketId { get; set; }
        public Sirket Sirket { get; set; }

    }
}
