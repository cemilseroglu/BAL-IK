using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_IK.Model.ResponseClass
{
    public class SirketYoneticisiIslemleriResponse : BaseResponse
    {
        public class SirketYoneticisiGuncel : BaseResponse
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
        }
    }
}
