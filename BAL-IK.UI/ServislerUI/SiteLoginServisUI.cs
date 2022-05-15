using BAL_IK.Data.Interfaceler.Site;
using BAL_IK.Model.RequestClass;
using BAL_IK.Model.ResponseClass;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BAL_IK.Model.ResponseClass.LogIslemleriResponse;

namespace BAL_IK.UI.ServislerUI
{
    public class SiteLoginServisUI : ISiteLoginServis
    {
        public LogIslemleriResponse.LoginKullanici LoginIslemi(LogIslemleriRequest.LogKullanici log)
        {
            var request = new RestRequest("api/Login", Method.POST, DataFormat.Json).AddJsonBody(log);

            var response = Globals.ApiClient.Execute<LoginKullanici>(request);

            return response.Data;
        }
    }
}
