using static BAL_IK.Model.ResponseClass.SirketIslemleriResponse;
using static BAL_IK.Model.ResponseClass.SirketYoneticisiIslemleriResponse;

namespace BAL_IK.UI.ViewModels
{
    public class SirketYoneticisiAnaSayfaWM
    {
        public SirketVerileri GelenVeriler { get; set; }=new SirketVerileri();
        public PersonelleriGetirResponse Personeller { get; set; }=new PersonelleriGetirResponse();
        public HarcamalarResponse Harcamalar { get; set; } = new HarcamalarResponse();
    }
}
