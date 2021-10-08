using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace TraderBot
{
    public class Api
    {
        bool test = true;


        private static readonly string baseURL = APIKeys.APISandbox;
        //private static readonly string baseURL = "https://api.exchange.coinbase.com/";
        
        private static readonly string apiKey = APIKeys.APIKey;
        private static readonly string apiSecret = APIKeys.APISecret;
        private static readonly string apiPass = APIKeys.APIPassphrase;
        public string[] productIds; // does this need to be declared here?

        internal class Fetch
        {
            public void History(params string[] tradingPairs)
            {
                string[] productIds = tradingPairs;
                //callto generator method?
            }

            private string Generator(string querystring)
            {
                return string.Empty;
            }

            private string ApiCall(string URL)
            {
                return string.Empty;
            }

        }





        





        /*
         * endpoint generator
         * 
         * request method setting
         * 
         * default params eg apikeys
         * 
         *  how to call:
         *      api.fetch.accounts()
         *      api.fetch.prices
         *      api.fetch.coins
         *      api.send.order
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         */


        public void Account()
        {
            var client = new RestClient("https://api.exchange.coinbase.com/accounts");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("cb-access-key", "jhg");
            request.AddHeader("cb-access-passphrase", "kjh");
            request.AddHeader("cb-access-sign", "sdf");
            request.AddHeader("cb-access-timestamp", "sdf");
            IRestResponse response = client.Execute(request);
        }





}
}
