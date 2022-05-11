using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_IK.Model.Entities
{
    public class SiteYoneticisi:BasePerson
    {
        [Required,Key]
        public int SiteYoneticisiId { get; set; } 
    }
}
