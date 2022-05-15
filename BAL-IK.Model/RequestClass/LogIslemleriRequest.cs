using System;
using System.Collections.Generic;
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
    }
}
