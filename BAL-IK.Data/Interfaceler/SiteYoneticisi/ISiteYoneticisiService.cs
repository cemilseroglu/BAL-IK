using BAL_IK.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BAL_IK.Model.RequestClass.SiteYoneticisiIslemleriRequest;
using static BAL_IK.Model.ResponseClass.SiteYoneticisiIslemleriResponse;

namespace BAL_IK.Data.Interfaceler
{
    public interface ISiteYoneticisiService
    {
        SiteYoneticisiEkleResponse SiteYoneticisiKaydet(SiteYoneticisiEkle sy);
        SiteYoneticileriniListeleResponse SiteYoneticileriniListele();
        SiteYoneticisiResp SiteYoneticisiGetir(string guid);
        SiteYoneticisiGuncelleResponse SiteYoneticisiGuncelleme(SiteYoneticisiGuncelle sy);
        //List<SiteYoneticisi> SiteYoneticileriGetir();
        //List<Sirket> SirketleriGetir();
    }
}
