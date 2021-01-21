using Newtonsoft.Json;
using System.Collections.Generic;

namespace Trivia_API_Testing.Models
{
    public class TriviaQuestionDTO
    {

        [JsonProperty("category")]
        public string category { get; set; }

        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("difficulty")]
        public string difficulty { get; set; }

        [JsonProperty("question")]
        public string question { get; set; }

        [JsonProperty("correct_answer")]
        public string answer { get; set; }

        [JsonProperty("incorrect_answers")]
        public List<string> incorrect_answers { get; set; }

    }
}