using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_IK.Model.Entities
{
    public class Izinler
    {       
        public int IzinId { get; set; }   
        public int IzinTurId { get; set; }
        public IzinTuru IzinTur { get; set; }
        public int IzinSuresi { get; set; }    
        public string ReddilmeNedeni { get; set; }      
        public DateTime IzinIstemeTarihi { get; set; }
        public DateTime OnaylanmaTarihi { get; set; }
        public DateTime IzinBaslangicTarihi { get; set; } 
        public DateTime IzinBitisTarihi { get; set; }
        public int PersonelId { get; set; }
        public Personeller Personel { get; set; }
        public int SirketYoneticisiId { get; set; }
        public SirketYoneticisi SirketYoneticisi { get; set; }    
        public OnayDurumu OnayDurumu { get; set; } 
    }

    public enum OnayDurumu
    {
        Reddedildi,Onaylandi,OnayBekliyor
    }
}
