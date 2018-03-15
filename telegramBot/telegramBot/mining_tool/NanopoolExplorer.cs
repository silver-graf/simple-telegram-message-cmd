using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace telegramBot.mining_tool
{
    static class NanopoolExplorer
    {
        public static Task<NanopoolPrice> ETNNanopoolPrice(string addres)
        {
            return RestBack<NanopoolPrice>.RestLink("prices/" + addres);
        }

        

        //https://api.nanopool.org/v1/etn/workers/:address


        //https://api.nanopool.org/v1/etn/user/:address




        static class RestBack<T>
        {
            public static async Task<T> RestLink(string s)
            {
                T result = default(T);
                try
                {
                    var CLIENT = new RestClient("https://api.nanopool.org/v1/etn/" + s);

                    IRestResponse response = CLIENT.Execute(new RestRequest());
                    result = JObject.Parse(response.Content).ToObject<T>();
                }
                catch { }
                return result;
            }
        }
    }


}
