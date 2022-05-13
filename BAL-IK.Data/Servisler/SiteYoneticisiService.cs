using BAL_IK.Data.Context;
using BAL_IK.Data.Interfaceler;
using BAL_IK.Model.Entities;
using BAL_IK.Model.RequestClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BAL_IK.Model.ResponseClass.SiteYoneticisiIslemleriResponse;

namespace BAL_IK.Data.Servisler
{
    public class SiteYoneticisiService : ISiteYoneticisiService
    {
        private readonly BAL_IKContext _db;

        public SiteYoneticisiService(BAL_IKContext db)
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
                    SiteYoneticisiId = item.SiteYoneticisiId
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
                Soyad = sy.Soyad

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
    }
}
