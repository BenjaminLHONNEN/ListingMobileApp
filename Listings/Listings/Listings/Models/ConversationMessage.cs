using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Listings.Models
{
    public class ConversationMessage
    {
        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("read")]
        public bool Read { get; set; }
    }
}
