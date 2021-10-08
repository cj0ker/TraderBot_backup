using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TraderBot
{
    public class mJson
    {
        public string sentType;
        public string[] sentMarkets;


        //public mJson() { }

        public mJson(string type, params string[] markets)

        {
            sentType = type;
            sentMarkets = markets;
        }


        public string payload()
        {

            JObject json =
                new JObject(
                    new JProperty("type", sentType),
                    new JProperty("channels",
                    new JArray(
                        new JObject("name", "ticker"),
                        new JProperty("product_ids",
                        new JArray(
                            from s in sentMarkets
                            select new JValue(s))))));

            //new JProperty("Product_ids", sentMarkets))));

            //from c in sentMarkets
            //select new JValue(c)))))))));

            Console.WriteLine(json.ToString());
            return json.ToString();
        }
        

        

    }































    //interface IPayload
    //{

    //    void goodnamehere(string type, params string[] markets);
    //    string returngoodnamehere();
    //    //string SendType { get; set; }

    //    //string Name { get; set; }

    //    //string[] ProductIds { get; set; }

    //    //string jsonReturn();
    //}

    //public class Creation : IPayload
    //{
    //    protected string senttype;
    //    protected string[] sentmarkets;


    //    public void goodnamehere(string type, params string[] markets)
    //    {
    //        senttype = type;
    //        sentmarkets = markets;
    //    }


    //    public string returngoodnamehere()
    //    {


    //        JObject json =
    //            new JObject(
    //                new JProperty("type", senttype),
    //                new JProperty("channels",
    //                    new JArray(
    //                        new JProperty("name", "ticker"),

    //                            new JProperty("Product_ids", sentmarkets))));

    //        Console.WriteLine(json.ToString());
    //        return "done";
    //    }
    //}




            // {
            //   "channel": {
            //     "title": "James Newton-King",
            //     "link": "http://james.newtonking.com",
            //     "description": "James Newton-King's blog.",
            //     "item": [
            //       {
            //         "title": "Json.NET 1.3 + New license + Now on CodePlex",
            //         "description": "Announcing the release of Json.NET 1.3, the MIT license and being available on CodePlex",
            //         "link": "http://james.newtonking.com/projects/json-net.aspx",
            //         "category": [
            //           "Json.NET",
            //           "CodePlex"
            //         ]
            //       },
            //       {
            //         "title": "LINQ to JSON beta",
            //         "description": "Announcing LINQ to JSON",
            //         "link": "http://james.newtonking.com/projects/json-net.aspx",
            //         "category": [
            //           "Json.NET",
            //           "LINQ"
            //         ]
            //       }
            //     ]
            //   }
            // }



















}