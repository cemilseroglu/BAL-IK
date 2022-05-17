using Microsoft.AspNetCore.Http;

namespace BAL_IK.UI.ViewModels
{
    public class SirketViewModel
    {
        public string SirketAdi { get; set; }
        public string SirketEmail { get; set; }
        public string SirketAdresi { get; set; }
        public string SirketTelefonu { get; set; }
        public IFormFile SirketLogosu { get; set; }
        public OdemePlani OdemePlani { get; set; }
    }
    public enum OdemePlani
    {
        Aylık, Yıllık
    }
}
