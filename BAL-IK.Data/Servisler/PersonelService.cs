using BAL_IK.Data.Context;
using BAL_IK.Data.Interfaceler.Personeller;
using BAL_IK.Model;
using BAL_IK.Model.Entities;
using BAL_IK.Model.RequestClass;
using BAL_IK.Model.ResponseClass;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BAL_IK.Model.RequestClass.PersonelIslemleriRequest;
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

        public PersonelHarcamaEkle HarcamaEkleme(HarcamaEkle pr)
        {
            PersonelHarcamaEkle resp = new PersonelHarcamaEkle();
            try
            {
                Harcamalar harcama = new Harcamalar()
                {
                    HarcamaIsmi = pr.HarcamaIsmi,
                    HarcamaTutari = pr.HarcamaTutari,
                    PersonelId = pr.PersonelId,
                    DosyaYolu = pr.DosyaYolu
                };
                _db.Add(harcama);
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

        public PersonelIslemleriResponse.HarcamaListelemeResponse HarcamalarıGetir()
        {
            HarcamaListelemeResponse harcamaList = new HarcamaListelemeResponse();
            try
            {
                harcamaList.HarcamaListele = new List<HarcamaListeleResponse>();
                foreach (var harcamalar in _db.Harcamalar.Include(x => x.Personel).ToList())
                {
                    HarcamaListeleResponse harcama = new HarcamaListeleResponse()
                    {
                        HarcamaId = harcamalar.HarcamaId,
                        DosyaYolu = harcamalar.DosyaYolu,
                        HarcamaIsmi = harcamalar.HarcamaIsmi,
                        HarcamaTutari = harcamalar.HarcamaTutari,


                    };
                    harcama.BasariliMi = true;
                    harcamaList.HarcamaListele.Add(harcama);

                }
                harcamaList.Mesaj = "Başarılı";
                harcamaList.BasariliMi = true;
                return harcamaList;
            }
            catch (Exception)
            {
                harcamaList.Mesaj = "harcamaları getirirken hata oluştu";
                harcamaList.BasariliMi = false;
                return harcamaList;
            }
        }

        public IzinlerResponse IzinleriGetir(string guid)
        {
            IzinlerResponse resp = new IzinlerResponse();
            try
            {
                Personeller personel = _db.Personeller.Include(x => x.Izinler).FirstOrDefault(x => x.Guid.ToString() == guid);
                List<Izinler> izinlerList = _db.Izinler.Include(x => x.IzinTur).Where(x => x.PersonelId == personel.PersonelId).ToList();
                foreach (var izin in izinlerList)
                {
                    IzinResponse gidecekizin = new IzinResponse()
                    {
                        IzinId = izin.IzinId,
                        IzinBaslangicTarihi = izin.IzinBaslangicTarihi,
                        IzinBitisTarihi = izin.IzinBitisTarihi,
                        IzinIstemeTarihi = izin.IzinIstemeTarihi,
                        IzinSuresi = izin.IzinSuresi,
                        IzinTur = { IzinTurId = izin.IzinTur.IzinTurId, IzinTur = izin.IzinTur.IzinTur },
                        IzinTurId = izin.IzinTurId,
                        OnayDurumu = izin.OnayDurumu,
                        OnaylanmaTarihi = izin.OnaylanmaTarihi,
                        PersonelId = izin.PersonelId,
                        ReddilmeNedeni = izin.ReddilmeNedeni,
                        SirketYoneticisiId = izin.SirketYoneticisiId,


                    };
                    resp.Izinler.Add(gidecekizin);
                }
                resp.BasariliMi = true;
                resp.Mesaj = "İzinler başarıyla getirildi.";
                return (resp);
            }

            catch (Exception ex)
            {
                resp.Mesaj = "Izınler getirirken hata oluştu" + ex.Message;
                resp.BasariliMi = false;
                return resp;
            }

        }

        public IzinlerResponse IzinleriGetir()
        {
            throw new NotImplementedException();
        }

        public MolalarResponse MolalariGetir(string guid)
        {
            throw new NotImplementedException();
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
                    DogumTarihi = pr.DogumTarihi,
                    Eposta = pr.Eposta,
                    IseBaslama = pr.IseBaslama,
                    Soyad = pr.Soyad,
                    SirketId = pr.SirketId,
                    ResimUrl = pr.ResimUrl,
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

        public PersonelResp PersonelGetir(string guid)
        {
            PersonelResp resp = new PersonelResp();
            if (string.IsNullOrEmpty(guid))
            {
                resp.Mesaj = "Parametre boş olamaz.";
                resp.BasariliMi = false;
                return resp;

            }
            try
            {
                Personeller personeller = _db.Personeller.FirstOrDefault(x => x.Guid.ToString() == guid);
                if (personeller == null)
                {
                    resp.Mesaj = "Kullanıcı Bulunamadı";
                    resp.BasariliMi = false;
                    return resp;
                }
                resp.PersonelId = personeller.PersonelId;
                resp.Eposta = personeller.Eposta;
                resp.Cinsiyet = personeller.Cinsiyet;
                resp.Ad = personeller.Ad;
                resp.Soyad = personeller.Soyad;
                resp.AktifMi = personeller.AktifMi;
                resp.DepartmanId = personeller.DepartmanId;
                resp.DogumTarihi = personeller.DogumTarihi;
                resp.SirketId = personeller.SirketId;
                resp.VardiyaId = personeller.VardiyaId;
                resp.YillikIzinHakki = personeller.YillikIzinHakki;
                resp.IseBaslama = personeller.IseBaslama;
                resp.IstenAyrilma = personeller.IstenAyrilma;
                resp.BasariliMi = true;
                resp.Mesaj = "Başarılı";
                resp.Guid = personeller.Guid;
                return resp;
            }
            catch (Exception ex)
            {
                resp.BasariliMi = false;
                resp.Mesaj = ex.Message;
                throw;
            }

        }

        public PersonelGuncelleResponse PersonelGuncelleme(PersonelIslemleriRequest.PersonelGuncelle pr)
        {
            PersonelGuncelleResponse resp = new PersonelGuncelleResponse();

            try
            {

                Personeller pergun = _db.Personeller.Find(pr.PersonelId);
                if (pergun == null)
                {
                    resp.Mesaj = "Kullanıcı Bulunamadı";
                    resp.BasariliMi = false;
                    return resp;
                }
                if (pr.Ad != null)
                    pergun.Ad = pr.Ad;
                if (pr.Soyad != null)
                    pergun.Soyad = pr.Soyad;
                if (pr.Eposta != null)
                    pergun.Eposta = pr.Eposta;
                if (pr.Sifre != null)
                    pergun.Sifre = pr.Sifre;
                pergun.DogumTarihi = pr.DogumTarihi;
                _db.Update(pergun);
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

        public PersonelListelemeResponse PersonelListeleme()
        {
            throw new NotImplementedException();
        }


        public VardiyalarResponse VardiyalariGetir(string guid)
        {
            VardiyalarResponse resp = new VardiyalarResponse();
            try
            {
                Personeller personel = _db.Personeller.Include(x => x.Vardiya).FirstOrDefault(x => x.Guid.ToString() == guid);
                List<Vardiyalar> vardiyaList = _db.Vardiyalar.Include(x => x.VardiyaTur).Where(x => x.PersonelId == personel.PersonelId).ToList();
                foreach (var vardiya in vardiyaList)
                {
                    VardiyaResponse gidecekvardiya = new VardiyaResponse()
                    {
                        PersonelId = vardiya.PersonelId,
                        VardiyaId = vardiya.VardiyaId,
                        VardiyaTurId = vardiya.VardiyaTurId,
                        VardiyaTuru =
                        { 
                            VardiyaTurId = vardiya.VardiyaTur.VardiyaTurId,
                            VardiyaTuru = vardiya.VardiyaTur.VardiyaTuru, 
                            VardiyaBaslangicTarihi = vardiya.VardiyaTur.VardiyaBaslangicTarihi, 
                            VardiyaBitisTarihi = vardiya.VardiyaTur.VardiyaBitisTarihi 
                        }

                    };
                    resp.Vardiyalar.Add(gidecekvardiya);
                }
                resp.BasariliMi = true;
                resp.Mesaj = "Vardiyalar başarıyla getirildi.";
                return (resp);
            }

            catch (Exception ex)
            {
                resp.Mesaj = "Vardiyaları getirirken hata oluştu" + ex.Message;
                resp.BasariliMi = false;
                return resp;
            }

        }

        //public MolalarResponse MolalariGetir(string guid)
        //{
        //    MolalarResponse resp = new MolalarResponse();
        //    try
        //    {
        //        Personeller personel = _db.Personeller.Include(x => x.Vardiya).FirstOrDefault(x => x.Guid.ToString() == guid);
        //        List<Mola> molaList = _db.Molalar.Include(x => x.MolaTur).Where(x => x.Personeller. == personel.PersonelId).ToList();
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
    }
}
