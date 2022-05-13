using BAL_IK.Data.Context;
using BAL_IK.Data.Interfaceler;
using BAL_IK.Model.Entities;
using BAL_IK.Model.RequestClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public int SiteYoneticisiKaydet(SiteYoneticisiIslemleriRequest.SiteYoneticisiEkle sy)
        {
            SiteYoneticisi yonetici = new SiteYoneticisi()
            {
                Ad=sy.Ad,
                AktifMi=sy.AktifMi,
                DogumTarihi=sy.DogumTarihi,
                Eposta=sy.Eposta,
                ResimUrl=sy.ResimUrl,
                Sifre=sy.Sifre,
                Soyad=sy.Soyad
                
            };
            _db.Add(yonetici);
            return _db.SaveChanges();

        }

        //public List<Sirket> SirketleriGetir()
        //{
        //    return _db.Sirketler.ToList();
        //}
    }
}
