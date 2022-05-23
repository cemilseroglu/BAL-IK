using BAL_IK.Data.Context;
using BAL_IK.Data.Interfaceler.SirketYoneticisi;
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
using static BAL_IK.Model.ResponseClass.PersonelIslemleriResponse;
using static BAL_IK.Model.ResponseClass.SirketYoneticisiIslemleriResponse;

namespace BAL_IK.Data.Servisler
{
    public class SirketYoneticisiServis : ISirketYoneticisiServis
    {
        private readonly BAL_IKContext _db;

        public SirketYoneticisiServis(BAL_IKContext db)
        {
            _db = db;
        }


        public SirketYoneticisiResponse SirketYoneticisiGetir(string guid)
        {
            SirketYoneticisiResponse resp = new SirketYoneticisiResponse();
            if (string.IsNullOrEmpty(guid))
            {
                resp.BasariliMi = false;
                resp.Mesaj = "Parametre boş olamaz.";
                return resp;
            }
            try
            {
                SirketYoneticisi sirketYoneticisi = _db.SirketYoneticileri.FirstOrDefault(x => x.Guid.ToString() == guid);
                if (sirketYoneticisi == null)
                {
                    resp.BasariliMi = false;
                    resp.Mesaj = "Kullanıcı bulunamadı";
                    return resp;
                }

                resp.SirketYoneticisiId = sirketYoneticisi.SirketYoneticisiId;
                resp.Eposta = sirketYoneticisi.Eposta;
                resp.Ad = sirketYoneticisi.Ad;
                resp.Soyad = sirketYoneticisi.Soyad;
                resp.Cinsiyet = sirketYoneticisi.Cinsiyet;
                resp.AktifMi = sirketYoneticisi.AktifMi;
                resp.SirketId = sirketYoneticisi.SirketId;
                resp.Guid = sirketYoneticisi.Guid;
                resp.DogumTarihi = sirketYoneticisi.DogumTarihi;

                resp.BasariliMi = true;
                resp.Mesaj = "Başarılı";

                return resp;

            }
            catch (Exception ex)
            {
                resp.BasariliMi = false;
                resp.Mesaj = ex.Message;
                throw;
            }
        }


