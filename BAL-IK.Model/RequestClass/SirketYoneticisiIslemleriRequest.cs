using BAL_IK.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_IK.Model.RequestClass
{
    public class SirketYoneticisiIslemleriRequest
    {
        public class SirketYoneticisiGuncelle
        {
            [Required]
            public int SirketYoneticisiId { get; set; }
            [MaxLength(50)]
            public string Ad { get; set; }   //DisplayName'de buradan verilecek.
            [MaxLength(100)]
            public string Soyad { get; set; }
            public DateTime DogumTarihi { get; set; }
            [MaxLength(250)]
            public string Eposta { get; set; }  //BENZERSİZ OLMALI!!!
            [MaxLength(250)]
            public string Sifre { get; set; }
            public bool AktifMi { get; set; }
            public int? SirketId { get; set; }
        }

    }
}
