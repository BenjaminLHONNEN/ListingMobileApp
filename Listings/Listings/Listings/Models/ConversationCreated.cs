using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Listings.Models
{
    public class ConversationCreated
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("sender_id")]
        public long SenderId { get; set; }

        [JsonProperty("receiver_id")]
        public long ReceiverId { get; set; }

        [JsonProperty("article_id")]
        public long ArticleId { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
