using BAL_IK.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BAL_IK.Model.RequestClass.SiteYoneticisiIslemleriRequest;

namespace BAL_IK.Data.Interfaceler
{
    public interface ISiteYoneticisiService
    {
        int SiteYoneticisiKaydet(SiteYoneticisiEkle sy);
        List<SirketYoneticisi> SirketYoneticileriGetir();
        //List<Sirket> SirketleriGetir();
    }
}
