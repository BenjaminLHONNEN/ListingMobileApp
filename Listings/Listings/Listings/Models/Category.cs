using Newtonsoft.Json;

namespace Listings.Models
{
    public class Category
    {
        [JsonProperty("id")] public int Id { get; set; }

        [JsonProperty("name")] public string Name { get; set; }
    }
}