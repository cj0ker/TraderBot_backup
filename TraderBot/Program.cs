using Newtonsoft.Json;
using System;
using WebSocketSharp;

namespace TraderBot
{
    // JSON Creation Class - start
    public class Channels
    {
        public string name;
        public string[] product_ids;
    };

    public class Payload
    {
        public string type;
        public string testcase;
        public Channels channels;
    };

    // JSON Creation Class - end

    internal class Program
    {
        private static void Main(string[] args)
        {
            //creating the basic subscibe JSON payload
            var subscribePayload = new Payload()
            {
                type = "subscribe",
                channels = new Channels
                {
                    name = "ticker",
                    product_ids = new string[] { "BTC-USD" }
                }
            };

            // serializing the json object
            //string subscribe_message = JsonConvert.SerializeObject(subscribePayload,
            //    Formatting.Indented,
            //    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            string subscribe_message = JsonConvert.SerializeObject(subscribePayload,
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            //Console.WriteLine(subscribe_message);
            //Console.ReadLine();
            string CoinbaseWSS = "wss://ws-feed-public.sandbox.pro.coinbase.com";
            //Create an instance of a websocket client
            using (var ws = new WebSocket(CoinbaseWSS))
            {

                ws.Connect();








            }

            Console.ReadKey();
        }




        private static void Ws_OnMessage(object sender, MessageEventArgs e)
        {
            Console.WriteLine("Recieved from the serrver: " + e.Data);
        }
    }
}
