using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Trivia_API_Testing.Models;

namespace Trivia_API_Testing.ViewModel
{
    public class TriviaChallengeViewModel
    {
        public TriviaChallengeViewModel()
        {
            currentQuestion = 0;
            isSessionFinished = false;
            questionsManager = new TriviaQuestionManager();
            Score = 0;
        }

        public TriviaQuestionManager questionsManager { get; set; }

        public bool isSessionFinished { get; set; }

        public int currentQuestion { get; set; }

        public int Score { get; set; }

        public void resetViewModel()
        {
            currentQuestion = 0;
            isSessionFinished = false;
            questionsManager = new TriviaQuestionManager();
            Score = 0;
        }
    }
}