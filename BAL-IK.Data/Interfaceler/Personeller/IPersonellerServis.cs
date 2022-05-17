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
    }
}

