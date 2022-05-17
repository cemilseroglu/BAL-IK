using BAL_IK.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_IK.Model.ResponseClass
{
    public class PersonelIslemleriResponse
    {
       public class PersonelEkleResponse:BaseResponse
        {

        }
        public class PersonelGuncelleResponse : BaseResponse
        {

        }
        public class PersonelListelemeResponse:BaseResponse
        {
            public List<PersonelResp> PersonelListeleme { get; set; }

        }
        public class PersonelResp:BaseResponse
        {

            public Guid Guid { get; set; } 
            public string Ad { get; set; }         
            public string Soyad { get; set; }
            public DateTime DogumTarihi { get; set; }           
            public string Eposta { get; set; }  //BENZERSİZ OLMALI!!!
            public string Sifre { get; set; }
            public string ResimUrl { get; set; }
            public bool AktifMi { get; set; }
            public int PersonelId { get; set; }
            public int YillikIzinHakki { get; set; } //WHAT CAN I DO SOMETİMES?LOOK AT THE TABELA!
            public DateTime IseBaslama { get; set; }
            public DateTime IstenAyrilma { get; set; }
            public int SirketId { get; set; }
            public int? DepartmanId { get; set; }
            public int? VardiyaId { get; set; }
            public Cinsiyet Cinsiyet { get; set; }

        }
    }
}
