using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_IK.Model.Entities
{
    public class Departmanlar
    {
        public int DepartmanId { get; set; }
        public string DepartmanAdi { get; set; }
        public string DepartmanAdresi { get; set; }
        public int SirketId { get; set; }
        public Sirket Sirketi { get; set; }
        public List<Personeller> Personelleri { get; set; }
    }
}
