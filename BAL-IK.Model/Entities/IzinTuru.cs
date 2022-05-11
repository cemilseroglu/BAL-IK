using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_IK.Model.Entities
{
    public class IzinTuru
    {
        [Required,Key]
        public int IzinTurId { get; set; }
        public string IzinTur { get; set; }
        public List<Izinler> Izinler { get; set; }
    }
}
