using Coinbase.Pro;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TraderBot
{
    public class Api
    // class might be reworked in future to not rely on Coinbase.pro lib
    // so all data exiting must be raw(not using coinbase models)
    {
        private const string BaseUrl = "https://api-public.sandbox.exchange.coinbase.com"; //Sandbox URL
        //const string BaseUrl = "https://api.exchange.coinbase.com"; //Live URL

        private readonly CoinbaseProClient _client;

        private string _apikey = APIKeys.APIKey;
        private string _secret = APIKeys.APISecret;
        private string _passphrase = APIKeys.APISecret;

        public Api()
        {
            _client = new CoinbaseProClient(new Config
            {
                ApiKey = _apikey,
                Secret = _secret,
                Passphrase = _passphrase,
                ApiUrl = "https://api-public.sandbox.pro.coinbase.com"
            });
        }

        private async Task<List<Coinbase.Pro.Models.Candle>> History_fetch(string market, DateTime start, DateTime end, int granularity)
        {
            var getHistory = await _client.MarketData.GetHistoricRatesAsync(market, start, end, granularity);
            //var results = getHistory;

            return getHistory;
        }

        public async void History(string market, DateTime start, int granularity = 60)
        {
            var end = DateTime.Now;

            var results = await History_fetch(market, start, end, granularity);

            List<HistoricalData> myData = new List<HistoricalData>();
            foreach (Coinbase.Pro.Models.Candle candle in results)

            {
                HistoricalData _newdata = new HistoricalData
                {
                    Timestamp = candle.Time,
                    PriceLow = (decimal)candle.Low,
                    PriceHigh = (decimal)candle.High,
                    PriceOpen = (decimal)candle.Open,
                    PriceClose = (decimal)candle.Close
                };

                myData.Insert(0, _newdata); //adds to start of list, could be wrong way round??
                                            // does this matter with timestamps?
            }
        }

        public async void History(string market, DateTime start, DateTime end, int granularity = 60)
        {
            var results = await History_fetch(market, start, end, granularity);

            List<string> myData = new List<string>();
            foreach (Coinbase.Pro.Models.Candle candle in results)

            {
                Console.WriteLine(candle.Time);
                Console.WriteLine(candle.Low);
                Console.WriteLine(candle.High);
                Console.WriteLine(candle.Open);
                Console.WriteLine(candle.Close);
                Console.WriteLine(candle.Volume);
            }
        }
    }
}

//override for later
//public void history(string market, DateTime start, DateTime end, int granularity = 60)
//{
//    var getHistory = _client.MarketData.GetHistoricRatesAsync(market, start, end, granularity);

//    Console.WriteLine(getHistory);

//}