        public SirketYoneticisiGuncel SirketYoneticisiGuncelle(SirketYoneticisiIslemleriRequest.SirketYoneticisiGuncelle sirketYoneticisi)
        {
            SirketYoneticisiGuncel resp = new SirketYoneticisiGuncel();

            try
            {
                SirketYoneticisi syoneticisi = _db.SirketYoneticileri.Include(x => x.Sirket).FirstOrDefault(x => x.SirketYoneticisiId == sirketYoneticisi.SirketYoneticisiId);
                if (sirketYoneticisi.Ad != null)
                    syoneticisi.Ad = sirketYoneticisi.Ad;
                if (sirketYoneticisi.Soyad != null)
                    syoneticisi.Soyad = sirketYoneticisi.Soyad;
                if (sirketYoneticisi.Eposta != null)
                    syoneticisi.Eposta = sirketYoneticisi.Eposta;
                if (sirketYoneticisi.Sifre != null)
                    syoneticisi.Sifre = sirketYoneticisi.Sifre;

                if (syoneticisi.DogumTarihi != sirketYoneticisi.DogumTarihi)
                    syoneticisi.DogumTarihi = sirketYoneticisi.DogumTarihi;
                syoneticisi.AktifMi = sirketYoneticisi.AktifMi;
                if (sirketYoneticisi.SirketId != null)
                    syoneticisi.SirketId = sirketYoneticisi.SirketId;


                syoneticisi.AktifMi = sirketYoneticisi.AktifMi;
                if (syoneticisi.AktifMi == false)
                {
                    syoneticisi.Sirket.Durum = Durum.Pasif;
                }
                _db.Update(syoneticisi);
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
        public HarcamalarResponse HarcamalariGetir(string guid)
        {
            HarcamalarResponse resp = new HarcamalarResponse();
            resp.Harcamalar = new List<HarcamaResponse>();
            try
            {
                SirketYoneticisi sirketYoneticisi = _db.SirketYoneticileri.Include(x => x.Sirket).FirstOrDefault(x => x.Guid.ToString() == guid);
                List<Harcamalar> harcamalar = _db.Harcamalar.Include(x => x.Personel).Where(x => x.Personel.SirketId == sirketYoneticisi.SirketId).ToList();

                foreach (var harcama in harcamalar)
                {
                    HarcamaResponse harcamaResponse = new HarcamaResponse()
                    {
                        BasariliMi = true,
                        PersonelId = harcama.PersonelId,
                        HarcamaId = harcama.HarcamaId,
                        HarcamaIsmi = harcama.HarcamaIsmi,
                        DosyaYolu = harcama.DosyaYolu,
                        HarcamaTutari = harcama.HarcamaTutari,
                        OlusturulmaZamani = harcama.OlusturulmaZamani,
                        OnayDurumu = harcama.OnayDurumu,
                        Mesaj = "Başarılı",

                    };
                    harcamaResponse.Personel.Ad = harcama.Personel.Ad;
                    harcamaResponse.Personel.AktifMi = harcama.Personel.AktifMi;
                    harcamaResponse.Personel.Cinsiyet = harcama.Personel.Cinsiyet;
                    // harcamaResponse.Personel.DepartmanId = harcama.Personel.DepartmanId;
                    harcamaResponse.Personel.DogumTarihi = harcama.Personel.DogumTarihi;
                    harcamaResponse.Personel.Eposta = harcama.Personel.Eposta;
                    harcamaResponse.Personel.Guid = harcama.Personel.Guid;
                    harcamaResponse.Personel.IseBaslama = harcama.Personel.IseBaslama;
                    harcamaResponse.Personel.IstenAyrilma = harcama.Personel.IstenAyrilma;
                    harcamaResponse.Personel.PersonelId = harcama.PersonelId;
                    harcamaResponse.Personel.Soyad = harcama.Personel.Soyad;
                    harcamaResponse.Personel.SirketId = harcama.Personel.SirketId;
                    // harcamaResponse.Personel.VardiyaId = harcama.Personel.VardiyaId;
                    harcamaResponse.Personel.YillikIzinHakki = harcama.Personel.YillikIzinHakki;
                    resp.Harcamalar.Add(harcamaResponse);
                }
                resp.Mesaj = "Harcamalar başarıyla getirildi";
                resp.BasariliMi = true;
                return resp;

            }
            catch (Exception ex)
            {

                resp.BasariliMi = false;
                resp.Mesaj = "Hata" + ex.Message;
                return resp;
            }
        }

        public SirketYoneticisiEklemeResponse SirketYoneticisiOlustur(SirketYoneticisiIslemleriRequest.SirketYoneticisiEkle sy)
        {
            throw new NotImplementedException();
        }

        public PersonelIslemleriResponse.PersonelEkleResponse PersonelEklemeIslemi(PersonelIslemleriRequest.PersonelEkle personel)
        {
            PersonelEkleResponse resp = new PersonelEkleResponse();

            try
            {
                Personeller newPers = new Personeller()
                {
                    Ad = personel.Ad,
                    Soyad = personel.Soyad,
                    Eposta = personel.Eposta,
                    Sifre = Tools.CreatePasswordHash("balik1234"),
                    AktifMi = false,
                    Cinsiyet = personel.Cinsiyet,
                    DogumTarihi = personel.DogumTarihi,
                    ResimUrl = personel.ResimUrl,
                    IseBaslama = personel.IseBaslama,
                    SirketId = personel.SirketId
                };
                _db.Add(newPers);
                _db.SaveChanges();
                resp.BasariliMi = true;
                resp.Mesaj = "Personel başarıyla eklendi.";
                return resp;
            }
            catch (Exception ex)
            {
                resp.BasariliMi = false;
                resp.Mesaj = ex.Message;
                return resp;
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


                pergun.Cinsiyet = pr.Cinsiyet;
                pergun.AktifMi = pr.AktifMi;
                pergun.SirketId = pr.SirketId;
                pergun.DepartmanId = pr.DepartmanId;
                pergun.VardiyaId = pr.VardiyaId;


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

        public OzlukBelgesiEkleResponse OzlukBelgesiEkle(PersonelIslemleriRequest.OzlukBelgesiEkle ozlukBelgesi)
        {
            OzlukBelgesiEkleResponse resp = new OzlukBelgesiEkleResponse();
            try
            {
                OzlukBelgesi ozluk = new OzlukBelgesi()
                {
                    OzlukBelgesiAdi = ozlukBelgesi.OzlukBelgesiAdi,
                    OzlukBelgesiYolu = ozlukBelgesi.OzlukBelgesiYolu,
                    OlusturulmaZamani = ozlukBelgesi.OlusturulmaZamani,
                    PersonelId = ozlukBelgesi.PersonelId,
                    SirketYoneticisiId = ozlukBelgesi.SirketYoneticisiId
                };
                _db.Add(ozluk);
                _db.SaveChanges();
                resp.BasariliMi = true;
                resp.Mesaj = "Özlük belgesi başarıyla eklendi.";
                return resp;

            }
            catch (Exception ex)
            {
                resp.BasariliMi = false;
                resp.Mesaj = ex.Message;
                return resp;
            }
        }
        public OzlukBelgesiGuncelleResponse OzlukBelgesiGuncelle(PersonelIslemleriRequest.OzlukBelgesiGuncelle ozlukBelgesiGuncelle)
        {
            OzlukBelgesiGuncelleResponse resp = new OzlukBelgesiGuncelleResponse();
            try
            {
                OzlukBelgesi ozluk = _db.OzlukBelgeleri.Find(ozlukBelgesiGuncelle.OzlukBelgesiId);
                if (ozluk == null)
                {
                    resp.Mesaj = "Kullanıcı bulunamadı.";
                    resp.BasariliMi = false;
                    return resp;
                }
                if (ozlukBelgesiGuncelle.OzlukBelgesiAdi != null)
                    ozluk.OzlukBelgesiAdi = ozlukBelgesiGuncelle.OzlukBelgesiAdi;
                if (ozlukBelgesiGuncelle.OzlukBelgesiYolu != null)
                    ozluk.OzlukBelgesiYolu = ozlukBelgesiGuncelle.OzlukBelgesiYolu;
                ozluk.OlusturulmaZamani = ozlukBelgesiGuncelle.OlusturulmaZamani;
                ozluk.SirketYoneticisiId = ozlukBelgesiGuncelle.SirketYoneticisiId;
                ozluk.PersonelId = ozlukBelgesiGuncelle.PersonelId;
                _db.Update(ozluk);
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

        public IzinEkleResponse IzinEkle(PersonelIslemleriRequest.IzinEkle izinEkle)
        {
            IzinEkleResponse resp = new IzinEkleResponse();
            try
            {
                Izinler izinler = new Izinler()
                {
                    IzinBaslangicTarihi = izinEkle.IzinBaslangicTarihi,
                    IzinBitisTarihi = izinEkle.IzinBitisTarihi,
                    IzinSuresi = izinEkle.IzinSuresi,
                    IzinIstemeTarihi = izinEkle.IzinIstemeTarihi,
                    IzinTur =
                    {
                        IzinTurId=izinEkle.IzinTur.IzinTurId,
                        IzinTur=izinEkle.IzinTur.IzinTur
                    },
                    OnayDurumu = izinEkle.OnayDurumu,
                    OnaylanmaTarihi = izinEkle.OnaylanmaTarihi,
                    ReddilmeNedeni = izinEkle.ReddilmeNedeni,
                    PersonelId = izinEkle.PersonelId,
                    SirketYoneticisiId = izinEkle.SirketYoneticisiId
                };
                _db.Add(izinler);
                _db.SaveChanges();
                resp.BasariliMi = true;
                resp.Mesaj = "İzinler başarıyla eklendi.";
                return resp;
            }
            catch (Exception ex)
            {
                resp.BasariliMi = false;
                resp.Mesaj = ex.Message;
                return resp;
            }
        }

        public IzinListelemeResponse IzinListele()
        {
            IzinListelemeResponse izinListesi = new IzinListelemeResponse();
            try
            {
                izinListesi.IzinListele = new List<IzinListeleResponse>();
                foreach (var izinler in _db.Izinler.Include(x => x.Personel).ToList())
                {
                    IzinListeleResponse izin = new IzinListeleResponse()
                    {
                        PersonelId = izinler.PersonelId,
                        IzinBaslangicTarihi = izinler.IzinBaslangicTarihi,
                        IzinBitisTarihi = izinler.IzinBitisTarihi,
                        IzinIstemeTarihi = izinler.IzinIstemeTarihi,
                        OnayDurumu = izinler.OnayDurumu,
                        IzinSuresi = izinler.IzinSuresi,
                        OnaylanmaTarihi = izinler.OnaylanmaTarihi,
                        IzinTurId = izinler.IzinTurId,
                        ReddilmeNedeni = izinler.ReddilmeNedeni
                    };
                    izin.BasariliMi = true;
                    izinListesi.IzinListele.Add(izin);
                }
                izinListesi.Mesaj = "Başarılı";
                izinListesi.BasariliMi = true;
                return izinListesi;
            }
            catch (Exception ex)
            {
                izinListesi.Mesaj = ex.Message;
                izinListesi.BasariliMi = false;
                return izinListesi;
            }
        }

        public PersonelSilResponse PersonelSil(int personelId)
        {
            PersonelSilResponse resp = new PersonelSilResponse();
            try
            {
                Personeller pers = _db.Personeller.Find(personelId);
                pers.AktifMi = false;
                _db.Update(pers);
                _db.SaveChanges();
                resp.Mesaj = "Başarılı";
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
    }
}