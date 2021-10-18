using System;

namespace TraderBot
{
    internal class HistoricalData
    {
        public DateTimeOffset Timestamp { get; set; } //need conversion?????

        public decimal PriceLow { get; set; }

        public decimal PriceHigh { get; set; }

        public decimal PriceOpen { get; set; }

        public decimal PriceClose { get; set; }
    }
}