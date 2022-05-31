using static BAL_IK.Model.ResponseClass.SiteYoneticisiIslemleriResponse;

namespace BAL_IK.UI.ViewModels
{
    public class SiteYoneticisiIndexWM
    {
        public GelenData resmiTatiller { get; set; }
        public SirketSayisiResponse sirketSayisi { get; set; }= new SirketSayisiResponse();
        public SirketYoneticisiSayisiResponse sirketYoneticisiSayisi { get; set; }= new SirketYoneticisiSayisiResponse();
        public PersonelSayisiResponse personelSayisiResponse { get; set; }= new PersonelSayisiResponse();
        public AskiyaAlinacakSirketleriListeleResponse askiyaAlinacaklarListesi { get; set; } = new AskiyaAlinacakSirketleriListeleResponse();
        public UyelikAskiyaAlmaResponse askiyaAl { get; set; }= new UyelikAskiyaAlmaResponse();
    }
}
