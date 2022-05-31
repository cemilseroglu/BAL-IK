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
        public List<IzinTurler> IzinTurleri { get; set; }
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
        public List<VardiyaResponse> Vardiya { get; set; }= new List<VardiyaResponse> ();
        public List<MolaResponse> Molalar { get; set; } = new List<MolaResponse>();
        public List<VardiyaResponse> Vardiyalar { get; set; } = new List<VardiyaResponse>();
    }
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
        public class EkleizinResponse 
        {
            public int IzinTurId { get; set; }
            public string IzinTur { get; set; }
            public int IzinSuresi { get; set; }
            public string ReddilmeNedeni { get; set; }
            public DateTime IzinIstemeTarihi { get; set; }
            public DateTime OnaylanmaTarihi { get; set; }
            public DateTime IzinBaslangicTarihi { get; set; }
            public DateTime IzinBitisTarihi { get; set; }
            public int PersonelId { get; set; }
            public int SirketYoneticisiId { get; set; }
            public OnayDurumu OnayDurumu { get; set; }
        }
        //public class VardiyaResponse 
        //{
        //    public int VardiyaId { get; set; }
        //    public DateTime VardiyaBaslangicTarihi { get; set; }
        //    public DateTime VardiyaBitisTarihi { get; set; }  //10 gün gece 10 gün gündüz vardiyası şeklinde gibi...
        //    public int VardiyaTurId { get; set; }
        //    public int PersonelId { get; set; }
        //    public VardiyaTur VardiyaTuru { get; set; } = new VardiyaTur();


        //}
        public class VardiyaTur 
        {
            public int VardiyaTurId { get; set; }
            public string VardiyaTuru { get; set; }
            public DateTime VardiyaBaslangicTarihi { get; set; }
            public DateTime VardiyaBitisTarihi { get; set; }
        }
        public class VardiyalarResponse 
        {
            public List<VardiyaResponse> Vardiyalar { get; set; } = new List<VardiyaResponse>();
        }
        //public class MolaResponse 
        //{
        //    public int MolaId { get; set; }
        //    public int MolaTurId { get; set; }
        //    public DateTime OlusturulduguTarih { get; set; } = DateTime.Now;
        //    public MolaTur MolaTuru { get; set; } = new MolaTur();
        //    public int PersonelId { get; set; }
        //}
        public class MolaTur 
        {
            public int MolaTurId { get; set; }
            public string MolaTuru { get; set; }
            public double MolaSuresi { get; set; }
            public int SirketId { get; set; }
        }
        public class MolalarResponse 
        {
            public List<MolaResponse> Molalar { get; set; } = new List<MolaResponse>();
        }
    

   
}
