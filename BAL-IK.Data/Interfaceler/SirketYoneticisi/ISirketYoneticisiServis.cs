using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BAL_IK.Model.RequestClass.PersonelIslemleriRequest;
using static BAL_IK.Model.RequestClass.SirketYoneticisiIslemleriRequest;
using static BAL_IK.Model.ResponseClass.PersonelIslemleriResponse;
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
        IzinEkleResponse IzinEkle(IzinEkle izinEkle);
        IzinListelemeResponse IzinListele();
        PersonelSilResponse PersonelSil(int personelId);   
    }
}
