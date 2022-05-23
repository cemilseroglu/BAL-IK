using BAL_IK.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_IK.Model.RequestClass
{
    public class PersonelIslemleriRequest
    {
        public class PersonelEkle
        {

            [Required, MaxLength(50)]
            public string Ad { get; set; }
            [Required, MaxLength(100)]
            public string Soyad { get; set; }
            public DateTime DogumTarihi { get; set; }
            [Required, MaxLength(250)]
            public string Eposta { get; set; }  //BENZERSİZ OLMALI!!!
            [Required, MaxLength(250)]
            public string Sifre { get; set; }
            public string ResimUrl { get; set; }
            public bool AktifMi { get; set; }
           
            [Required]
            public int YillikIzinHakki { get; set; } //WHAT CAN I DO SOMETİMES?LOOK AT THE TABELA!
            public DateTime IseBaslama { get; set; }
            public DateTime IstenAyrilma { get; set; }
            public int SirketId { get; set; }
            public int DepartmanId { get; set; }
            public int VardiyaId { get; set; }
            public Cinsiyet Cinsiyet { get; set; }

        }
        public class PersonelGuncelle
        {
            public int PersonelId { get; set; }
            [MaxLength(50)]
            public string Ad { get; set; }
            [MaxLength(100)]
            public string Soyad { get; set; }
            public DateTime DogumTarihi { get; set; }
            [MaxLength(250)]
            public string Eposta { get; set; }  //BENZERSİZ OLMALI!!!
            [MaxLength(250)]
            public string Sifre { get; set; }
        }
        public class HarcamaEkle
        {
            public string DosyaYolu { get; set; }
            public int PersonelId { get; set; }       
            public string HarcamaIsmi { get; set; }
            public decimal HarcamaTutari { get; set; }
        }

    }
}
