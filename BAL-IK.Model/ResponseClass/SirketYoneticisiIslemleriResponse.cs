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
        public class SirketYoneticisiEklemeResponse : BaseResponse
        {
        }
        public class SirketYoneticisiGuncel : BaseResponse
        {

        }

        public class SirketYoneticisiResponse : BaseResponse
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
        #region Harcamalar


        public class HarcamalarResponse : BaseResponse
        {
            public List<HarcamaResponse> Harcamalar { get; set; }
        }
        public class HarcamaResponse : BaseResponse
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
        #endregion

        #region Zimmetler
        public class ZimmetEkleResponse : BaseResponse
        {

        }
        public class ZimmetleriGetirResponse : BaseResponse
        {
            public List<ZimmetGetirResponse> Zimmetler { get; set; } = new List<ZimmetGetirResponse>();

        }
        public class ZimmetGetirResponse : BaseResponse
        {
            public int ZimmetId { get; set; }
            public int ZimmetTuruId { get; set; }
            public ZimmetTurResponse ZimmetTuru { get; set; } = new ZimmetTurResponse();
            public DateTime ZimmetTarihi { get; set; }
            public DateTime? ZimmetTeslimTarihi { get; set; }
            public bool TeslimEdildiMi { get; set; } = false;
            public int PersonelId { get; set; }
            public Durum Durumu { get; set; }
            public string NotIcerik { get; set; }
        }
        public enum Durum
        {
            KabulEdildi, Reddedildi, Beklemede
        }

        public class ZimmetTurResponse
        {
            public int ZimmetTuruId { get; set; }
            public string ZimmetTur { get; set; }
        }

        public class ZimmetTurleriResponse : BaseResponse
        {
            public List<ZimmetTurResponse> ZimmetTurleri { get; set; } = new List<ZimmetTurResponse>();
        }

        public class ZimmetSilResponse : BaseResponse
        {

        }
        public class ZimmetGuncelleResponse : BaseResponse
        {


        }
        #endregion

        #region Vardiyalar
        public class VardiyaTurEkleResponse : BaseResponse
        {

        }
        public class VardiyaTurSilResponse : BaseResponse
        {

        }
        public class VardiyaTurResponse : BaseResponse
        {

            public int VardiyaTurId { get; set; }
            public string VardiyaTuru { get; set; }
            public DateTime VardiyaBaslangicTarihi { get; set; }
            public DateTime VardiyaBitisTarihi { get; set; }
            public int SirketId { get; set; }
            public List<VardiyaResponse> Vardiyalar { get; set; } = new List<VardiyaResponse>();
        }
        public class VardiyaResponse : BaseResponse
        {
            public int VardiyaId { get; set; }
            public int PersonelId { get; set; }
            public int VardiyaTurId { get; set; }
        }
        public class VardiyaTurleriGetirResponse : BaseResponse
        {
            public List<VardiyaTurResponse> VardiyaTurleri { get; set; } = new List<VardiyaTurResponse>();
        }

        public class CalisanVardiyaMolaEkleResponse : BaseResponse
        {

        }
        #endregion

        #region Molalar

        public class MolaTurResponse : BaseResponse
        {
            public int MolaTurId { get; set; }
            public string MolaTuru { get; set; }
            public double MolaSuresi { get; set; }
            public int SirketId { get; set; }
            public List<MolaResponse> Molalar { get; set; } = new List<MolaResponse>();
        }
        public class MolaTurEkleResponse : BaseResponse
        {

        }
        public class MolaTurlerResponse : BaseResponse
        {
            public List<MolaTurResponse> MolaTurleri { get; set; } = new List<MolaTurResponse>();

        }
        public class MolaTurSilResponse : BaseResponse
        {

        }
        public class MolaResponse
        {
            public int MolaId { get; set; }
            public int MolaTurId { get; set; }
            public int PersonelId { get; set; }
            public DateTime OlusturulduguTarih { get; set; } = DateTime.Now;
        }

        #endregion


        public class SirketVerileri : BaseResponse
        {
            public int ZimmetSayisi { get; set; }
            public decimal AylikHarcama { get; set; }
            public int BekleyenIzinTalebiSayisi { get; set; }
        }
        public class YorumGuncelleResponse :BaseResponse
        {

        }
        public class YorumResponse : BaseResponse
        {

            public int YorumId { get; set; }
            public string YorumBaslik { get; set; }
            public string YorumIcerik { get; set; }
            public DateTime OlusturulmaTarihi { get; set; }
        }
        public class YorumEkleResponse : BaseResponse
        {

        }
    }
}
