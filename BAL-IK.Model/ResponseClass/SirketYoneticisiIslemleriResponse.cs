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
            public int SirketYoneticisiId { get; set; }
            public string Ad { get; set; }   //DisplayName'de buradan verilecek.
            public string Soyad { get; set; }
            public DateTime DogumTarihi { get; set; }
            public string Eposta { get; set; }  //BENZERSİZ OLMALI!!!
            public string Sifre { get; set; }
        }
    }
}
