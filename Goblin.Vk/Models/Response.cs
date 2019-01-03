﻿using Newtonsoft.Json;
using Goblin.Vk.Models.Responses;

namespace Goblin.Vk.Models
{
    public class Response
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("object")]
        public dynamic Object { get; set; }
        [JsonProperty("group_id")]
        public int GroupId { get; set; }
    }
}