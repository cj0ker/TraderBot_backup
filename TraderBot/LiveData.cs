using Newtonsoft.Json;
using System;

namespace TraderBot
{
    internal class LiveData
    {
        [JsonProperty("type")]
        public string Type;

        [JsonProperty("sequence")]
        public int Sequence;

        [JsonProperty("product_id")]
        public string ProductId;

        [JsonProperty("price")]
        public float Price;

        [JsonProperty("open_24h")]
        public float Open24h;

        [JsonProperty("volume_24h")]
        public float Volume24h;

        [JsonProperty("low_24h")]
        public float Low24h;

        [JsonProperty("high_24h")]
        public float High24h;

        [JsonProperty("volume_30d")]
        public float Volume30d;

        [JsonProperty("best_bid")]
        public float BestBid;

        [JsonProperty("best_ask")]
        public float BestAsk;

        [JsonProperty("side")]
        public string Side;

        [JsonProperty("time")]
        public DateTime Time;

        [JsonProperty("trade_id")]
        public int TradeId;

        [JsonProperty("last_size")]
        public float LastSize;
    }
}