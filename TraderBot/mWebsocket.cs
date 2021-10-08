//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Security.Authentication;
//using WebSocket4Net;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;

//namespace TraderBot
//{
//    class mWebsocket
//    {
//        #region Fields
//        static WebSocket mSocketClient = null;

//        static int counter = 0;
//        static readonly string subjson = @"
//                {
//                  ""type"": ""subscribe"",
//                  ""channels"": [
//                    {
//                                ""name"": ""ticker"",
//                      ""product_ids"": [
//                        ""BTC-USD""
//                      ]
//                    }
//                  ]
//                }";

//        #endregion Fields

//        #region Methods
//        private static void InitNetWork()
//        {

//            mSocketClient = new WebSocket("wss://ws-feed-public.sandbox.pro.coinbase.com", sslProtocols: SslProtocols.Tls12 | SslProtocols.Tls11 | SslProtocols.Tls);
//            mSocketClient.Opened += new EventHandler(MSocketClient_Opened);
//            mSocketClient.Error += new EventHandler<SuperSocket.ClientEngine.ErrorEventArgs>(MSocketClient_Error);
//            mSocketClient.Closed += new EventHandler(MSocketClient_Closed);
//            //mSocketClient.MessageReceived += new EventHandler<WebSocket4Net.MessageReceivedEventArgs>(websocket_MessageReceived);
//            //mSocketClient.DataReceived += new EventHandler<DataReceivedEventArgs>(websocket_DataReceived);

//            mSocketClient.MessageReceived += MSocketClient_MessageReceived;
//            mSocketClient.DataReceived += MSocketClient_DataReceived;
//            //ws.OnMessage += Ws_OnMessage;
//            mSocketClient.Open();
//        }

//        #endregion Methods


//        static void Main(string[] args)
//        {

//            InitNetWork();

//            Console.ReadKey();
//        }

//        static List<LiveData> candles = new List<LiveData>();

//        private static void MSocketClient_Opened(object sender, EventArgs e)
//        {

//            mSocketClient.Send(subjson);
//        }

//        private static void MSocketClient_Error(object sender, SuperSocket.ClientEngine.ErrorEventArgs e)
//        {
//            Console.WriteLine("websocket_Error:" + e.Exception.ToString());
//        }

//        private static void MSocketClient_Closed(object sender, EventArgs e)
//        {
//            Console.WriteLine("Connection closed");
//        }

//        private static void MSocketClient_MessageReceived(object sender, MessageReceivedEventArgs e)
//        {
//            //Console.WriteLine("Message Recieved" + e.Message);
//            if (counter != 0)
//                try
//                {
//                    LiveData rawCandles = JsonConvert.DeserializeObject<LiveData>(e.Message);
//                    Console.WriteLine(rawCandles.Price);
//                    candles.Add(rawCandles);
//                    //Console.WriteLine("Current count is: " + counter);
//                    //Console.WriteLine(candles);
//                    //foreach (LiveData aCandle in candles)
//                    //{
//                    //    Console.WriteLine(aCandle);
//                    //}


//                    //Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(e.Message);
//                    //Console.WriteLine(values.Count);
//                    //dict works but needs adding to a list now?
//                    //List<Product> products = JsonConvert.DeserializeObject<List<Product>>(json);











//                }

//                catch (Exception ex)
//                {
//                    Console.WriteLine(ex);
//                }
//            counter = counter + 1;
//        }

//        private static void MSocketClient_DataReceived(object sender, DataReceivedEventArgs e)
//        {
//            Console.WriteLine("DataRecieved" + e.Data);

//        }








//    }
//}



