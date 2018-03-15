using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace telegramBot.mining_tool
{
    class NanopoolPrice
    {

        public bool Status { get; set; }
        public DataPriceNanopool data {get;set;}
      
    }

    internal class DataPriceNanopool
    {
        public decimal price_usd { get; set; }
        public decimal price_eur { get; set; }
        public decimal price_rur { get; set; }
        public decimal price_CNY { get; set; }
        public decimal price_btc { get; set; }


    }
}
