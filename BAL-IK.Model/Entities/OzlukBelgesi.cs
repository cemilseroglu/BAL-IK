using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_IK.Model.Entities
{
    public class OzlukBelgesi
    {
        public int OzlukBelgesiId { get; set; }
        public int PersonelID { get; set; }
        public Personeller Personel { get; set; }
        public string OzlukBelgesiAdi { get; set; }
        public string OzlukBelgesiYolu { get; set; }
        public DateTime OlusturulmaZamani { get; set; }
        public int SirketYoneticisiId { get; set; }  //attribute ile kolon ismi verilebilir daha sonrasında.
        public SirketYoneticisi SirketYoneticisi { get; set; }
    }
}
