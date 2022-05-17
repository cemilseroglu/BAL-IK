using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

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

    }
}
