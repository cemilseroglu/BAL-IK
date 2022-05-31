using BAL_IK.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_IK.Model
{
    public class Mola
    {
        public Mola()
        {
           
        }
        [Required,Key]
        public int MolaId { get; set; }
        public int MolaTurId { get; set; }
        public MolaTur MolaTur { get; set; }      
        public int PersonelId { get; set; }
        public Personeller Personel { get; set; }
        public DateTime OlusturulduguTarih { get; set; } = DateTime.Now;
        
    }
  
}
