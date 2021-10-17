using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraderBot
{
    class HistoricalData
    {



        [JsonProperty("timestamp")]
        public string Timestamp;

        [JsonProperty("price_low")]
        public int PriceLow;

        [JsonProperty("price_high")]
        public string PriceHigh;

        [JsonProperty("price_open")]
        public float PriceOpen;

        [JsonProperty("price_close")]
        public float PriceClose;






    }
}
