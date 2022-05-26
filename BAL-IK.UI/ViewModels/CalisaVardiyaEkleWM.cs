using System.Collections.Generic;
using static BAL_IK.Model.ResponseClass.PersonelIslemleriResponse;
using static BAL_IK.Model.ResponseClass.SirketIslemleriResponse;
using static BAL_IK.Model.ResponseClass.SirketYoneticisiIslemleriResponse;

namespace BAL_IK.UI.ViewModels
{
    public class CalisaVardiyaEkleWM
    {
        public int PersonelId { get; set; }
        public int VardiyaTurId { get; set; }
        public List<int> MolaTurIds { get; set; } = new List<int>();
        public List<MolaTurResponse> MolaTurleri { get; set; } = new List<MolaTurResponse>();
        public List<PersonelResponse> Personeller { get; set; } = new List<PersonelResponse>();
        public List<VardiyaTurResponse> VardiyaTurleri { get; set; } = new List<VardiyaTurResponse>();
    }
}
