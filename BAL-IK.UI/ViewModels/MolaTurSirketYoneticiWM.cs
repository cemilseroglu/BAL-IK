using System.Collections.Generic;
using static BAL_IK.Model.RequestClass.SirketYoneticisiIslemleriRequest;
using static BAL_IK.Model.ResponseClass.SirketYoneticisiIslemleriResponse;

namespace BAL_IK.UI.ViewModels
{
    public class MolaTurSirketYoneticiWM
    {
        public List<MolaTurResponse> MolaTurleri { get; set; } = new List<MolaTurResponse>();
        public MolaTurRequest MolaTur { get; set; }
    }
}
