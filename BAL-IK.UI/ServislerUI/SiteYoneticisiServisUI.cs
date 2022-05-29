using BAL_IK.Data.Interfaceler;
using BAL_IK.Model.RequestClass;
using BAL_IK.Model.ResponseClass;
using RestSharp;
using static BAL_IK.Model.ResponseClass.SiteYoneticisiIslemleriResponse;

namespace BAL_IK.UI.ServislerUI
{
    public class SiteYoneticisiServisUI:ISiteYoneticisiService
    {
        public SirketResp SirketGetir(int id)
        {
            var request = new RestRequest("api/SiteYoneticisi/SirketGetir", Method.GET, DataFormat.Json).AddParameter("id", id);
            var response = Globals.ApiClient.Execute<SirketResp>(request);

            return response.Data;
        }

        public SirketGuncelleResponse SirketGuncelleme(SiteYoneticisiIslemleriRequest.SirketGuncelle s)
        {
            var request = new RestRequest("api/SiteYoneticisi/SirketGuncelleme", Method.POST, DataFormat.Json).AddJsonBody(s);
            var response = Globals.ApiClient.Execute<SirketGuncelleResponse>(request);
            return response.Data;
        }

        public SirketListeleResponse SirketleriListele()
        {
            
                var request = new RestRequest("api/SiteYoneticisi/SirketleriListele", Method.GET, DataFormat.Json);
                var response = Globals.ApiClient.Execute<SirketListeleResponse>(request);
                return response.Data;
            
        }

        public SiteYoneticileriniListeleResponse SiteYoneticileriniListele()
        {
            throw new System.NotImplementedException();
        }

        public SiteYoneticisiResp SiteYoneticisiGetir(string guid)
        {
            var request = new RestRequest("api/SiteYoneticisi/SiteYoneticisiGetir", Method.GET, DataFormat.Json).AddParameter("guid", guid);
            var response = Globals.ApiClient.Execute<SiteYoneticisiResp>(request);

            return response.Data;
        }

        public SiteYoneticisiGuncelleResponse SiteYoneticisiGuncelleme(SiteYoneticisiIslemleriRequest.SiteYoneticisiGuncelle sy)
        {
            var request = new RestRequest("api/SiteYoneticisi/SiteYoneticisiGuncelleme", Method.POST, DataFormat.Json).AddJsonBody(sy);
            var response = Globals.ApiClient.Execute<SiteYoneticisiGuncelleResponse>(request);
            return response.Data;
        }

        public SiteYoneticisiEkleResponse SiteYoneticisiKaydet(SiteYoneticisiIslemleriRequest.SiteYoneticisiEkle sy)
        {
            throw new System.NotImplementedException();
        }

        public IzinTurleriListeleResponse IzinTurleriListele()
        {

            var request = new RestRequest("api/SiteYoneticisi/IzinTurleriListele", Method.GET, DataFormat.Json);
            var response = Globals.ApiClient.Execute<IzinTurleriListeleResponse>(request);
            return response.Data;
        }

        public IzinTurleriEkleResponse IzinTurleriEkle(SiteYoneticisiIslemleriRequest.IzinTuruEkleReq ıt)
        {
            var request = new RestRequest("api/SiteYoneticisi/IzinTurleriEkle", Method.POST, DataFormat.Json).AddJsonBody(ıt);
            var response = Globals.ApiClient.Execute<IzinTurleriEkleResponse>(request);
            return response.Data;
        }

        public IzinTurleriGuncelleResponse IzinTurleriGuncelleme(SiteYoneticisiIslemleriRequest.IzinTuruGuncelle ıtgun)
        {
            var request = new RestRequest("api/SiteYoneticisi/IzinTurleriGuncelleme", Method.POST, DataFormat.Json).AddJsonBody(ıtgun);
            var response = Globals.ApiClient.Execute<IzinTurleriGuncelleResponse>(request);
            return response.Data;
        }

        public IzinTurleriResponse IzinTuruGetir(int id)
        {
            var request = new RestRequest("api/SiteYoneticisi/IzinTuruGetir", Method.GET, DataFormat.Json).AddParameter("id", id);
            var response = Globals.ApiClient.Execute<IzinTurleriResponse>(request);

            return response.Data;
        }

