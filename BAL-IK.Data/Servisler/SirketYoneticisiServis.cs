﻿using BAL_IK.Data.Context;
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
using static BAL_IK.Model.ResponseClass.SirketIslemleriResponse;
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
                    syoneticisi.Sirket.Durum = Model.Entities.Durum.Pasif;
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

        public string HarcamaOnayla(int id, bool durum)
        {
            try
            {
                Harcamalar harcama = _db.Harcamalar.Find(id);
                if (harcama == null)
                    return "Bir Hata Oluştu";
                harcama.OnayDurumu = durum;
                _db.Update(harcama);
                MaasBilgisi maasBilgisi = _db.MaasBilgileri.FirstOrDefault(x => x.PersonelId == harcama.PersonelId && x.AlacagiTarih.Month == DateTime.Now.AddMonths(1).Month);
                if (maasBilgisi == null)
                {
                    return "Başarısız";
                }
                Personeller personel = _db.Personeller.Find(harcama.PersonelId);
                if (durum == true)
                {
                    maasBilgisi.MaasTutari += harcama.HarcamaTutari;
                    Tools.MailGonder(personel.Eposta, "Harcama Onayı", $"<p>Merhaba Sayın {personel.Ad}</p><p>{harcama.HarcamaIsmi} adlı {harcama.HarcamaTutari} TL Tutarlı harcamanız, {maasBilgisi.AlacagiTarih.ToShortDateString()} zamanında alacağınız maaşınıza eklenmiştir.<br/> O tarihte alacağınız maaş tutarı: {maasBilgisi.MaasTutari} TL</p><p>İyi Günler, İyi Çalışmalar.</p>");
                   
                }
                else
                {
                    maasBilgisi.MaasTutari -= harcama.HarcamaTutari;
                    Tools.MailGonder(personel.Eposta, "Harcama İptali", $"<p>Merhaba Sayın {personel.Ad}</p><p>{harcama.HarcamaIsmi} adlı {harcama.HarcamaTutari} TL Tutarlı harcama tutarı iptal edilmiştir, {maasBilgisi.AlacagiTarih.ToShortDateString()} zamanında alacağınız maaşınızdan bu işlem çıkarılmıştır.<br/> O tarihte alacağınız maaş tutarı: {maasBilgisi.MaasTutari} TL</p><p>İyi Günler, İyi Çalışmalar.</p>");
                }

                _db.Update(maasBilgisi);
                _db.SaveChanges();
                return "Harcama durumu değişti.";
            }
            catch (Exception ex)
            {
                return "Başarısız" + ex.Message;
            }
        }

        public ZimmetEkleResponse ZimmetEkle(SirketYoneticisiIslemleriRequest.ZimmetEkleRequest zimmet)
        {
            ZimmetEkleResponse resp = new ZimmetEkleResponse();
            try
            {
                Zimmetler yeniZimmet = new Zimmetler()
                {
                    ZimmetTuruId = zimmet.ZimmetTuruId,
                    PersonelId = zimmet.PersonelId,
                     ZimmetTarihi=DateTime.Now,
                };
                _db.Add(yeniZimmet);
                _db.SaveChanges();
                resp.Mesaj = "Zimmet başarıyla eklendi";
                resp.BasariliMi = true;
                Personeller personeller = _db.Personeller.Find(zimmet.PersonelId);
                Tools.MailGonder(personeller.Eposta, "Zimmet Atandı", $"<h4>Sayın {personeller.Ad} {personeller.Soyad}</h4><p>Şirketiniz tarafından tarafınıza zimmet ataması yapılmıştır lütfen sistemden kontrol ederek gerekli işlemlerinizi yapınız. </p><p>İyi günler, İyi çalışmalar</p>");
                return resp;
            }
            catch (Exception ex)
            {
                resp.Mesaj = ex.Message;
                resp.BasariliMi = false;
                return resp;
            }
        }

        public ZimmetleriGetirResponse ZimmetleriGetir(string guid)
        {
            ZimmetleriGetirResponse resp = new ZimmetleriGetirResponse();

            try
            {
                SirketYoneticisi sirketYoneticisi = _db.SirketYoneticileri.Include(x => x.Sirket).FirstOrDefault(x => x.Guid.ToString() == guid);
                List<int> personellerIds = _db.Personeller.Where(x => x.SirketId == sirketYoneticisi.SirketId).Select(x => x.PersonelId).ToList();
                foreach (var zimmet in _db.Zimmetler.Include(x => x.ZimmetTuru).ToList())
                {
                    if (personellerIds.Contains(zimmet.PersonelId))
                    {
                        ZimmetGetirResponse gidenZimmet = new ZimmetGetirResponse()
                        {
                            PersonelId = zimmet.PersonelId,
                            ZimmetTuruId = zimmet.ZimmetTuruId,
                            ZimmetTeslimTarihi = zimmet.ZimmetTeslimTarihi,
                            TeslimEdildiMi = zimmet.TeslimEdildiMi,
                            NotIcerik = zimmet.NotIcerik,
                            ZimmetId = zimmet.ZimmetId,
                            ZimmetTarihi = zimmet.ZimmetTarihi,
                            ZimmetTuru =
                            {
                                ZimmetTuruId = zimmet.ZimmetTuru.ZimmetTuruId,
                                ZimmetTur = zimmet.ZimmetTuru.ZimmetTur,
                            },
                            BasariliMi = true,
                        };
                        if (zimmet.Durumu == Durumu.KabulEdildi)
                            gidenZimmet.Durumu = SirketYoneticisiIslemleriResponse.Durum.KabulEdildi;
                        else if (zimmet.Durumu == Durumu.Reddedildi)
                            gidenZimmet.Durumu = SirketYoneticisiIslemleriResponse.Durum.Reddedildi;
                        else
                            gidenZimmet.Durumu = SirketYoneticisiIslemleriResponse.Durum.Beklemede;
                        resp.Zimmetler.Add(gidenZimmet);

                    }
                }
                resp.Mesaj = "Zimmetler başarıyla getirildi";
                resp.BasariliMi = true;
                return resp;

            }
            catch (Exception ex)
            {
                resp.BasariliMi = false;
                resp.Mesaj = ex.Message;
                return resp;
            }
        }

        public ZimmetTurleriResponse ZimmetTurleriniGetir()
        {
            ZimmetTurleriResponse resp = new ZimmetTurleriResponse();
            try
            {
                foreach (var zimmetTurDb in _db.ZimmetTurleri.ToList())
                {
                    ZimmetTurResponse zimmetTur = new ZimmetTurResponse()
                    {
                        ZimmetTur = zimmetTurDb.ZimmetTur,
                        ZimmetTuruId = zimmetTurDb.ZimmetTuruId
                    };
                    resp.ZimmetTurleri.Add(zimmetTur);
                }
                resp.BasariliMi = true;
                resp.Mesaj = "Zimmet Türleri Başarıyla Getirildi.";
                return resp;
            }
            catch (Exception ex)
            {
                resp.BasariliMi = false;
                resp.Mesaj = ex.Message;
                return resp;
            }
        }

        public ZimmetSilResponse ZimmetSil(int id)
        {
            ZimmetSilResponse resp = new ZimmetSilResponse();
            try
            {
                Zimmetler zimmet = _db.Zimmetler.Include(x => x.ZimmetTuru).FirstOrDefault(x => x.ZimmetId == id);
                _db.Remove(zimmet);
                _db.SaveChanges();
                resp.Mesaj = "Zimmet silindi";
                resp.BasariliMi = true;
                Personeller personeller = _db.Personeller.Find(zimmet.PersonelId);
                Tools.MailGonder(personeller.Eposta, "Zimmet Silindi", $"<h4>Sayın {personeller.Ad} {personeller.Soyad}</h4><p>Şirketiniz tarafından üzerinize kayıtlı {zimmet.ZimmetTuru.ZimmetTur} türünde bir zimmet silinmiştir. </p><p>İyi günler, İyi çalışmalar</p>");


                return resp;

            }
            catch (Exception ex)
            {
                resp.Mesaj = ex.Message;
                resp.BasariliMi = false;
                return resp;
            }
        }

        public ZimmetGuncelleResponse ZimmetGuncelle(SirketYoneticisiIslemleriRequest.ZimmetGuncelleRequest req)
        {
            ZimmetGuncelleResponse resp = new ZimmetGuncelleResponse();

            try
            {
                Zimmetler guncelZimmet = _db.Zimmetler.Include(x => x.ZimmetTuru).FirstOrDefault(x => x.ZimmetId == req.ZimmetId);
                guncelZimmet.ZimmetTuruId = req.ZimmetTuruId;
                guncelZimmet.Durumu = Durumu.Beklemede;
                guncelZimmet.TeslimEdildiMi = false;
                guncelZimmet.ZimmetTarihi = DateTime.Now;
                _db.Update(guncelZimmet);
                _db.SaveChanges();
                resp.BasariliMi = true;
                resp.Mesaj = "Zimmet güncellendi";
                Personeller personeller = _db.Personeller.Find(guncelZimmet.PersonelId);
                Tools.MailGonder(personeller.Eposta, "Zimmet Güncellendi", $"<h4>Sayın {personeller.Ad} {personeller.Soyad}</h4><p>Şirketiniz tarafından üzerinize kayıtlı zimmet güncellemesi yapılmıştır lütfen sistemden gerekli işlemleri yapınız. </p><p>İyi günler, İyi çalışmalar</p>");
                return resp;
            }
            catch (Exception ex)
            {
                resp.Mesaj = ex.Message;
                resp.BasariliMi = false;
                return resp;
            }
        }

        public SirketIslemleriResponse.PersonelleriGetirResponse PersonelleriGetir()
        {
            PersonelleriGetirResponse resp = new PersonelleriGetirResponse();
            try
            {
                foreach (var personelDb in _db.Personeller.ToList())
                {
                    PersonelResponse personel = new PersonelResponse()
                    {
                        PersonelId = personelDb.PersonelId,
                        DepartmanId = personelDb.DepartmanId,
                        IseBaslama = personelDb.IseBaslama,
                        IstenAyrilma = personelDb.IstenAyrilma,
                        SirketId = personelDb.SirketId,
                        TemelMaasBilgisi = personelDb.TemelMaasBilgisi,
                        VardiyaId = personelDb.VardiyaId,
                        YillikIzinHakki = personelDb.YillikIzinHakki,
                        Ad = personelDb.Ad,
                        AktifMi = personelDb.AktifMi,
                        Cinsiyet = personelDb.Cinsiyet,
                        DogumTarihi = personelDb.DogumTarihi,
                        Eposta = personelDb.Eposta,
                        Guid = personelDb.Guid,
                        Soyad = personelDb.Soyad,
                    };
                    resp.Personeller.Add(personel);
                }
                resp.BasariliMi = true;
                resp.Mesaj = "Personeller getirildi";
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
