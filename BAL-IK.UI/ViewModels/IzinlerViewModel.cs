using BAL_IK.Model.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using static BAL_IK.Model.ResponseClass.PersonelIslemleriResponse;

namespace BAL_IK.UI.ViewModels
{
    public class IzinlerViewModel
    {

        public GelenData resmiTatiller { get; set; }
        public int IzinId { get; set; }
        public int IzinTurId { get; set; }
        public IzinTurler IzinTur { get; set; } = new IzinTurler();
        public int IzinSuresi { get; set; }
        public string ReddilmeNedeni { get; set; }
        public DateTime IzinIstemeTarihi { get; set; }
        public DateTime? OnaylanmaTarihi { get; set; }
        public DateTime IzinBaslangicTarihi { get; set; }
        public DateTime IzinBitisTarihi { get; set; }
        public int PersonelId { get; set; }

        public int? SirketYoneticisiId { get; set; }

        public OnayDurumu OnayDurumu { get; set; }
        public List<IzinResponse> Izinler { get; set; }=new List<IzinResponse>();
        public class GelenData
        {
            public bool success { get; set; }
            public string status { get; set; }
            public string pagecreatedate { get; set; }
            public List<ResmiTatiller> ResmiTatiller { get; set; }
        }

        public class ResmiTatiller
        {
            public string gun { get; set; }
            public string en { get; set; }
            public string haftagunu { get; set; }
            public string tarih { get; set; }
            public string uzuntarih { get; set; }

        }
    }

   
}
