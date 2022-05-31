using static BAL_IK.Model.RequestClass.SirketYoneticisiIslemleriRequest;
using static BAL_IK.Model.ResponseClass.SirketYoneticisiIslemleriResponse;

namespace BAL_IK.UI.ViewModels
{
    public class YorumEkleWM
    {
        public YorumResponse YorumResponse { get; set; }=new YorumResponse();
        public YorumEkleResponse YorumEkleResponse { get; set; }=new YorumEkleResponse();
        public YorumGuncelleResponse YorumGuncelle { get; set; }=new YorumGuncelleResponse();

        public YorumEkleRequest YorumEkleRequest { get; set; } = new YorumEkleRequest();
        public YorumGuncelleRequest YorumGuncelleRequest { get; set; }= new YorumGuncelleRequest();
    }
}
