using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BAL_IK.Data.Servisler
{
    public class Tools
    {
        public static string CreatePasswordHash(string sifre)
        {
            string sifreHash = "";

            var provider = new SHA1CryptoServiceProvider();
            var encoding = new UnicodeEncoding();
            var passwordBytes = provider.ComputeHash(encoding.GetBytes(sifre + "KUCUKBALIKBUYUKBALIGIYEDIBUKEZ"));
            sifreHash = Convert.ToBase64String(passwordBytes);

            return sifreHash;
        }
    }
}
