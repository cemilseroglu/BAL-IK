using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Net;
using System.Net.Mail;
using System.Net.Http;
using Newtonsoft.Json;

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

        public static string MailGonder(string email, string baslik,string icerik)
        {

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("balik.yonetim@gmail.com", "balik1234");
            smtp.EnableSsl = true;
            smtp.Timeout = 10000;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("balik.yonetim@gmail.com", "BAL-IK Destek");
            mail.To.Add(email);

            mail.Subject = baslik;
            mail.Body = icerik;

            mail.IsBodyHtml = true;
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.BodyEncoding = System.Text.Encoding.UTF8;

            try
            {
                smtp.Send(mail);
                mail.Dispose();
                return "Mail başarıyla gönderildi.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}
