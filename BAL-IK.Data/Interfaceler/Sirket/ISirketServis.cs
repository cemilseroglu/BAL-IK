using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BAL_IK.Model.RequestClass.SirketIslemleriRequest;
using static BAL_IK.Model.ResponseClass.SirketIslemleriResponse;

namespace BAL_IK.Data.Interfaceler.Sirket
{
    public interface ISirketServis
    {
        SirketEkleResponse SirketEkle(SirketEkleRequest sirketRequest);
    }
}
