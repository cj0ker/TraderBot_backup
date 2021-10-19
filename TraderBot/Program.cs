using System;
using System.Security.Authentication;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocket4Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TraderBot //netflify.com
{
    class Program
    {
        static void Main(string[] args)
        {



            //var mJson = new mJson("subscribe", "BTC-USD").payload();
            //Console.WriteLine(mJson);

            //var mWebsocket = new mWebsocket(mJson);
            //mWebsocket.InitNetWork();
            //Console.WriteLine(candles);


            //InitNetWork(mJsonString);

            //var testing = new Api.Fetch(1);
            var test = new Api();
            var starttime = DateTime.Now.AddMinutes(-6);
            //test.History("BTC-USD", starttime);
            //test.tradingpairs();

            var hello = new SqliteDataAccess();
            hello.DbTableName("USD-BTC", 60);







            Console.ReadKey();
        }

        




    }
}
