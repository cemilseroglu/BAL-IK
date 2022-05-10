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
        public int SirketId { get; set; }
        [Required]
        public string SirketAdi { get; set; }
        public string SirketAdresi { get; set; }
        public string SirketTelefonu { get; set; }
        public string SirketEmail { get; set; }
        public string SirketLogoURL { get; set; }
        public Durum Durum { get; set; }
        public List<SirketYoneticisi> SirketYoneticileri { get; set; }  
        public List<Personeller> Personeller { get; set; }
        public List<Departmanlar> Departmanlar { get; set; }
        public DateTime KayitTarihi { get; set; }
        public DateTime UyelikBitisTarihi { get; set; }
    }

    public enum Durum
    {
        Aktif,Pasif,Askıda
    }
}
