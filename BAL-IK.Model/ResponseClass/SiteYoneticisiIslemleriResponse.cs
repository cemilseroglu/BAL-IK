using BAL_IK.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_IK.Model.ResponseClass
{
    public class SiteYoneticisiIslemleriResponse : BaseResponse
    {
        public class SiteYoneticisiEkleResponse : BaseResponse
        {

        }
        public class SiteYoneticileriniListeleResponse : BaseResponse
        {
            public List<SiteYoneticisiResp> SiteYoneticisiListele { get; set; }
        }

        public class SirketListeleResponse : BaseResponse
        {
            public List<SirketResp> SirketListele { get; set; }
        }
        public class SiteYoneticisiResp : BaseResponse
        {
            public int SiteYoneticisiId { get; set; }
            public Guid Guid { get; set; }
            public string Ad { get; set; }
            public string Soyad { get; set; }
            public DateTime DogumTarihi { get; set; }
            public string Eposta { get; set; }  //BENZERSİZ OLMALI!!!
            public string Sifre { get; set; }
            public string ResimUrl { get; set; }
            public bool AktifMi { get; set; }
            public Cinsiyet Cinsiyet { get; set; }
        }

        public class SirketResp : BaseResponse
        {
            public int SirketId { get; set; }
            public string SirketAdi { get; set; }
            public string SirketAdresi { get; set; }
            public string SirketTelefonu { get; set; }
            public string SirketEmail { get; set; }
            public string SirketLogoURL { get; set; }
            public OdemePlani OdemePlani { get; set; }
            public Durum Durum { get; set; }
            public DateTime KayitTarihi { get; set; }
            public DateTime UyelikBitisTarihi { get; set; }
            public int? YorumId { get; set; }
        }

        public class SiteYoneticisiGuncelleResponse : BaseResponse
        {

        }

        public class SirketGuncelleResponse : BaseResponse
        {

        }
        public class VardiyaEkleResponse : BaseResponse
        {

        }
    }
}
