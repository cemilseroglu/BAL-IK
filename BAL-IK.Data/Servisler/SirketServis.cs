using BAL_IK.Data.Context;
using BAL_IK.Data.Interfaceler.Sirket;
using BAL_IK.Model.Entities;
using BAL_IK.Model.RequestClass;
using BAL_IK.Model.ResponseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BAL_IK.Model.ResponseClass.SirketIslemleriResponse;

namespace BAL_IK.Data.Servisler
{
    public class SirketServis : ISirketServis
    {
        private readonly BAL_IKContext _db;

        public SirketServis(BAL_IKContext db)
        {
            this._db = db;
        }
        public SirketIslemleriResponse.SirketEkleResponse SirketEkle(SirketIslemleriRequest.SirketEkleRequest sirketRequest)
        {
            SirketEkleResponse response = new SirketEkleResponse();
            try
            {
                Sirket yeniSirket = new Sirket();
                yeniSirket.SirketAdi = sirketRequest.SirketAdi;
                yeniSirket.SirketAdresi = sirketRequest.SirketAdresi;
                yeniSirket.SirketEmail = sirketRequest.SirketEmail;
                yeniSirket.SirketLogoURL = sirketRequest.SirketLogoURL;
                if (sirketRequest.OdemePlani == Model.RequestClass.OdemePlani.Yillik)
                {
                    yeniSirket.OdemePlani = Model.Entities.OdemePlani.Yillik;
                    yeniSirket.UyelikBitisTarihi = DateTime.Now.AddYears(1);
                }
                else
                {
                    yeniSirket.OdemePlani = Model.Entities.OdemePlani.Aylik;
                    yeniSirket.UyelikBitisTarihi = DateTime.Now.AddMonths(1);
                }
                if(_db.Sirketler.Any(x=>x.SirketEmail==sirketRequest.SirketEmail))
                {
                    response.Mesaj = "Hata.Bu şirket maili kullanılmaktadır.";
                    response.BasariliMi = false;
                    return response;
                }
                _db.Add(yeniSirket);
                _db.SaveChanges();
                response.SirketId = yeniSirket.SirketId;
                response.Mesaj = "Şirket Başarıyla Eklendi";
                response.BasariliMi = true;
                return response;
            }
            catch (Exception ex)
            {
                response.BasariliMi = false;
                response.Mesaj = ex.Message;
                return response;
            }
        }
    }
}
