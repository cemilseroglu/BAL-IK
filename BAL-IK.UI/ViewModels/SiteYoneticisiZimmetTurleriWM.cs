using static BAL_IK.Model.RequestClass.SiteYoneticisiIslemleriRequest;
using static BAL_IK.Model.ResponseClass.SiteYoneticisiIslemleriResponse;

namespace BAL_IK.UI.ViewModels
{
    public class SiteYoneticisiZimmetTurleriWM
    {
        public ZimmetTurleriListeleResponse ZimmetTurleriListesi { get; set; } = new ZimmetTurleriListeleResponse();
        public ZimmetTuruEkleReq ZimmetTuruEkleReq { get; set; } = new ZimmetTuruEkleReq();
    }
}
