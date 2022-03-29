using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterAPI
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Location
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("zoneCount")]
        public int ZoneCount { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Weakness
    {
        [JsonProperty("element")]
        public string Element { get; set; }

        [JsonProperty("stars")]
        public int Stars { get; set; }

        [JsonProperty("condition")]
        public object Condition { get; set; }
    }

    public class Monster
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("species")]
        public string Species { get; set; }

        [JsonProperty("elements")]
        public List<object> Elements { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("ailments")]
        public List<Ailment> Ailments { get; set; }

        [JsonProperty("locations")]
        public List<Location> Locations { get; set; }

        [JsonProperty("resistances")]
        public List<object> Resistances { get; set; }

        [JsonProperty("weaknesses")]
        public List<Weakness> Weaknesses { get; set; }

        [JsonProperty("rewards")]
        public List<object> Rewards { get; set; }
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Item
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("rarity")]
        public int Rarity { get; set; }

        [JsonProperty("value")]
        public int Value { get; set; }

        [JsonProperty("carryLimit")]
        public int CarryLimit { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class Recovery
    {
        [JsonProperty("actions")]
        public List<string> Actions { get; set; }

        [JsonProperty("items")]
        public List<Item> Items { get; set; }
    }

    public class Skill
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class Protection
    {
        [JsonProperty("items")]
        public List<Item> Items { get; set; }

        [JsonProperty("skills")]
        public List<Skill> Skills { get; set; }
    }

    public class Ailment
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("recovery")]
        public Recovery Recovery { get; set; }

        [JsonProperty("protection")]
        public Protection Protection { get; set; }
    }



}
