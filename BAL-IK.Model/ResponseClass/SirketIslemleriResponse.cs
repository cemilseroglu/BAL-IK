using BAL_IK.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_IK.Model.ResponseClass
{
    public class SirketIslemleriResponse
    {
        public class SirketEkleResponse:BaseResponse
        {
            public int SirketId { get; set; }
        }

        public class PersonelleriGetirResponse: BaseResponse
        {
            public List<PersonelResponse> Personeller { get; set; } =new List<PersonelResponse> ();
            
        }
        

        public class PersonelResponse
        {
            public Guid Guid { get; set; } 
            public string Ad { get; set; }
            public string Soyad { get; set; }
            public DateTime DogumTarihi { get; set; }
            public string Eposta { get; set; } 
            public string Sifre { get; set; }
            public string ResimUrl { get; set; }
            public bool AktifMi { get; set; }
            public Cinsiyet Cinsiyet { get; set; }
            public int PersonelId { get; set; }
            public int YillikIzinHakki { get; set; } 
            public DateTime IseBaslama { get; set; }
            public DateTime? IstenAyrilma { get; set; }
            public decimal TemelMaasBilgisi { get; set; }
            public int SirketId { get; set; }
            public int? DepartmanId { get; set; }
            public int? VardiyaId { get; set; }
        }


    }
}
