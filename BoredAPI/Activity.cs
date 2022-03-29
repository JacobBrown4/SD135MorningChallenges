using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoredAPI
{
    public class Event
    {
        [JsonProperty("activity")]
        public string Activity { get; set; }

        [JsonProperty("accessibility")]
        public double Accessibility { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("participants")]
        public int Participants { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }
    }


}

