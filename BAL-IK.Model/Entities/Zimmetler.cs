using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_IK.Model.Entities
{
    public class Zimmetler
    {
        [Required,Key]
        public int ZimmetId { get; set; }
        [Required]
        public int ZimmetTuruId { get; set; }
        public ZimmetTuru ZimmetTuru { get; set; }
        public DateTime ZimmetTarihi { get; set; }
        public DateTime? ZimmetTeslimTarihi { get; set; }
        public bool TeslimEdildiMi { get; set; } = false;
        [Required]
        public int PersonelId { get; set; }
        public Personeller Personel { get; set; }
        public Durumu Durumu { get; set; } = Durumu.Beklemede;
        public string NotIcerik { get; set; }
    }

    public enum Durumu 
    { 
        KabulEdildi,Reddedildi,Beklemede
    }
}
