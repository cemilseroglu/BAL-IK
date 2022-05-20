using BAL_IK.Data.Interfaceler.SirketYoneticisi;
using BAL_IK.Model.RequestClass;
using BAL_IK.Model.ResponseClass;
using RestSharp;
using static BAL_IK.Model.ResponseClass.SirketYoneticisiIslemleriResponse;

namespace BAL_IK.UI.ServislerUI
{
    public class SirketYoneticisiServisUI : ISirketYoneticisiServis
    {
        public HarcamalarResponse HarcamalariGetir(string guid)
        {
            var request = new RestRequest("/api/SirketYoneticisi/HarcamalariGetir", Method.GET, DataFormat.Json).AddParameter("guid", guid);

            var response = Globals.ApiClient.Execute<HarcamalarResponse>(request);

            return response.Data;
        }

        public SirketYoneticisiIslemleriResponse.SirketYoneticisiResponse SirketYoneticisiGetir(string guid)
        {
            var request = new RestRequest("api/SirketYoneticisi/SirketYoneticisiGetir", Method.GET, DataFormat.Json).AddParameter("guid",guid);

            var response = Globals.ApiClient.Execute<SirketYoneticisiResponse>(request);

            return response.Data;
        }

        public SirketYoneticisiIslemleriResponse.SirketYoneticisiGuncel SirketYoneticisiGuncelle(SirketYoneticisiIslemleriRequest.SirketYoneticisiGuncelle sy)
        {
            var request = new RestRequest("api/SirketYoneticisi/SirketYoneticisiGuncelle", Method.POST, DataFormat.Json).AddJsonBody(sy);

            var response = Globals.ApiClient.Execute<SirketYoneticisiGuncel>(request);

            return response.Data;
        }
    }
}
