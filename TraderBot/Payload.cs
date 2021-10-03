using Newtonsoft.Json;

namespace TraderBot
{
    public class Payload
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("channels")]
        public string[] Channels { get; set; }
    }

    public class Channel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("product_ids")]
        public string[] ProductIds { get; set; }
    }
}