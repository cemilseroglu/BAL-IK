using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_IK.Model.RequestClass
{
    public class LogIslemleriRequest
    {
        public class LogKullanici
        {
            public string Email { get; set; }
            public string Sifre { get; set; }
        }
        public class KayitKullaniciReq
        {
            public string Email { get; set; }
            public string Sifre { get; set; }
            public string Ad { get; set; }
            public string Soyad { get; set; }
        }
    }
}
