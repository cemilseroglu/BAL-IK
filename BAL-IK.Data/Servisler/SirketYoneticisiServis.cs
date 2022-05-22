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

        public string HarcamaOnayla(int id, bool durum)
        {
            try
            {
                Harcamalar harcama = _db.Harcamalar.Find(id);
                if (harcama == null)
                    return "Bir Hata Oluştu";
                harcama.OnayDurumu=durum;
                _db.Update(harcama);
                MaasBilgisi maasBilgisi = _db.MaasBilgileri.FirstOrDefault(x => x.PersonelId == harcama.PersonelId && x.AlacagiTarih.Month == DateTime.Now.AddMonths(1).Month);
                if(maasBilgisi==null)
                {
                    return "Başarısız";
                }
                Personeller personel = _db.Personeller.Find(harcama.PersonelId);
                if(durum==true)
                {
                 maasBilgisi.MaasTutari += harcama.HarcamaTutari;
                    Tools.MailGonder(personel.Eposta,"Harcama Onayı",$"<p>Merhaba Sayın {personel.Ad}</p><p>{harcama.HarcamaIsmi} adlı {harcama.HarcamaTutari} TL Tutarlı harcamanız, {maasBilgisi.AlacagiTarih.ToShortDateString()} zamanında alacağınız maaşınıza eklenmiştir.<br/> O tarihte alacağınız maaş tutarı: {maasBilgisi.MaasTutari} TL</p><p>İyi Günler, İyi Çalışmalar.</p>");
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
    }
}
