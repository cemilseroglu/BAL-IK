using System.Collections.Generic;
using static BAL_IK.Model.ResponseClass.SirketIslemleriResponse;
using static BAL_IK.Model.ResponseClass.SirketYoneticisiIslemleriResponse;

namespace BAL_IK.UI.ViewModels
{
    public class ZimmetSirketYoneticisiViewModel
    {
        public List<PersonelResponse> Personeller { get; set; }
        public List<ZimmetTurResponse> ZimmetTurleri { get; set; }
        public List<ZimmetGetirResponse> Zimmetler { get; set; }
        public int PersonelId { get; set; }
        public int ZimmetTurId { get; set; }
        public int ZimmetId { get; set; }
    }
}
