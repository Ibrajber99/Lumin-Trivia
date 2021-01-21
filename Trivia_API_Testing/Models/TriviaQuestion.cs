using System.Collections.Generic;

namespace Trivia_API_Testing.Models
{
    public class TriviaQuestion
    {
        public TriviaQuestion()
        {
            PossibleAnswers = new List<string>();
        }

        public QuestionType Type { get; set; }

        public QuestionDifficulty Difficulty { get; set; }

        public string Category { get; set; }

        public string Question { get; set; }

        public string CorrectAnswer { get; set; }

        public List<string> PossibleAnswers { get; set; }
    }
}