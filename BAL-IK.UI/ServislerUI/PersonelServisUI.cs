using BAL_IK.Data.Interfaceler.Personeller;
using BAL_IK.Model.RequestClass;
using BAL_IK.Model.ResponseClass;
using RestSharp;
using static BAL_IK.Model.ResponseClass.PersonelIslemleriResponse;

namespace BAL_IK.UI.ServislerUI
{
    public class PersonelServisUI : IPersonellerServis
    {
        public PersonelHarcamaEkle HarcamaEkleme(PersonelIslemleriRequest.HarcamaEkle pr)
        {
            var request = new RestRequest("api/Personel/HarcamaEkleme", Method.POST, DataFormat.Json).AddJsonBody(pr);
            var response = Globals.ApiClient.Execute<PersonelHarcamaEkle>(request);
            return response.Data;
        }

        public HarcamaListelemeResponse HarcamalarıGetir()
        {
            var request = new RestRequest("api/Personel/HarcamalarıGetir", Method.GET, DataFormat.Json);
            var response= Globals.ApiClient.Execute<HarcamaListelemeResponse>(request);
            return response.Data;
        }

        public PersonelIslemleriResponse.PersonelEkleResponse PersonelEkleme(PersonelIslemleriRequest.PersonelEkle pr)
        {
            var request = new RestRequest("api/Personel/PersonelEkleme",Method.POST,DataFormat.Json).AddJsonBody(pr);
            var response = Globals.ApiClient.Execute<PersonelEkleResponse>(request);
            return response.Data;
        }

        public PersonelIslemleriResponse.PersonelResp PersonelGetir(string guid)
        {
            var request = new RestRequest("api/Personel/PersonelGetir", Method.GET, DataFormat.Json).AddParameter("guid",guid);
            var response = Globals.ApiClient.Execute<PersonelResp>(request);

                return response.Data;
        }

        public PersonelIslemleriResponse.PersonelGuncelleResponse PersonelGuncelleme(PersonelIslemleriRequest.PersonelGuncelle pr)
        {
            var request = new RestRequest("api/Personel/PersonelGuncelleme", Method.POST, DataFormat.Json).AddJsonBody(pr);
            var response = Globals.ApiClient.Execute<PersonelGuncelleResponse>(request);
            return response.Data;
        }

        public PersonelIslemleriResponse.PersonelListelemeResponse PersonelListeleme()
        {
            throw new System.NotImplementedException();
        }
    }
}
