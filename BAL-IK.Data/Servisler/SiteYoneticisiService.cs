using BAL_IK.Data.Context;
using BAL_IK.Data.Interfaceler;
using BAL_IK.Model.Entities;
using BAL_IK.Model.RequestClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BAL_IK.Model.RequestClass.SiteYoneticisiIslemleriRequest;
using static BAL_IK.Model.ResponseClass.SiteYoneticisiIslemleriResponse;

namespace BAL_IK.Data.Servisler
{
    public class SiteYoneticisiService : ISiteYoneticisiService
    {
        private readonly BAL_IKContext _db;

        public SiteYoneticisiService(BAL_IKContext db )
        {
            _db = db;
        }

        public List<SirketYoneticisi> SirketYoneticileriGetir()
        {
            return _db.SirketYoneticileri.ToList();
        }

        public SiteYoneticileriniListeleResponse SiteYoneticileriniListele()
        {
            SiteYoneticileriniListeleResponse liste = new SiteYoneticileriniListeleResponse();
            liste.SiteYoneticisiListele = new List<SiteYoneticisiResp>();
            foreach (var item in _db.SiteYoneticileri)
            {
                SiteYoneticisiResp resp = new SiteYoneticisiResp()
                {
                    Ad = item.Ad,
                    Soyad = item.Soyad,
                    AktifMi = item.AktifMi,
                    DogumTarihi = item.DogumTarihi,
                    Eposta = item.Eposta,
                    ResimUrl = item.ResimUrl,
                    Guid = item.Guid,
                    Sifre = item.Sifre,
                    SiteYoneticisiId = item.SiteYoneticisiId,
                    Cinsiyet = item.Cinsiyet
                    
                };
                liste.SiteYoneticisiListele.Add(resp);
            }
            return liste;
        }

        public SiteYoneticisiEkleResponse SiteYoneticisiKaydet(SiteYoneticisiIslemleriRequest.SiteYoneticisiEkle sy)
        {
            SiteYoneticisi yonetici = new SiteYoneticisi()
            {
                Ad = sy.Ad,
                AktifMi = sy.AktifMi,
                DogumTarihi = sy.DogumTarihi,
                Eposta = sy.Eposta,
                ResimUrl = sy.ResimUrl,
                Sifre = sy.Sifre,
                Soyad = sy.Soyad,
                Cinsiyet = sy.Cinsiyet

            };
            _db.Add(yonetici);
            _db.SaveChanges();
            SiteYoneticisiEkleResponse resp = new SiteYoneticisiEkleResponse();
            resp.BasariliMi = true;
            resp.Mesaj = "Başarılı";
            return resp;
        }

        //public List<Sirket> SirketleriGetir()
        //{
        //    return _db.Sirketler.ToList();
        //}

        

        public SiteYoneticisiGuncelleResponse SiteYoneticisiGuncelleme(SiteYoneticisiGuncelle sy)
        {
            SiteYoneticisiGuncelleResponse resp = new SiteYoneticisiGuncelleResponse();
            try
            {

                SiteYoneticisi siteyongun = _db.SiteYoneticileri.Find(sy.SiteYoneticisiId);
                if (siteyongun == null)
                {
                    resp.Mesaj = "Kullanıcı Bulunamadı";
                    resp.BasariliMi = false;
                    return resp;
                }
                if (sy.Ad != null)
                    siteyongun.Ad = sy.Ad;
                if (siteyongun.Soyad != null)
                    siteyongun.Soyad = sy.Soyad;
                if (siteyongun.Eposta != null)
                    siteyongun.Eposta = sy.Eposta;
                if (sy.Sifre != null)
                    siteyongun.Sifre = Tools.CreatePasswordHash(sy.Sifre);
                siteyongun.DogumTarihi = sy.DogumTarihi.AddDays(1); // NEDEN ABİ NEDEN??? TODO: Hocaya sor...
                _db.Update(siteyongun);
                _db.SaveChanges();
                resp.BasariliMi = true;
                resp.Mesaj = "Başarıyla güncellendi.";
                return resp;
            }
            catch (Exception ex)
            {

                resp.BasariliMi = false;
                resp.Mesaj = ex.Message;
                return resp;
            }
        }

        public SiteYoneticisiResp SiteYoneticisiGetir(string guid)
        {
            SiteYoneticisiResp resp = new SiteYoneticisiResp();
            if(string.IsNullOrEmpty(guid))
            {
                resp.Mesaj = "Kullanıcı bulunamadı.";
                resp.BasariliMi= false;
                return resp;
            }
            try
            {
                SiteYoneticisi siteyoneticisi = _db.SiteYoneticileri.FirstOrDefault(x => x.Guid.ToString() == guid);
                if(siteyoneticisi ==null)
                {
                    resp.Mesaj = "Kullanıcı bulunamadı.";
                    resp.BasariliMi = false;
                    return resp;
                }
                resp.SiteYoneticisiId = siteyoneticisi.SiteYoneticisiId;
                resp.Eposta = siteyoneticisi.Eposta;
                resp.Cinsiyet = siteyoneticisi.Cinsiyet;
                resp.Ad = siteyoneticisi.Ad;
                resp.Soyad = siteyoneticisi.Soyad;
                resp.AktifMi = siteyoneticisi.AktifMi;
                resp.DogumTarihi = siteyoneticisi.DogumTarihi;
                resp.BasariliMi = true;
                resp.Mesaj = "Başarılı";
                resp.Guid = siteyoneticisi.Guid;
                return resp;
            }
            catch (Exception ex)
            {
                resp.BasariliMi = false;
                resp.Mesaj = ex.Message;
                throw;
            }
            
        }
    }
}
