using BAL_IK.Model.Entities;
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
           
        }

        public class SirketYoneticisiResponse :BaseResponse
        {
            public int SirketYoneticisiId { get; set; }
            public string Ad { get; set; } 
            public string Soyad { get; set; }
            public DateTime DogumTarihi { get; set; }
            public string Eposta { get; set; }       
            public int? SirketId { get; set; }
            public Guid Guid { get; set; }                   
            public bool AktifMi { get; set; }
            public Cinsiyet Cinsiyet { get; set; }
        }
    }
}
