using System.Collections.Generic;
using static BAL_IK.Model.ResponseClass.PersonelIslemleriResponse;
using static BAL_IK.Model.ResponseClass.SirketIslemleriResponse;

namespace BAL_IK.UI.ViewModels
{
    public class ZimmetlerWM
    {
        public List<ZimmetResponse> Zimmetler { get; set; } = new List<ZimmetResponse>();
        public List<PersonelResp> Personeller { get; set; } = new List<PersonelResp>();
    }
}
