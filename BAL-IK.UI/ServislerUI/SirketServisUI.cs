using BAL_IK.Data.Interfaceler.Sirket;
using BAL_IK.Model.RequestClass;
using BAL_IK.Model.ResponseClass;
using RestSharp;
using static BAL_IK.Model.ResponseClass.SirketIslemleriResponse;

namespace BAL_IK.UI.ServislerUI
{
    public class SirketServisUI : ISirketServis
    {
        public SirketIslemleriResponse.SirketEkleResponse SirketEkle(SirketIslemleriRequest.SirketEkleRequest sirketRequest)
        {
            var request = new RestRequest("api/Sirket/SirketEkle", Method.POST, DataFormat.Json).AddJsonBody(sirketRequest);

            var response = Globals.ApiClient.Execute<SirketEkleResponse>(request);

            return response.Data;
        }
    }
}
