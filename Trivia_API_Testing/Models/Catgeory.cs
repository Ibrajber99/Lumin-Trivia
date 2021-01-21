using Newtonsoft.Json;

namespace Trivia_API_Testing.Models
{
    public class Catgeory
    {
        [JsonProperty("id")]
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
}