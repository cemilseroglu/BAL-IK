using BAL_IK.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_IK.Model.RequestClass
{
    public class SirketYoneticisiIslemleriRequest
    {
        public class SirketYoneticisiGuncelle
        {
            public int SirketYoneticisiId { get; set; }
            public string Ad { get; set; }  
            public string Soyad { get; set; }
            public DateTime DogumTarihi { get; set; }
            public string Eposta { get; set; }  
            public string Sifre { get; set; }
            public bool AktifMi { get; set; }
            public int? SirketId { get; set; }
        }
        public class SirketYoneticisiEkle
        {
            public string Ad { get; set; } 
            public string Soyad { get; set; }
            public DateTime DogumTarihi { get; set; }
            public string Eposta { get; set; }  
            public Cinsiyet Cinsiyet { get; set; }
        }

        public class ZimmetEkleRequest
        {
            public int ZimmetTuruId { get; set; }
            public int PersonelId { get; set; }
        }    
        
        public class ZimmetGuncelleRequest
        {
            public int ZimmetId { get; set; }
            public int ZimmetTuruId { get; set; }
        }

        public class VardiyaTurEkleRequest
        {
            public string SirketYoneticisiGuid{ get; set; }
            public string VardiyaTuru { get; set; }
            public DateTime VardiyaBaslangicTarihi { get; set; }
            public DateTime VardiyaBitisTarihi { get; set; }
        }
        public class CalisanVardiyaMolaEkleRequest
        {
            public int VardiyaId { get; set; }
            public int PersonelId { get; set; }
            public int VardiyaTurId { get; set; }
            public List<int> MolaTurIds { get; set; }
        }

        public class MolaTurRequest
        {
            public int MolaTurId { get; set; }
            public string MolaTuru { get; set; }
            public double MolaSuresi { get; set; }
            public string SirketYoneticisiGuid { get; set; }
        }
    }
}
