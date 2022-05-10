using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_IK.Model.Entities
{
    public class ZimmetTuru
    {
        [Required,Key]
        public int ZimmetTuruId { get; set; }
        [Required,MaxLength(30)]
        public string ZimmetTur { get; set; }
        public List<Zimmetler> Zimmetler { get; set; }
    }
}
