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
            var testing = new Api();
            string history = testing.History("BTC-USD");
            Console.WriteLine(history);


           Console.ReadKey();
        }

        




    }
}
