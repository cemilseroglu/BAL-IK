using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using static BAL_IK.UI.Areas.SirketYoneticisi.Controllers.HomeController;

namespace BAL_IK.UI
{
    public class Tools
    {  
        public static string resimKaydet(IFormFile resim, IWebHostEnvironment env)
        {
            string resimAdi = Guid.NewGuid() + Path.GetExtension(resim.FileName);

            string kaydetmeYolu = Path.Combine(env.WebRootPath, "Uploads", resimAdi);


            using (FileStream fs = new FileStream(kaydetmeYolu, FileMode.Create))
            {
                resim.CopyTo(fs);
            }

            return resimAdi;
        }
        public static async Task<GelenData> ResmiTatillerGetir()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.ubilisim.com/");
                var result = await client.GetAsync("resmitatiller");

                if (result.IsSuccessStatusCode)
                {
                    var data = await result.Content.ReadAsStringAsync();  //JSON formattan okuyacak hale getirdik.
                    var durum = JsonConvert.DeserializeObject<GelenData>(data);

                    return durum;

                }
                else
                    return null;
            }
        }

    }
}
