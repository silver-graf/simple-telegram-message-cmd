using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace telegramBot
{
    static class KunaExplorer
    {     

        public static Task<Market> GetTicker (string s)
        {
            //btcuah
            return RestBack<Market>.RestLink("tickers/" + s);
        }
        
    }



    static class RestBack<T>
    {
        public static async Task<T> RestLink(string s)
        {
            T result = default(T);
            try
            {
                var CLIENT = new RestClient("https://kuna.io/api/v2/" + s);
          
                IRestResponse response = CLIENT.Execute(new RestRequest());
                result = JObject.Parse(response.Content).ToObject<T>();
            }           
            catch { }
            return result ;
        }
    }
}
