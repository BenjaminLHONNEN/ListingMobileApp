using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Listings.Models
{
    public class UserConnection
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password);
        }
    }
    public class UserToken
    {
        [JsonProperty("token")] public string Token { get; set; }

        [JsonProperty("exp")] public DateTime Exp { get; set; }

        [JsonProperty("username")] public string Username { get; set; }
    }
}