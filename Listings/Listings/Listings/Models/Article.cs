using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Listings.Models
{
    public class Article
    {
        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("price")]
        public decimal Price{ get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("picture")]
        public string Picture { get; set; }

        [JsonProperty("category")]
        public Category Category { get; set; }

        [JsonProperty("user_id")]
        public long UserId { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("category_id")] public int CategoryId => Category.Id;
    }
}
