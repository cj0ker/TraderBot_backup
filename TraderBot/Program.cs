using System;
using System.Security.Authentication;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocket4Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TraderBot
{
    class Program
    {
        #region Fields
        static WebSocket mSocketClient = null;
        static string subjson = @"
                {
                  ""type"": ""subscribe"",
                  ""channels"": [
                    {
                                ""name"": ""ticker"",
                      ""product_ids"": [
                        ""BTC-USD""
                      ]
                    }
                  ]
                }";

        #endregion

        #region Methods
        private static void InitNetWork()
        {
            mSocketClient = new WebSocket("wss://ws-feed-public.sandbox.pro.coinbase.com", sslProtocols: SslProtocols.Tls12 | SslProtocols.Tls11 | SslProtocols.Tls);
            mSocketClient.Opened += new EventHandler(websocket_Opened);
            mSocketClient.Error += new EventHandler<SuperSocket.ClientEngine.ErrorEventArgs>(websocket_Error);
            mSocketClient.Closed += new EventHandler(websocket_Closed);
            //mSocketClient.MessageReceived += new EventHandler<WebSocket4Net.MessageReceivedEventArgs>(websocket_MessageReceived);
            //mSocketClient.DataReceived += new EventHandler<DataReceivedEventArgs>(websocket_DataReceived);
            
            mSocketClient.MessageReceived += MSocketClient_MessageReceived;
            mSocketClient.DataReceived += MSocketClient_DataReceived;
            //ws.OnMessage += Ws_OnMessage;
            mSocketClient.Open();
        }

        #endregion


        static void Main(string[] args)
        {
            InitNetWork();

            Console.ReadKey();
        }


        private static void websocket_Opened(object sender, EventArgs e)
        {
            
            mSocketClient.Send(subjson);
        }

        private static void websocket_Error(object sender, SuperSocket.ClientEngine.ErrorEventArgs e)
        {
            Console.WriteLine("websocket_Error:" + e.Exception.ToString());
        }

        private static void websocket_Closed(object sender, EventArgs e)
        {
            Console.WriteLine("Connection closed");
        }

        private static void MSocketClient_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            Console.WriteLine("Message Recieved" + e.Message);
        }

        private static void MSocketClient_DataReceived(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine("DataRecieved" + e.Data);
        }




    }
}
