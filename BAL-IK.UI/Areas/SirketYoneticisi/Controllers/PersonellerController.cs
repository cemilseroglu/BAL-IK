using BAL_IK.Data.Interfaceler.SirketYoneticisi;
using BAL_IK.UI.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BAL_IK.UI.Areas.SirketYoneticisi.Controllers
{
    [SirketYoneticisi]
    [Area("SirketYoneticisi")]
    public class PersonellerController : Controller
    {
        private readonly ISirketYoneticisiServis _syServis;

        public PersonellerController(ISirketYoneticisiServis _syServis)
        {
            this._syServis = _syServis;
        }
        public IActionResult Index()
        {
            return View();            
        }
        public IActionResult HarcamalarYonetim()
        {
            //TODO HARCAMALAR
            //1. Harcamalar Listelenecek. Harcamalar Getir API/Harcamalara ulaşma şekli ŞirkeyYöneticisi>Şirket>Personeller>(Tamamladı)
            //2. Harcama onaylama API yazılacak Onaylandığı zaman ait olduğu zamanın personelin maaş bilgisine eklenecek.(Maaş kısmının oluşturulması lazım tamamlanabilmesi için)
           

            var sirketYoneticisiGuid = HttpContext.Session.GetString("sirketYoneticisi");
            var response = _syServis.HarcamalariGetir(sirketYoneticisiGuid);
            return View(response);
        }
        public IActionResult BelgeGoruntule(string belge)
        {
            ViewBag.belge = belge;
            return View();
        }
    }
}
