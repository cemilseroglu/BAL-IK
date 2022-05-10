using BAL_IK.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_IK.Model
{
    public class Mola
    {
        public int MolaID { get; set; }
        public MolaAdi MolaAdi { get; set; }
        public int PersonelID { get; set; }
        public Personeller Personel { get; set; }
        public DateTime OlusturulduguTarih { get; set; }
        public double MolaSuresi { get; set; }
    }
    public enum MolaAdi
    {
        ÇayMolası, YemekMolası
    }
}
