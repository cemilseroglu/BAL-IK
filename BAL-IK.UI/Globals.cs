using RestSharp;

namespace BAL_IK.UI
{  
    
        public static class Globals
        {
            public static RestClient ApiClient { get; private set; } = new RestClient("http://localhost:46375/");
        }
   
}
