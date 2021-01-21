using System.ComponentModel.DataAnnotations;

namespace Trivia_API_Testing.Models
{
    public class QuestionsFilter
    {

        public int CategoryId { get; set; }

        public QuestionDifficulty Difficulty { get; set; }

        public QuestionType Type { get; set; }

        [Display(Name ="Questions amount")]
        [Range(1,30)]
        public int NumOfQuestions { get; set; }
    }
}