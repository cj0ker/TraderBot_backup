using RestSharp;
using System;

namespace TraderBot
{
    public class Api
    {
        private static readonly string apiKey = APIKeys.APIKey;
        private static readonly string apiSecret = APIKeys.APISecret;
        private static readonly string apiPass = APIKeys.APIPassphrase;

        public string AccountInfo()
        {
            String timestamp = DateTime.Now.ToString();
            var client = new RestClient("https://api.exchange.coinbase.com/accounts");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("cb-access-key", apiKey);
            request.AddHeader("cb-access-passphrase", apiPass);
            request.AddHeader("cb-access-sign", apiPass);
            request.AddHeader("cb-access-timestamp", timestamp);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }
        //added to check sometime with git push

        public string Product()
        {
            string baseQuery = "https://api.exchange.coinbase.com/products/";
            var client = new RestClient(baseQuery);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Accept", "application/json");
            IRestResponse response = client.Execute(request);
            return response.Content;
        }

        public string History(string Market)
        {
            string baseQuery = $"https://api.exchange.coinbase.com/products/{Market}/candles";
            var client = new RestClient(baseQuery);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Accept", "application/json");

            return CallApi(client, request);
        }

        public string CallApi(RestClient client, RestRequest request)
        {
            IRestResponse response = client.Execute(request);
            return response.Content;
        }
    }
}

//public enum TimeSpan : int
//{
//    One_Min = 60,
//    Five_Min = 300,
//    Fifteen_Min = 900,
//    One_Hour = 3600,
//    Six_Hour = 21600,
//    One_Day = 86400,
//};