        public IzinTuruSilResponse IzinTuruSil(int id)
        {
            var request = new RestRequest("api/SiteYoneticisi/IzinTuruSil", Method.POST, DataFormat.Json).AddParameter("id", id);

            var response = Globals.ApiClient.Execute<IzinTuruSilResponse>(request);

            return response.Data;
        }

        public ZimmetTurleriListeleResponse ZimmetTurleriListele()
        {

            var request = new RestRequest("api/SiteYoneticisi/ZimmetTurleriListele", Method.GET, DataFormat.Json);
            var response = Globals.ApiClient.Execute<ZimmetTurleriListeleResponse>(request);
            return response.Data;
        }

        public ZimmetTurleriEkleResponse ZimmetTurleriEkle(SiteYoneticisiIslemleriRequest.ZimmetTuruEkleReq ıt)
        {
            var request = new RestRequest("api/SiteYoneticisi/ZimmetTurleriEkle", Method.POST, DataFormat.Json).AddJsonBody(ıt);
            var response = Globals.ApiClient.Execute<ZimmetTurleriEkleResponse>(request);
            return response.Data;
        }

        public ZimmetTurleriGuncelleResponse ZimmetTurleriGuncelleme(SiteYoneticisiIslemleriRequest.ZimmetTuruGuncelle ıtgun)
        {
            var request = new RestRequest("api/SiteYoneticisi/ZimmetTurleriGuncelleme", Method.POST, DataFormat.Json).AddJsonBody(ıtgun);
            var response = Globals.ApiClient.Execute<ZimmetTurleriGuncelleResponse>(request);
            return response.Data;
        }

        public ZimmetTurleriResponse ZimmetTuruGetir(int id)
        {
            var request = new RestRequest("api/SiteYoneticisi/ZimmetTuruGetir", Method.GET, DataFormat.Json).AddParameter("id", id);
            var response = Globals.ApiClient.Execute<ZimmetTurleriResponse>(request);

            return response.Data;
        }

        public ZimmetTuruSilResponse ZimmetTuruSil(int id)
        {
            var request = new RestRequest("api/SiteYoneticisi/ZimmetTuruSil", Method.POST, DataFormat.Json).AddParameter("id", id);

            var response = Globals.ApiClient.Execute<ZimmetTuruSilResponse>(request);

            return response.Data;
        }

        public SirketSayisiResponse SirketSayisiGetir()
        {
            var request = new RestRequest("api/SiteYoneticisi/SirketSayisiGetir", Method.GET, DataFormat.Json);
            var response = Globals.ApiClient.Execute<SirketSayisiResponse>(request);

            return response.Data;
        }

        public SirketYoneticisiSayisiResponse SirketYoneticisiSayisiGetir()
        {
            var request = new RestRequest("api/SiteYoneticisi/SirketYoneticisiSayisiGetir", Method.GET, DataFormat.Json);
            var response = Globals.ApiClient.Execute<SirketYoneticisiSayisiResponse>(request);

            return response.Data;
        }

        public PersonelSayisiResponse PersonelSayisiGetir()
        {
            var request = new RestRequest("api/SiteYoneticisi/PersonelSayisiGetir", Method.GET, DataFormat.Json);
            var response = Globals.ApiClient.Execute<PersonelSayisiResponse>(request);

            return response.Data;
        }

        public AskiyaAlinacakSirketleriListeleResponse AskiyaAlinacakSirketleriListele()
        {
            var request = new RestRequest("api/SiteYoneticisi/AskiyaAlinacakSirketleriListele", Method.GET, DataFormat.Json);
            var response = Globals.ApiClient.Execute<AskiyaAlinacakSirketleriListeleResponse>(request);
            return response.Data;
        }

        public UyelikAskiyaAlmaResponse UyelikAskiyaAlma()
        {
            var request = new RestRequest("api/SiteYoneticisi/UyelikAskiyaAlma", Method.GET, DataFormat.Json);
            var response = Globals.ApiClient.Execute<UyelikAskiyaAlmaResponse>(request);
            return response.Data;
        }
    }
}
