using BAL_IK.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BAL_IK.Model.ResponseClass.PersonelIslemleriResponse.PersonelEkleResponse;

namespace BAL_IK.UI.ViewModels
{
    public class PersonelEkleViewModel
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string Eposta { get; set; }  //BENZERSİZ OLMALI!!!
        public string ResimUrl { get; set; }
        public bool AktifMi { get; set; }
        public DateTime IseBaslama { get; set; }
        public int SirketId { get; set; }
        public Cinsiyet Cinsiyet { get; set; }
    }
}
