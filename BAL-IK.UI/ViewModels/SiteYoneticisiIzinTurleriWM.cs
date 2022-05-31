using BAL_IK.Model.Entities;
using static BAL_IK.Model.RequestClass.SiteYoneticisiIslemleriRequest;
using static BAL_IK.Model.ResponseClass.SiteYoneticisiIslemleriResponse;

namespace BAL_IK.UI.ViewModels
{
    public class SiteYoneticisiIzinTurleriWM
    {
        public IzinTurleriListeleResponse IzinTurleriListesi { get; set; } = new IzinTurleriListeleResponse();
        public IzinTuruEkleReq IzinTuruEkleReq { get; set; } = new IzinTuruEkleReq();
    }
}
