using BAL_IK.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BAL_IK.Model.ResponseClass.PersonelIslemleriResponse;

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
        public class HarcamalarResponse:BaseResponse
        {
            public List<HarcamaResponse> Harcamalar { get; set; }
        }
        public class HarcamaResponse:BaseResponse
        {           
            public int HarcamaId { get; set; }         
            public int PersonelId { get; set; }
            public PersonelResp Personel { get; set; } = new PersonelResp();
            public string HarcamaIsmi { get; set; }
            public decimal HarcamaTutari { get; set; }
            public DateTime OlusturulmaZamani { get; set; } 
            public string DosyaYolu { get; set; }
            public bool OnayDurumu { get; set; } 
        }
    }
}
