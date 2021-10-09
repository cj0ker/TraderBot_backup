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

        public QueryBuilder (string querystring)
        {
            
            Generator(querystring);
        }

        private string Generator(string querystring)
        {
            string fullURL = baseURL;
            fullURL += querystring;
            return fullURL;
        }






    }
}
