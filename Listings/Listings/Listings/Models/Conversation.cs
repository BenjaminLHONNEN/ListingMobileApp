using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Listings.Models
{

    public class Conversation
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("sender")]
        public User Sender { get; set; }

        [JsonProperty("receiver")]
        public User Receiver { get; set; }

        [JsonProperty("article")]
        public Article Article { get; set; }
    }
}
