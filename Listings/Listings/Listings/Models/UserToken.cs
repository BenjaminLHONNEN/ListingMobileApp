using System;
using Newtonsoft.Json;

namespace Listings.Models
{
    public class UserToken
    {
        [JsonProperty("token")] public string Token { get; set; }

        [JsonProperty("exp")] public DateTime Exp { get; set; }

        [JsonProperty("username")] public string Username { get; set; }
    }
}