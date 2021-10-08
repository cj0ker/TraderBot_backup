using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security.Authentication;
using WebSocket4Net;

//TODO: look into recieveing heartbeat messages (1 message persecond)
//TODO: check for async
//TODO: output data to main class

namespace TraderBot
{
    internal class mWebsocket
    {
        public string mPayload;

        public mWebsocket(string mPayload)
        {
            this.mPayload = mPayload;
        }

        private WebSocket mSocketClient = null;
        private int counter = 0;

        public void InitNetWork()
        {
            mSocketClient = new WebSocket("wss://ws-feed-public.sandbox.pro.coinbase.com", sslProtocols: SslProtocols.Tls12 | SslProtocols.Tls11 | SslProtocols.Tls);
            mSocketClient.Opened += new EventHandler(MSocketClient_Opened);
            mSocketClient.Error += new EventHandler<SuperSocket.ClientEngine.ErrorEventArgs>(MSocketClient_Error);
            mSocketClient.Closed += new EventHandler(MSocketClient_Closed);
            //mSocketClient.MessageReceived += new EventHandler<WebSocket4Net.MessageReceivedEventArgs>(websocket_MessageReceived);
            //mSocketClient.DataReceived += new EventHandler<DataReceivedEventArgs>(websocket_DataReceived);

            mSocketClient.MessageReceived += MSocketClient_MessageReceived;
            mSocketClient.DataReceived += MSocketClient_DataReceived;
            mSocketClient.Open();
        }

        private void MSocketClient_Opened(object sender, EventArgs e)
        {
            mSocketClient.Send(mPayload);
        }

        private void MSocketClient_Error(object sender, SuperSocket.ClientEngine.ErrorEventArgs e)
        {
            Console.WriteLine("websocket_Error:" + e.Exception.ToString());
        }

        private void MSocketClient_Closed(object sender, EventArgs e)
        {
            Console.WriteLine("Connection closed");
        }

        public void MSocketClient_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            List<LiveData> candles = new List<LiveData>();
            //Console.WriteLine("Message Recieved" + e.Message);
            if (counter != 0)
                try
                {
                    Console.WriteLine(e.Message);
                    LiveData rawCandles = JsonConvert.DeserializeObject<LiveData>(e.Message);
                    Console.WriteLine(rawCandles.Price);
                    candles.Add(rawCandles);
                    //Console.WriteLine("Current count is: " + counter);
                    //Console.WriteLine(candles);
                    //foreach (LiveData aCandle in candles)
                    //{
                    //    Console.WriteLine(aCandle);
                    //}

                    //Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(e.Message);
                    //Console.WriteLine(values.Count);
                    //dict works but needs adding to a list now?
                    //List<Product> products = JsonConvert.DeserializeObject<List<Product>>(json);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            counter = counter + 1;
        }

        private void MSocketClient_DataReceived(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine("DataRecieved" + e.Data);
        }
    }
}