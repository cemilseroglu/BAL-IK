using Microsoft.AspNetCore.Http;
using static BAL_IK.UI.Attributes.GecerliResim;

namespace BAL_IK.UI.ViewModels
{
    public class HarcamaViewModel
    {
        
    
        public int PersonelId { get; set; }
        public string HarcamaIsmi { get; set; }
        public decimal HarcamaTutari { get; set; }
        [GecerliResim(ResimMaxBoyutuMB = 3)]
        public IFormFile DosyaYolu { get; set; }
    }
}
