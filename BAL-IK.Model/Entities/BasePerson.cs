using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_IK.Model.Entities
{
    public class BasePerson
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string Eposta { get; set; }  //BENZERSİZ OLMALI!!!
        public string Sifre { get; set; }
        public string ResimUrl { get; set; }
        public bool AktifMi { get; set; } = true;
    }



    
}
