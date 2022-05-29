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
                    SiteYoneticisiId = item.SiteYoneticisiId,
                    Cinsiyet = item.Cinsiyet

                };
                liste.SiteYoneticisiListele.Add(resp);
            }
            return liste;
        }

        public SirketListeleResponse SirketleriListele()
        {
            SirketListeleResponse liste = new SirketListeleResponse();
            liste.SirketListele = new List<SirketResp>();
            foreach (var item in _db.Sirketler.ToList())
            {
                SirketResp resp = new SirketResp()
                {
                    SirketId = item.SirketId,
                    SirketAdi = item.SirketAdi,
                    SirketAdresi = item.SirketAdresi,
                    SirketTelefonu = item.SirketTelefonu,
                    SirketEmail = item.SirketEmail,
                    SirketLogoURL = item.SirketLogoURL,
                    OdemePlani = item.OdemePlani,
                    Durum = item.Durum,
                    KayitTarihi = item.KayitTarihi,
                    UyelikBitisTarihi = item.UyelikBitisTarihi,
                    YorumId = item.YorumId
                };
                liste.SirketListele.Add(resp);
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

        public SirketResp SirketGetir(int id)
        {
            SirketResp resp = new SirketResp();
            if (id == 0)
            {
                resp.Mesaj = "Kullanıcı bulunamadı.";
                resp.BasariliMi = false;
                return resp;
            }
            try
            {
                Sirket sirket = _db.Sirketler.FirstOrDefault(x => x.SirketId == id);
                if (sirket == null)
                {
                    resp.Mesaj = "Kullanıcı bulunamadı.";
                    resp.BasariliMi = false;
                    return resp;
                }
                resp.SirketId = id;
                resp.SirketAdi = sirket.SirketAdi;
                resp.SirketAdresi = sirket.SirketAdresi;
                resp.SirketTelefonu = sirket.SirketTelefonu;
                resp.SirketEmail = sirket.SirketEmail;
                resp.Durum = sirket.Durum;
                resp.SirketLogoURL = sirket.SirketLogoURL;
                resp.BasariliMi = true;
                resp.Mesaj = "Başarılı";
                resp.KayitTarihi = sirket.KayitTarihi;
                resp.UyelikBitisTarihi = sirket.UyelikBitisTarihi;
                resp.OdemePlani = sirket.OdemePlani;
                resp.YorumId = sirket.YorumId;
                return resp;
            }
            catch (Exception ex)
            {
                resp.BasariliMi = false;
                resp.Mesaj = ex.Message;
                throw;
            }

            
        }

        public SiteYoneticisiResp SiteYoneticisiGetir(string guid)
        {
            SiteYoneticisiResp resp = new SiteYoneticisiResp();
            if (string.IsNullOrEmpty(guid))
            {
                resp.Mesaj = "Kullanıcı bulunamadı.";
                resp.BasariliMi = false;
                return resp;
            }
            try
            {
                SiteYoneticisi siteyoneticisi = _db.SiteYoneticileri.FirstOrDefault(x => x.Guid.ToString() == guid);
                if (siteyoneticisi == null)
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

        public SirketGuncelleResponse SirketGuncelleme(SirketGuncelle sy)
        {
            SirketGuncelleResponse resp = new SirketGuncelleResponse();
            try
            {

                Sirket sirketgun = _db.Sirketler.Find(sy.SirketId);
                if (sirketgun == null)
                {
                    resp.Mesaj = "Kullanıcı Bulunamadı";
                    resp.BasariliMi = false;
                    return resp;
                }
                if (sy.SirketAdi != null)
                    sirketgun.SirketAdi = sy.SirketAdi;
                if (sirketgun.SirketEmail != null)
                    sirketgun.SirketEmail = sy.SirketEmail;



                sirketgun.SirketLogoURL = sy.SirketLogoURL;
                sirketgun.SirketTelefonu = sy.SirketTelefonu;
                sirketgun.Durum = sy.Durum;
                sirketgun.OdemePlani = (Model.Entities.OdemePlani)sy.OdemePlani;
                sirketgun.KayitTarihi = sy.KayitTarihi.AddDays(1); // NEDEN ABİ NEDEN??? TODO: Hocaya sor...
                sirketgun.UyelikBitisTarihi = sy.UyelikBitisTarihi.AddDays(1); 
                _db.Update(sirketgun);
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

        public IzinTurleriListeleResponse IzinTurleriListele()
        {
            IzinTurleriListeleResponse liste = new IzinTurleriListeleResponse();
            liste.IzinTurleriListele = new List<IzinTurleriResponse>();
            foreach (var item in _db.IzinTurleri.ToList())
            {
                IzinTurleriResponse resp = new IzinTurleriResponse()
                {
                    IzinTurId = item.IzinTurId,
                    IzinTur = item.IzinTur
            };
                liste.IzinTurleriListele.Add(resp);
            }
            return liste;
        }

        public IzinTurleriEkleResponse IzinTurleriEkle(IzinTuruEkleReq ıt)
        {
            IzinTurleriEkleResponse resp = new IzinTurleriEkleResponse();

            try
            {
                IzinTuru izinturu = new IzinTuru()
                {
                    IzinTur = ıt.IzinTur
                };
                _db.Add(izinturu);
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

        public IzinTurleriGuncelleResponse IzinTurleriGuncelleme(IzinTuruGuncelle ıtgun)
        {
            IzinTurleriGuncelleResponse resp = new IzinTurleriGuncelleResponse();
            try
            {

                IzinTuru izinturgun = _db.IzinTurleri.Find(ıtgun.IzinTurId);
                if (izinturgun == null)
                {
                    resp.Mesaj = "Kullanıcı Bulunamadı";
                    resp.BasariliMi = false;
                    return resp;
                }
                if (ıtgun.IzinTur != null)
                    izinturgun.IzinTur = ıtgun.IzinTur;
                
                _db.Update(izinturgun);
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

        public IzinTurleriResponse IzinTuruGetir(int id)
        {
            IzinTurleriResponse resp = new IzinTurleriResponse();
            if (id == 0)
            {
                resp.Mesaj = "Kullanıcı bulunamadı.";
                resp.BasariliMi = false;
                return resp;
            }
            try
            {
                IzinTuru izinturu = _db.IzinTurleri.FirstOrDefault(x => x.IzinTurId == id);
                if (izinturu == null)
                {
                    resp.Mesaj = "İzin türü bulunamadı.";
                    resp.BasariliMi = false;
                    return resp;
                }
                else
                {
                    resp.IzinTurId = id;
                    resp.IzinTur = izinturu.IzinTur;
                    resp.BasariliMi = true;
                    resp.Mesaj = "İzin türü düzenlendi.";
                    return resp;
                }
            }
            catch (Exception ex)
            {
                resp.BasariliMi = false;
                resp.Mesaj = ex.Message;
                throw;
            }
        }

        public IzinTuruSilResponse IzinTuruSil(int id)
        {
            IzinTuruSilResponse resp = new IzinTuruSilResponse();
            try
            {
                IzinTuru izinturu = _db.IzinTurleri.Find(id);
                _db.Remove(izinturu);
                _db.SaveChanges();
                resp.Mesaj = "İzin türü silindi";
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

        public ZimmetTurleriListeleResponse ZimmetTurleriListele()
        {
            ZimmetTurleriListeleResponse liste = new ZimmetTurleriListeleResponse();
            liste.ZimmetTurleriListele = new List<ZimmetTurleriResponse>();
            foreach (var item in _db.ZimmetTurleri.ToList())
            {
                ZimmetTurleriResponse resp = new ZimmetTurleriResponse()
                {
                    ZimmetTurId = item.ZimmetTuruId,
                    ZimmetTur = item.ZimmetTur
                };
                liste.ZimmetTurleriListele.Add(resp);
            }
            return liste;
        }

        public ZimmetTurleriEkleResponse ZimmetTurleriEkle(ZimmetTuruEkleReq ıt)
        {
            ZimmetTurleriEkleResponse resp = new ZimmetTurleriEkleResponse();

            try
            {
                ZimmetTuru zimmeturu = new ZimmetTuru()
                {
                    ZimmetTur = ıt.ZimmetTur
                };
                _db.Add(zimmeturu);
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

        public ZimmetTurleriGuncelleResponse ZimmetTurleriGuncelleme(ZimmetTuruGuncelle ıtgun)
        {
            ZimmetTurleriGuncelleResponse resp = new ZimmetTurleriGuncelleResponse();
            try
            {

                ZimmetTuru zimmetturgun = _db.ZimmetTurleri.Find(ıtgun.ZimmetTurId);
                if (zimmetturgun == null)
                {
                    resp.Mesaj = "Kullanıcı Bulunamadı";
                    resp.BasariliMi = false;
                    return resp;
                }
                if (zimmetturgun.ZimmetTur != null)
                    zimmetturgun.ZimmetTur = ıtgun.ZimmetTur;

                _db.Update(zimmetturgun);
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

        public ZimmetTurleriResponse ZimmetTuruGetir(int id)
        {
            ZimmetTurleriResponse resp = new ZimmetTurleriResponse();
            if (id == 0)
            {
                resp.Mesaj = "Kullanıcı bulunamadı.";
                resp.BasariliMi = false;
                return resp;
            }
            try
            {
                ZimmetTuru zimmetturu = _db.ZimmetTurleri.FirstOrDefault(x => x.ZimmetTuruId == id);
                if (zimmetturu == null)
                {
                    resp.Mesaj = "İzin türü bulunamadı.";
                    resp.BasariliMi = false;
                    return resp;
                }
                else
                {
                    resp.ZimmetTurId = id;
                    resp.ZimmetTur = zimmetturu.ZimmetTur;
                    resp.BasariliMi = true;
                    resp.Mesaj = "İzin türü düzenlendi.";
                    return resp;
                }
            }
            catch (Exception ex)
            {
                resp.BasariliMi = false;
                resp.Mesaj = ex.Message;
                throw;
            }
        }

        public ZimmetTuruSilResponse ZimmetTuruSil(int id)
        {
            ZimmetTuruSilResponse resp = new ZimmetTuruSilResponse();
            try
            {
                ZimmetTuru zimmetturu = _db.ZimmetTurleri.Find(id);
                _db.Remove(zimmetturu);
                _db.SaveChanges();
                resp.Mesaj = "Zimmet türü silindi";
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

        public SirketSayisiResponse SirketSayisiGetir()
        {
            SirketSayisiResponse sirketSayisi = new SirketSayisiResponse();
            var resp = _db.Sirketler.Count();
            sirketSayisi.SirketSayisi = resp;
            return sirketSayisi;
        }

        public SirketYoneticisiSayisiResponse SirketYoneticisiSayisiGetir()
        {
            SirketYoneticisiSayisiResponse sirketyoneticisiSayisi = new SirketYoneticisiSayisiResponse();
            var resp = _db.SirketYoneticileri.Count();
            sirketyoneticisiSayisi.SirketYoneticisiSayisi = resp;
            return sirketyoneticisiSayisi;
        }

        public PersonelSayisiResponse PersonelSayisiGetir()
        {
            PersonelSayisiResponse personelSayisi = new PersonelSayisiResponse();
            var resp = _db.Personeller.Count();
            personelSayisi.PersonelSayisi = resp;
            return personelSayisi;
        }

        public AskiyaAlinacakSirketleriListeleResponse AskiyaAlinacakSirketleriListele()
        {
            AskiyaAlinacakSirketleriListeleResponse askiyaAlinacakSirketler = new AskiyaAlinacakSirketleriListeleResponse();
            var resp = _db.Sirketler.Where(x=>x.UyelikBitisTarihi.Date >= DateTime.Now.Date && x.UyelikBitisTarihi.Date<DateTime.Now.Date.AddDays(7) && x.Durum==Durum.Aktif).ToList();
            askiyaAlinacakSirketler.AskiyaAlinacakSirketleriListele = resp;
            return askiyaAlinacakSirketler;
        }

        public UyelikAskiyaAlmaResponse UyelikAskiyaAlma()
        {
            UyelikAskiyaAlmaResponse uyelikAskiyaAlinacaklar = new UyelikAskiyaAlmaResponse();
            var resp = _db.Sirketler.Where(x => x.UyelikBitisTarihi.Date < DateTime.Now.Date && x.Durum == Durum.Aktif).ToList();
            foreach (var item in resp)
            {
                item.Durum=Durum.Askıda;
                Tools.MailGonder(item.SirketEmail,"Üyelik bitiş tarihiniz geçmiştir.","Bu sebeple hesabınız askıya alınmıştır.Hizmete devam etmek için ödeme işlemini gerçekleştiriniz.");
            }
            uyelikAskiyaAlinacaklar.AskiyaAlinacakSirketler = resp;
            _db.SaveChanges();
            return uyelikAskiyaAlinacaklar;
        }
    }
}
