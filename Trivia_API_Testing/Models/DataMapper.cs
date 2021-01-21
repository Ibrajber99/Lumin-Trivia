using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Trivia_API_Testing.Models;

namespace Trivia_API_Testing
{
    public static class DataMapper
    {

        public static TriviaQuestionManager MapTriviaQuestionManager(TriviaQuestionManagerDTO objDTO)
        {
            TriviaQuestionManager result = new TriviaQuestionManager();
            foreach(var questionDTO in objDTO.results)
            {
                var question = MapQuestionsFromDTO(questionDTO);
                result.Questions.Add(question);
            }
            return result;
        }

        private static TriviaQuestion MapQuestionsFromDTO(TriviaQuestionDTO objDTO)
        {
            TriviaQuestion result = new TriviaQuestion();
            result.Type = (QuestionType)
            Enum.Parse(typeof(QuestionType), objDTO.type, true);

            result.Difficulty = (QuestionDifficulty)
            Enum.Parse(typeof(QuestionDifficulty), objDTO.difficulty, true);

            result.Category = objDTO.category;

            string []filterString = objDTO.question.Split('&');
            result.Question = GetCleanedData(filterString);


            result.CorrectAnswer = GetCleanedData(objDTO.answer.Split('&'));

            result.PossibleAnswers.Add(objDTO.answer);
            result.PossibleAnswers.AddRange(objDTO.incorrect_answers);
            result.PossibleAnswers = GetCleanedData(result.PossibleAnswers);
            result.PossibleAnswers.OrderBy(x => Guid.NewGuid()).ToList();

            return result;
        }


        //Gets rid of Unicode characters
        private static string GetCleanedData(string[] filterString)
        {
            StringBuilder sb =  new StringBuilder();
            foreach (var ss in filterString)
            {
                StringBuilder tmpSb = new StringBuilder();
                 tmpSb.Append(ss);
                int indexFind = ss.IndexOf(';', 0, tmpSb.Length);
                if (indexFind != -1)
                {
                    tmpSb.Remove(0, 5);
                    sb.Append(tmpSb.ToString());
                }
                else
                    sb.Append(ss);
            }
            return sb.ToString();
        }

        private static List<string> GetCleanedData(List<string> filterStringList)
        {
            List<string> res = new List<string>();
            foreach(var entry in filterStringList)
            {
                string[] tmpholder = entry.Split('&');
                res.Add(GetCleanedData(tmpholder));
            }

            return res;
        }

    }
}