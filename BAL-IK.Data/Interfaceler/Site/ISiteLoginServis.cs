using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BAL_IK.Model.RequestClass.LogIslemleriRequest;
using static BAL_IK.Model.ResponseClass.LogIslemleriResponse;

namespace BAL_IK.Data.Interfaceler.Site
{
    public interface ISiteLoginServis
    {
        LoginKullanici LoginIslemi(LogKullanici log);
    }
}
