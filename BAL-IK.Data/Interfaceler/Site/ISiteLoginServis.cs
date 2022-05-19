using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BAL_IK.Model.RequestClass.LogIslemleriRequest;
using static BAL_IK.Model.ResponseClass.LogIslemleriResponse;
using static BAL_IK.Model.ResponseClass.SiteIslemleriResponse;

namespace BAL_IK.Data.Interfaceler.Site
{
    public interface ISiteLoginServis
    {
        LoginKullanici LoginIslemi(LogKullanici log);
        KayitKullaniciResp KayitIslemi(KayitKullaniciReq req);
        YorumlarResponse YorumlariGetir();
    }
}
