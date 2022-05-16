using BAL_IK.Data.Context;
using BAL_IK.Data.Interfaceler.SirketYoneticisi;
using BAL_IK.Model.Entities;
using BAL_IK.Model.RequestClass;
using BAL_IK.Model.ResponseClass;
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
                SirketYoneticisi syoneticisi = _db.SirketYoneticileri.Find(sirketYoneticisi.SirketYoneticisiId);
                if (sirketYoneticisi.Ad != null)
                    syoneticisi.Ad = sirketYoneticisi.Ad;
                syoneticisi.Soyad = sirketYoneticisi.Soyad;
                syoneticisi.DogumTarihi = sirketYoneticisi.DogumTarihi;
                syoneticisi.Eposta = sirketYoneticisi.Eposta;
                syoneticisi.Sifre = sirketYoneticisi.Sifre;

                _db.Update(syoneticisi);
                _db.SaveChanges();
                resp.SirketYoneticisiId = syoneticisi.SirketYoneticisiId;
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
    }
}
