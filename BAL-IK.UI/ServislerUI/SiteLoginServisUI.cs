using BAL_IK.Data.Interfaceler.Site;
using BAL_IK.Model.RequestClass;
using BAL_IK.Model.ResponseClass;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BAL_IK.Model.ResponseClass.LogIslemleriResponse;
using static BAL_IK.Model.ResponseClass.SiteIslemleriResponse;

namespace BAL_IK.UI.ServislerUI
{
    public class SiteLoginServisUI : ISiteLoginServis
    {
        public KayitKullaniciResp KayitIslemi(LogIslemleriRequest.KayitKullaniciReq req)
        {
            var request = new RestRequest("api/Login/KayitIslemi", Method.POST, DataFormat.Json).AddJsonBody(req);

            var response = Globals.ApiClient.Execute<KayitKullaniciResp>(request);

            return response.Data;
        }

        public LogIslemleriResponse.LoginKullanici LoginIslemi(LogIslemleriRequest.LogKullanici log)
        {
            var request = new RestRequest("api/Login", Method.POST, DataFormat.Json).AddJsonBody(log);

            var response = Globals.ApiClient.Execute<LoginKullanici>(request);

            return response.Data;
        }

        public SiteIslemleriResponse.YorumlarResponse YorumlariGetir()
        {
            var request = new RestRequest("api/Site/YorumlariGetir", Method.GET, DataFormat.Json);

            var response = Globals.ApiClient.Execute<YorumlarResponse>(request);

            return response.Data;
        }
    }
}
