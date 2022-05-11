using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_IK.Model.Entities
{
    public class PrimTuru
    {
        [Required, Key]
        public int PrimTuruId { get; set; }
        [Required, MaxLength(50)]
        public string PrimTur { get; set; }
        public List<Prim> Primler { get; set; }
    }
}
