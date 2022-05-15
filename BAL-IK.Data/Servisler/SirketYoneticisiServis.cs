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
                SirketYoneticisi syoneticisi = new SirketYoneticisi()
                {
                    SirketYoneticisiId = sirketYoneticisi.SirketYoneticisiId,
                    Ad = sirketYoneticisi.Ad,
                    Soyad = sirketYoneticisi.Soyad,
                    DogumTarihi = sirketYoneticisi.DogumTarihi,
                    Eposta = sirketYoneticisi.Eposta,
                    Sifre = sirketYoneticisi.Sifre
                };
                _db.Update(sirketYoneticisi);
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
    }
}
