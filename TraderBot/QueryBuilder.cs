using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraderBot
{
    class QueryBuilder
    {




        private static readonly string baseURL = APIKeys.APISandbox;
        //private static readonly string baseURL = "https://api.exchange.coinbase.com/";
        string query = "";

        public QueryBuilder(string endpoint)
        {
            Generator(endpoint);
        }

        public QueryBuilder(string endpoint, string market)
        {

            string _query = baseURL;
            _query += endpoint;
            _query += "/";
            _query += market;
            _query += "candles";

        }




        private string Generator(string querystring)
        {
            string fullURL = baseURL;
            fullURL += querystring;
            return fullURL;
        }






    }
}
