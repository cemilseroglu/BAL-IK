using BAL_IK.Model.Entities;
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
            public bool AktifMi { get; set; } 
            public Cinsiyet Cinsiyet { get; set; }
        }

        public class SiteYoneticisiGuncelle
        {
            public int SiteYoneticisiId { get; set; }
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


        public class SirketGuncelle
        {
            public int SirketId { get; set; }
            [MaxLength(50)]
            public string SirketAdi { get; set; }
            [MaxLength(100)]
            public string SirketAdresi { get; set; }
            [MaxLength(13)]
            public string SirketTelefonu { get; set; }
            [MaxLength(50)]
            public string SirketEmail { get; set; }  //BENZERSİZ OLMALI!!!
            public string SirketLogoURL { get; set; }
            public Durum Durum { get; set; }
            public OdemePlani OdemePlani { get; set; }
            public DateTime KayitTarihi { get; set; }
            public DateTime UyelikBitisTarihi { get; set; }
            public int? YorumId { get; set; }
        }

        public class IzinTuruEkleReq
        {
            public string IzinTur { get; set; }
        }
        public class ZimmetTuruEkleReq
        {
            public string ZimmetTur { get; set; }
        }

        public class IzinTuruGuncelle
        {
            public int IzinTurId { get; set; }
            public string IzinTur { get; set; }
        }
        public class ZimmetTuruGuncelle
        {
            public int ZimmetTurId { get; set; }
            public string ZimmetTur { get; set; }
        }
    }

    
}
