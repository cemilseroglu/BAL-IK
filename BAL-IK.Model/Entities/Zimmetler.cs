using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_IK.Model.Entities
{
    public class Zimmetler
    {
        public int ZimmetId { get; set; }
        public int ZimmetTuruId { get; set; }
        public ZimmetTuru ZimmetTuru { get; set; }
        public DateTime ZimmetTarihi { get; set; }
        public DateTime ZimmetTeslimTarihi { get; set; }
        public bool TeslimEdildiMi { get; set; }
        public int PersonelId { get; set; }
        public Personeller Personel { get; set; }  //status enum tutulabilir. ---- redderse yorum içeriği de olmalı.
        public Durumu Durumu { get; set; }
        public string NotIcerik { get; set; }
    }

    public enum Durumu 
    { 
        KabulEdildi,Reddedildi
    }
}
