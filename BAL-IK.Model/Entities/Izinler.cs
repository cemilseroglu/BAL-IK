using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_IK.Model.Entities
{
    public class Izinler
    {   
        [Required,Key]
        public int IzinId { get; set; } 
        [Required]
        public int IzinTurId { get; set; }
        public IzinTuru IzinTur { get; set; } 
        [Required]
        public int IzinSuresi { get; set; }        
        public string ReddilmeNedeni { get; set; }
        [Required]
        public DateTime IzinIstemeTarihi { get; set; }        
        public DateTime? OnaylanmaTarihi { get; set; }
        [Required]
        public DateTime IzinBaslangicTarihi { get; set; }
        [Required]
        public DateTime IzinBitisTarihi { get; set; }
        [Required]
        public int PersonelId { get; set; }
        public Personeller Personel { get; set; }      
        public int? SirketYoneticisiId { get; set; }
        public SirketYoneticisi SirketYoneticisi { get; set; }    
        public OnayDurumu OnayDurumu { get; set; } 
    }

    public enum OnayDurumu
    {
        Reddedildi,Onaylandi,OnayBekliyor
    }
}
