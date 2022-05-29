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
        SirketGuncelleResponse SirketGuncelleme(SirketGuncelle sy);
        SirketListeleResponse SirketleriListele();
        SirketResp SirketGetir(int id);
        IzinTurleriListeleResponse IzinTurleriListele();
        IzinTurleriEkleResponse IzinTurleriEkle(IzinTuruEkleReq ıt);
        IzinTurleriGuncelleResponse IzinTurleriGuncelleme(IzinTuruGuncelle ıtgun);
        IzinTurleriResponse IzinTuruGetir(int id);
        IzinTuruSilResponse IzinTuruSil(int id);
        ZimmetTurleriListeleResponse ZimmetTurleriListele();
        ZimmetTurleriEkleResponse ZimmetTurleriEkle(ZimmetTuruEkleReq ıt);
        ZimmetTurleriGuncelleResponse ZimmetTurleriGuncelleme(ZimmetTuruGuncelle ıtgun);
        ZimmetTurleriResponse ZimmetTuruGetir(int id);
        ZimmetTuruSilResponse ZimmetTuruSil(int id);
        SirketSayisiResponse SirketSayisiGetir();
        SirketYoneticisiSayisiResponse SirketYoneticisiSayisiGetir();
        PersonelSayisiResponse PersonelSayisiGetir();
        AskiyaAlinacakSirketleriListeleResponse AskiyaAlinacakSirketleriListele();
        UyelikAskiyaAlmaResponse UyelikAskiyaAlma();
        //List<SiteYoneticisi> SiteYoneticileriGetir();
        //List<Sirket> SirketleriGetir();
    }
}
