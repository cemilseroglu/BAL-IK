﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_IK.Model.Entities
{
    
    public class Personeller:BasePerson
    {
        public int PersonelId { get; set; }
        public int YillikIzinHakki { get; set; } //WHAT CAN I DO SOMETİMES?LOOK AT THE TABELA!
        public DateTime IseBaslama { get; set; }
        public DateTime IstenAyrilma { get; set; }
        public int SirketID { get; set; }
        public Sirket Sirket { get; set; }
        public int DepartmanID { get; set; }
        public Departmanlar Departman { get; set; }

        

        public List<Zimmetler> Zimmetler { get; set; }
        public List<Izinler> Izinler { get; set; }
        public List<OzlukBelgesi> OzlukBelgeleri { get; set; } 
        public List<Mola> Molalar { get; set; }
        public List<MaasBilgisi> MaasBilgileri { get; set; }
        public List<Vardiyalar> Vardiyalar { get; set; }
        public List<Harcamalar> Harcamalar { get; set; }
        public List<Prim> Primler { get; set; }
    }
}
