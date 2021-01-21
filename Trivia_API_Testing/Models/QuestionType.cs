using System.ComponentModel.DataAnnotations;


namespace Trivia_API_Testing.Models
{
   public enum QuestionType
    {
        multiple,
        [Display(Name ="True of False")]
        boolean
    }
}