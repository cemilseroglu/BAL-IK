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
            public string Ad { get; set; }
            public string Soyad { get; set; }
            public DateTime DogumTarihi { get; set; }
            public string Eposta { get; set; }  
            public string ResimUrl { get; set; }
            public bool AktifMi { get; set; }
            public DateTime IseBaslama { get; set; }
            public int SirketId { get; set; }
            public Cinsiyet Cinsiyet { get; set; }
            public decimal TemelMaasBilgisi { get; set; }

        }
        public class PersonelGuncelle
        {
            public int PersonelId { get; set; }
            public string Ad { get; set; }
            public string Soyad { get; set; }
            public DateTime DogumTarihi { get; set; }
            public string Eposta { get; set; } 
            public string Sifre { get; set; }
            public DateTime IseBaslama { get; set; }
            public DateTime IstenAyrilma { get; set; }
            public bool AktifMi { get; set; }
            public int YillikIzinHakki { get; set; } 
            public int SirketId { get; set; }
            public int DepartmanId { get; set; }
            public int VardiyaId { get; set; }
            public Cinsiyet Cinsiyet { get; set; }

        }
        public class HarcamaEkle
        {
            public string DosyaYolu { get; set; }
            public int PersonelId { get; set; }
            public string HarcamaIsmi { get; set; }
            public decimal HarcamaTutari { get; set; }
        }

        public class OzlukBelgesiEkle
        {
            public int PersonelId { get; set; }
            public int SirketYoneticisiId { get; set; }
            public string OzlukBelgesiAdi { get; set; }
            public string OzlukBelgesiYolu { get; set; }
            public DateTime OlusturulmaZamani { get; set; }
        }
        public class OzlukBelgesiGuncelle
        {
            public int OzlukBelgesiId { get; set; }
            public int PersonelId { get; set; }
            public string OzlukBelgesiAdi { get; set; }
            public string OzlukBelgesiYolu { get; set; }
            public DateTime OlusturulmaZamani { get; set; }
            public int SirketYoneticisiId { get; set; }
        }       
        public class Ekleizin
        {
            public int IzinTurId { get; set; } 
            public int IzinSuresi { get; set; }
            public string ReddilmeNedeni { get; set; }
            public DateTime IzinIstemeTarihi { get; set; } = DateTime.Now;
            public DateTime OnaylanmaTarihi { get; set; }
            public DateTime IzinBaslangicTarihi { get; set; }
            public DateTime IzinBitisTarihi { get; set; }
            public int PersonelId { get; set; }
            public int SirketYoneticisiId { get; set; }
            public OnayDurumu OnayDurumu { get; set; } = OnayDurumu.OnayBekliyor;
        } 
        public class IzinTuru
        {
            public int IzinTurId { get; set; }
            public string IzinTur { get; set; }
        }
        public class PersonelSil
        {
            public int PersonelId { get; set; }
            public bool AktifMi { get; set; }
        }

    }
}
