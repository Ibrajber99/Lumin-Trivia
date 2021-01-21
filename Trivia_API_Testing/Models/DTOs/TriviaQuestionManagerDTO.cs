using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trivia_API_Testing.Models
{
    public class TriviaQuestionManagerDTO
    {
        public TriviaQuestionManagerDTO()
        {
            results = new List<TriviaQuestionDTO>();
        }
        public List<TriviaQuestionDTO> results { get; set; }
    }
}