using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_IK.Model.Entities
{
    public class Sirket
    {
        [Required, Key]
        public int SirketId { get; set; }
        [Required, MaxLength(50)]
        public string SirketAdi { get; set; }
        [Required, MaxLength(250)]
        public string SirketAdresi { get; set; }
        [MaxLength(13)]
        public string SirketTelefonu { get; set; }
        [MaxLength(50)]
        public string SirketEmail { get; set; }
        public string SirketLogoURL { get; set; }
        public OdemePlani OdemePlani { get; set; }
        public Durum Durum { get; set; } = Durum.Aktif;
        public List<SirketYoneticisi> SirketYoneticileri { get; set; }
        public List<Personeller> Personeller { get; set; }
        public List<Departmanlar> Departmanlar { get; set; }
        public DateTime KayitTarihi { get; set; } = DateTime.Now;
        public DateTime UyelikBitisTarihi { get; set; }
        public Yorum Yorumu { get; set; }
    }

    public enum Durum
    {
        Aktif, Pasif, Askıda
    }
    public enum OdemePlani
    {
        Aylik, Yillik
    }
}
