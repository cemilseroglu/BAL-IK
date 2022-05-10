﻿using BAL_IK.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_IK.Model
{
    public class Vardiyalar
    {
        public int VardiyaID { get; set; }
        public int PersonelID { get; set; }
        public Personeller Personel { get; set; }
        public VardiyaTuru VardiyaTuru { get; set; }
        public DateTime VardiyaBaslangicTarihi { get; set; }
        public DateTime VardiyaBitisTarihi { get; set; }  //10 gün gece 10 gün gündüz vardiyası şeklinde gibi...
    }

    public enum VardiyaTuru
    {
        GunduzVardiyasi, GeceVardiyasi
    }

}
