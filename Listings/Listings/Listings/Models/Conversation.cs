using System;
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

    public class User
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("firstname")]
        public string Firstname { get; set; }

        [JsonProperty("lastname")]
        public string Lastname { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("is_admin")]
        public bool IsAdmin { get; set; }

        [JsonProperty("is_guest")]
        public bool IsGuest { get; set; }
    }
}
