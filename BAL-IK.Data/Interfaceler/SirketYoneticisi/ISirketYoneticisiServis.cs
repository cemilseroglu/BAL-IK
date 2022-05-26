using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BAL_IK.Model.RequestClass.PersonelIslemleriRequest;
using static BAL_IK.Model.RequestClass.SirketYoneticisiIslemleriRequest;

using static BAL_IK.Model.ResponseClass.PersonelIslemleriResponse;

using static BAL_IK.Model.ResponseClass.SirketIslemleriResponse;

using static BAL_IK.Model.ResponseClass.SirketYoneticisiIslemleriResponse;
using BAL_IK.Model.Entities;

namespace BAL_IK.Data.Interfaceler.SirketYoneticisi
{
    public interface ISirketYoneticisiServis
    {
        SirketYoneticisiGuncel SirketYoneticisiGuncelle(SirketYoneticisiGuncelle sy);
        SirketYoneticisiResponse SirketYoneticisiGetir(string guid);
        SirketYoneticisiEklemeResponse SirketYoneticisiOlustur(SirketYoneticisiEkle sy);
        HarcamalarResponse HarcamalariGetir(string guid);

        PersonelEkleResponse PersonelEklemeIslemi(PersonelEkle personel);
        PersonelGuncelleResponse PersonelGuncelleme(PersonelGuncelle pr);
        OzlukBelgesiEkleResponse OzlukBelgesiEkle(OzlukBelgesiEkle ozlukBelgesi);
        OzlukBelgesiGuncelleResponse OzlukBelgesiGuncelle(OzlukBelgesiGuncelle ozlukBelgesiGuncelle);
        OzlukBelgesiSilResponse OzlukBelgesiSil(int ozlukBelgesiId);

        EkleizinResponse Ekleizin(Ekleizin izinEkle);
        ListelemeizinResponse Listeleizin();
        PersonelSilResponse PersonelSil(int personelId);   
        PersonelleriGetirResponse PersonelleriGetir(string guid);

        string HarcamaOnayla(int id, bool durum);

        #region Zimmet        

        ZimmetEkleResponse ZimmetEkle(ZimmetEkleRequest zimmet);

        ZimmetleriGetirResponse ZimmetleriGetir(string guid);
        ZimmetTurleriResponse ZimmetTurleriniGetir();
        ZimmetSilResponse ZimmetSil(int id);
        ZimmetGuncelleResponse ZimmetGuncelle(ZimmetGuncelleRequest req);
        #endregion

        #region Vardiya      
        VardiyaTurEkleResponse VardiyaTurEkle(VardiyaTurEkleRequest req);
        VardiyaTurSilResponse VardiyaTurSil(int vardiyaTurId);
        VardiyaTurleriGetirResponse VardiyaTurleriGetir(string guid);
        CalisanVardiyaMolaEkleResponse CalisanVardiyaEkle(CalisanVardiyaMolaEkleRequest req);
        #endregion

        #region Mola
        MolaTurEkleResponse MolaTurEkle(MolaTurRequest req);
        MolaTurSilResponse MolaTurSil(int id);
        MolaTurlerResponse MolaTurleriGetir(string guid);
        #endregion
    }
}
