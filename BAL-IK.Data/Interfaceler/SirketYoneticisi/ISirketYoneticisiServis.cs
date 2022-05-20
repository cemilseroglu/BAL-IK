using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BAL_IK.Model.RequestClass.SirketYoneticisiIslemleriRequest;
using static BAL_IK.Model.ResponseClass.SirketYoneticisiIslemleriResponse;

namespace BAL_IK.Data.Interfaceler.SirketYoneticisi
{
    public interface ISirketYoneticisiServis
    {
        SirketYoneticisiGuncel SirketYoneticisiGuncelle(SirketYoneticisiGuncelle sy);
        SirketYoneticisiResponse SirketYoneticisiGetir(string guid);
        HarcamalarResponse HarcamalariGetir(string guid);

    }
}
