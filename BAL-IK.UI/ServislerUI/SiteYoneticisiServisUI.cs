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
    }
}
