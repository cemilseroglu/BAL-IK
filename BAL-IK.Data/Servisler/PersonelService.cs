using BAL_IK.Data.Context;
using BAL_IK.Data.Interfaceler.Personeller;
using BAL_IK.Model.Entities;
using BAL_IK.Model.RequestClass;
using BAL_IK.Model.ResponseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BAL_IK.Model.ResponseClass.PersonelIslemleriResponse;

namespace BAL_IK.Data.Servisler
{
    public class PersonelService : IPersonellerServis
    {
        private readonly BAL_IKContext _db;

        public PersonelService(BAL_IKContext db)
        {
            _db = db;
        }
        public PersonelIslemleriResponse.PersonelEkleResponse PersonelEkleme(PersonelIslemleriRequest.PersonelEkle pr)
        {
            PersonelEkleResponse resp = new PersonelEkleResponse();
            try
            {
                Personeller personel = new Personeller()
                {
                    Ad = pr.Ad,
                    AktifMi = pr.AktifMi,
                    DepartmanId = pr.DepartmanId,
                    DogumTarihi = pr.DogumTarihi,
                    Eposta = pr.Eposta,
                    IseBaslama = pr.IseBaslama,
                    Sifre = pr.Sifre,
                    Soyad = pr.Soyad,
                    SirketId = pr.SirketId,
                    ResimUrl = pr.ResimUrl,
                    VardiyaId = pr.VardiyaId,
                    YillikIzinHakki = pr.YillikIzinHakki,
                    Cinsiyet = pr.Cinsiyet
                };
                _db.Add(personel);
                _db.SaveChanges();
                resp.Mesaj = ("Başarılı");
                resp.BasariliMi = true;
                return resp;
               
            }
            catch (Exception ex)
            {
                resp.Mesaj = ex.Message;
                resp.BasariliMi = false;
                return resp;
            }


        }

        public PersonelIslemleriResponse.PersonelListelemeResponse PersonelListeleme()
        {
            throw new NotImplementedException();
        }
    }
}
