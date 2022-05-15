using BAL_IK.Data.Context;
using BAL_IK.Data.Interfaceler.Site;
using BAL_IK.Model.Entities;
using BAL_IK.Model.RequestClass;
using BAL_IK.Model.ResponseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BAL_IK.Model.ResponseClass.LogIslemleriResponse;

namespace BAL_IK.Data.Servisler
{
    public class SiteLoginServis : ISiteLoginServis
    {
        private readonly BAL_IKContext _db;

        public SiteLoginServis(BAL_IKContext db)
        {
            this._db = db;
        }
        public LogIslemleriResponse.LoginKullanici LoginIslemi(LogIslemleriRequest.LogKullanici log)
        {
            LoginKullanici resp=new LoginKullanici();
            if(string.IsNullOrEmpty(log.Email)||string.IsNullOrEmpty(log.Sifre))
            {
                resp.Mesaj = "Kullanıcı adı veya şifresi girilmedi.";
                resp.BasariliMi = false;
                return resp;
            }
            //string hashSifre = Tools.CreatePasswordHash(log.Sifre);
            string hashSifre = log.Sifre;
            try
            {
                SiteYoneticisi siteYoneticisi = _db.SiteYoneticileri.FirstOrDefault(x => x.Eposta == log.Email && x.Sifre == hashSifre);
                Personeller personel= _db.Personeller.FirstOrDefault(x => x.Eposta == log.Email && x.Sifre == hashSifre);
                SirketYoneticisi sirketYoneticisi = _db.SirketYoneticileri.FirstOrDefault(x => x.Eposta == log.Email && x.Sifre == hashSifre);

                if (siteYoneticisi!=null)
                {
                    return response("siteYoneticisi",siteYoneticisi.Guid.ToString());
                }
                else if(personel!=null)
                {
                    return response("personel", personel.Guid.ToString());
                }
                else if(sirketYoneticisi!=null)
                {
                    return response("sirketYoneticisi", sirketYoneticisi.Guid.ToString());
                }
                else
                {
                    resp.BasariliMi = false;
                    resp.Mesaj = "Kullanıcı Adı veya Şifresi Yanlış";
                    return resp;
                }
              
            }
            catch (Exception ex)
            {
                resp.Mesaj = ex.Message;
                resp.BasariliMi = false;
                return resp;
             
            }
            LoginKullanici response(string kullaniciTuru,string Guid)
            {
                resp.KullaniciTuru=kullaniciTuru;
                resp.GirisGuid = Guid;
                resp.BasariliMi=true;
                resp.Mesaj="Giriş Başarılı";
                return resp;
            }
        }
    }
}
