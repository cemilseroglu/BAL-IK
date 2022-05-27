using BAL_IK.Model.RequestClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BAL_IK.Model.RequestClass.PersonelIslemleriRequest;
using static BAL_IK.Model.ResponseClass.PersonelIslemleriResponse;

namespace BAL_IK.Data.Interfaceler.Personeller
{
    public interface IPersonellerServis
    {
        PersonelEkleResponse PersonelEkleme(PersonelEkle pr);
        PersonelListelemeResponse PersonelListeleme();
        PersonelGuncelleResponse PersonelGuncelleme(PersonelGuncelle pr);
        PersonelResp PersonelGetir(string guid);
        PersonelHarcamaEkle HarcamaEkleme(HarcamaEkle pr);
        HarcamaListelemeResponse HarcamalarıGetir();

        IzinlerResponse IzinleriGetir(string guid);
        VardiyalarResponse VardiyalariGetir(string guid);
        MolalarResponse MolalariGetir(string guid);
        EkleizinResponse Ekleizin(Ekleizin izinEkle);
        IzinTurlerResponse IzinTurleriGetir();



    }
}

