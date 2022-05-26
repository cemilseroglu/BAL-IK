using System.Collections.Generic;
using static BAL_IK.Model.RequestClass.SirketYoneticisiIslemleriRequest;
using static BAL_IK.Model.ResponseClass.SirketYoneticisiIslemleriResponse;

namespace BAL_IK.UI.ViewModels
{
    public class VardiyaTurSirketYoneticisiVM
    {
        public VardiyaTurEkleRequest VardiyaTurRequestVM { get; set; } =new VardiyaTurEkleRequest();
        public List<VardiyaTurResponse> VardiyaTurleri { get; set; } = new List<VardiyaTurResponse>();
    }
}
