using BAL_IK.Data.Interfaceler.SirketYoneticisi;
using BAL_IK.Model.RequestClass;
using BAL_IK.Model.ResponseClass;
using RestSharp;
using static BAL_IK.Model.ResponseClass.PersonelIslemleriResponse;
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

        public PersonelIslemleriResponse.IzinEkleResponse IzinEkle(PersonelIslemleriRequest.IzinEkle izinEkle)
        {
            var request = new RestRequest("api/SirketYoneticisi/IzinEkle", Method.POST, DataFormat.Json).AddJsonBody(izinEkle);

            var response = Globals.ApiClient.Execute<IzinEkleResponse>(request);

            return response.Data;
        }

        public PersonelIslemleriResponse.IzinListelemeResponse IzinListele()
        {
            var request = new RestRequest("api/SirketYoneticisi/IzinListele", Method.POST, DataFormat.Json);

            var response = Globals.ApiClient.Execute<IzinListelemeResponse>(request);

            return response.Data;
        }

        public PersonelIslemleriResponse.OzlukBelgesiEkleResponse OzlukBelgesiEkle(PersonelIslemleriRequest.OzlukBelgesiEkle ozlukBelgesi)
        {
            var request = new RestRequest("api/SirketYoneticisi/OzlukBelgesiEkle", Method.POST, DataFormat.Json).AddJsonBody(ozlukBelgesi);

            var response = Globals.ApiClient.Execute<OzlukBelgesiEkleResponse>(request);

            return response.Data;
        }

        public OzlukBelgesiGuncelleResponse OzlukBelgesiGuncelle(PersonelIslemleriRequest.OzlukBelgesiGuncelle ozlukBelgesiGuncelle)
        {
            var request = new RestRequest("api/SirketYoneticisi/OzlukBelgesiGuncelle", Method.POST, DataFormat.Json).AddJsonBody(ozlukBelgesiGuncelle);

            var response = Globals.ApiClient.Execute<OzlukBelgesiGuncelleResponse>(request);

            return response.Data;
        }

        public PersonelEkleResponse PersonelEklemeIslemi(PersonelIslemleriRequest.PersonelEkle personel)
        {
            var request = new RestRequest("api/SirketYoneticisi/PersonelEklemeIslemi", Method.POST, DataFormat.Json).AddJsonBody(personel);

            var response = Globals.ApiClient.Execute<PersonelEkleResponse>(request);

            return response.Data;
        }

        public PersonelGuncelleResponse PersonelGuncelleme(PersonelIslemleriRequest.PersonelGuncelle pr)
        {
            var request = new RestRequest("api/SirketYoneticisi/PersonelGuncelleme", Method.POST, DataFormat.Json).AddJsonBody(pr);

            var response = Globals.ApiClient.Execute<PersonelGuncelleResponse>(request);

            return response.Data;
        }   

        public PersonelSilResponse PersonelSil(int personelId)
        {
            var request = new RestRequest("api/SirketYoneticisi/PersonelSil", Method.GET, DataFormat.Json).AddParameter("personelId", personelId);

            var response = Globals.ApiClient.Execute<PersonelSilResponse>(request);

            return response.Data;
        }

        public SirketYoneticisiResponse SirketYoneticisiGetir(string guid)
        {
            var request = new RestRequest("api/SirketYoneticisi/SirketYoneticisiGetir", Method.GET, DataFormat.Json).AddParameter("guid", guid);

            var response = Globals.ApiClient.Execute<SirketYoneticisiResponse>(request);

            return response.Data;
        }

        public SirketYoneticisiGuncel SirketYoneticisiGuncelle(SirketYoneticisiIslemleriRequest.SirketYoneticisiGuncelle sy)
        {
            var request = new RestRequest("api/SirketYoneticisi/SirketYoneticisiGuncelle", Method.POST, DataFormat.Json).AddJsonBody(sy);

            var response = Globals.ApiClient.Execute<SirketYoneticisiGuncel>(request);

            return response.Data;
        }

        public SirketYoneticisiEklemeResponse SirketYoneticisiOlustur(SirketYoneticisiIslemleriRequest.SirketYoneticisiEkle sy)
        {
            var request = new RestRequest("api/SirketYoneticisi/SirketYoneticisiOlustur", Method.POST, DataFormat.Json).AddJsonBody(sy);

            var response = Globals.ApiClient.Execute<SirketYoneticisiEklemeResponse>(request);

            return response.Data;
        }
    }

}
