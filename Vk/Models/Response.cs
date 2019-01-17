﻿using Newtonsoft.Json;

namespace Vk.Models
{
    public class Response
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("object")]
        public object Object { get; set; }
        [JsonProperty("group_id")]
        public int GroupId { get; set; }
    }
}