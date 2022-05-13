using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_IK.Model.RequestClass
{
    public class SiteYoneticisiIslemleriRequest
    {
        public class SiteYoneticisiEkle
        {
            [Required, MaxLength(50)]
            public string Ad { get; set; }   //DisplayName'de buradan verilecek.
            [Required, MaxLength(100)]
            public string Soyad { get; set; }
            public DateTime DogumTarihi { get; set; }
            [Required, MaxLength(250)]
            public string Eposta { get; set; }  //BENZERSİZ OLMALI!!!
            [Required, MaxLength(250)]
            public string Sifre { get; set; }
            public string ResimUrl { get; set; }
            public bool AktifMi { get; set; } = true;
        }

    }

    
}
