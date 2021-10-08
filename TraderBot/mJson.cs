using Newtonsoft.Json.Linq;
using System.Linq;

namespace TraderBot
{
    public class mJson
    {
        public string sentType;
        public string[] sentMarkets;

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
                        new JObject(
                            new JProperty("name", "ticker"),
                            new JProperty("product_ids",
                            new JArray(
                                from s in sentMarkets
                                select new JValue(s)))))));

            return json.ToString();
        }
    }
}