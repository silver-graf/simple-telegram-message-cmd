using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace telegramBot
{
    class Market
    {
        internal static DateTime ParseDateTime(string dateTime)
        {
            return DateTime.SpecifyKind(DateTime.ParseExact(dateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture), DateTimeKind.Utc).ToLocalTime();
        }
        //[DeserializeAs(Name = "at") ]
        public string at { get; set; }

        public Ticker ticker { get; set; }        

    }
    public class Ticker
    {

        //[DeserializeAs(Name = "buy")]
        public string buy { get; set; }
        //[DeserializeAs(Name = "sell")]
        public string sell { get; set; }
        //[DeserializeAs(Name = "low")]
        public string low { get; set; }
        //[DeserializeAs(Name = "high")]
        public string high { get; set; }
        //[DeserializeAs(Name = "last")]
        public string last { get; set; }
        //[DeserializeAs(Name = "vol")]
        public string vol { get; set; }
        //[DeserializeAs(Name = "amount")]
        public string amount { get; set; }

    }

}
