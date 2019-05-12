using Newtonsoft.Json;

namespace Listings.Models
{
    public class CreateConversation
    {
        [JsonProperty("sender_id")]
        public long SenderId { get; set; }
        [JsonProperty("receiver_id")]
        public long ReceiverId { get; set; }
        [JsonProperty("article_id")]
        public long ArticleId { get; set; }
    }
}
