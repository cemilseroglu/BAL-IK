using System.Collections.Generic;
using static BAL_IK.Model.RequestClass.PersonelIslemleriRequest;
using static BAL_IK.Model.ResponseClass.PersonelIslemleriResponse;

namespace BAL_IK.UI.ViewModels
{
    public class PersonelIzinEkleWm
    {
        public List<IzinTurResponse> IzinTurler { get; set; } = new List<IzinTurResponse>();
        public Ekleizin Ekleizin { get; set; }
    }
}
