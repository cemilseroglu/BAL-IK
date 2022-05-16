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

        public SirketYoneticisiGuncel SirketYoneticisiGuncelle(SirketYoneticisiIslemleriRequest.SirketYoneticisiGuncelle sirketYoneticisi)
        {
            SirketYoneticisiGuncel resp = new SirketYoneticisiGuncel();

            try
            {
                SirketYoneticisi syoneticisi = _db.SirketYoneticileri.Find(sirketYoneticisi.SirketYoneticisiId);
                if (sirketYoneticisi.Ad != null)
                    syoneticisi.Ad = sirketYoneticisi.Ad;
                if (sirketYoneticisi.Soyad != null)
                    syoneticisi.Soyad = sirketYoneticisi.Soyad;
                if (sirketYoneticisi.Eposta != null)
                    syoneticisi.Eposta = sirketYoneticisi.Eposta;
                if (sirketYoneticisi.Sifre != null)
                    syoneticisi.Sifre = sirketYoneticisi.Sifre;
                syoneticisi.DogumTarihi = sirketYoneticisi.DogumTarihi;


                _db.Update(syoneticisi);
                _db.SaveChanges();
                resp.SirketYoneticisiId = syoneticisi.SirketYoneticisiId;
                resp.Ad = syoneticisi.Ad;
                resp.Soyad = syoneticisi.Soyad;
                resp.DogumTarihi = syoneticisi.DogumTarihi;
                resp.Eposta = syoneticisi.Eposta;
                resp.Sifre = syoneticisi.Sifre;
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
