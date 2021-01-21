using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trivia_API_Testing.Models
{
    public class TriviaQuestionManager
    {
        public TriviaQuestionManager()
        {
            Questions = new List<TriviaQuestion>();
        }
        public List<TriviaQuestion> Questions { get; set; }
    }
}