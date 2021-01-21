using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Trivia_API_Testing.Models;
using Trivia_API_Testing.Utilities;
using Trivia_API_Testing.ViewModel;

namespace Trivia_API_Testing.Controllers
{
    public class TriviaController : Controller
    {

        private static TriviaChallengeViewModel triviaQuestionsviewModel =
            new TriviaChallengeViewModel();

        private static CategoryManager categoryManager;
        private static APIJsonParser apiJsonCaller;

        public TriviaController()
        {
            categoryManager = new CategoryManager();
            apiJsonCaller = new APIJsonParser();
        }

        // GET: Trivia
        public ActionResult Index()
        {
            return View();
        }

        //Gets Questions from the API id is optional for category type
        [HttpGet]
        public async Task<ActionResult> GetQuestions(int? id)
        {
            string apiURL = "";
            TriviaQuestionManagerDTO tmpQuestionManagerDTO = 
            new TriviaQuestionManagerDTO();

            if (!id.HasValue)
                apiURL = "https://opentdb.com/api.php?amount=10&type=multiple";
            else
                apiURL = $"https://opentdb.com/api.php?amount=10&category= {id}";

            if (triviaQuestionsviewModel.isSessionFinished || triviaQuestionsviewModel.currentQuestion == 0)
            {
                var jsonData = await apiJsonCaller.GetJsonString(apiURL);
                tmpQuestionManagerDTO = JsonConvert.DeserializeObject<TriviaQuestionManagerDTO>(jsonData);
                triviaQuestionsviewModel.questionsManager = DataMapper.MapTriviaQuestionManager(tmpQuestionManagerDTO);
            }
            return View(triviaQuestionsviewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> GetQuestions(QuestionsFilter questionFilter)
        {
            if (!ModelState.IsValid)
            {
                var vm = new QuestionsFilterViewModel()
                {
                    Catagories = categoryManager
                };
                return View("GetCatagories", vm);
            }
            else
            {
                TriviaQuestionManagerDTO tmpQuestionManagerDTO =
                new TriviaQuestionManagerDTO();

                string apiURL =
                $"https://opentdb.com/api.php?amount={questionFilter.NumOfQuestions}&category={questionFilter.CategoryId}&difficulty={questionFilter.Difficulty}&type={questionFilter.Type}";

                var jsonData = await apiJsonCaller.GetJsonString(apiURL);
                tmpQuestionManagerDTO = JsonConvert.DeserializeObject<TriviaQuestionManagerDTO>(jsonData);
                triviaQuestionsviewModel.questionsManager = DataMapper.MapTriviaQuestionManager(tmpQuestionManagerDTO);

                return View("GetQuestions", triviaQuestionsviewModel);
            }
        }

        //Gets all Questions Categories
        [HttpGet]
        public async Task<ActionResult> GetCatagories()
        {
            triviaQuestionsviewModel.resetViewModel();

            string apiURL = "https://opentdb.com/api_category.php";

            QuestionsFilterViewModel vm = new QuestionsFilterViewModel();

            var jsonData = await apiJsonCaller.GetJsonString(apiURL);
            categoryManager = JsonConvert.DeserializeObject<CategoryManager>(jsonData);

            vm.Catagories = categoryManager;

            return View(vm);
        }

        //Method to grab the users answer form the question
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetAnswer(string answer)
        {
            if (String.IsNullOrEmpty(answer))
                return View("Index");

            if (answer.Equals(triviaQuestionsviewModel.questionsManager.
            Questions.ElementAt(triviaQuestionsviewModel.currentQuestion).CorrectAnswer))
            {
                triviaQuestionsviewModel.Score += 1;
                Console.WriteLine("Correct");
            }
            else
                Console.WriteLine("False");

            return GetNextQuestion();
        }

        //Moves to the next questions
        [HttpGet]
        public ActionResult GetNextQuestion()
        {
            triviaQuestionsviewModel.currentQuestion++;
            if (triviaQuestionsviewModel.currentQuestion >= 
                triviaQuestionsviewModel.questionsManager.Questions.Count)
                triviaQuestionsviewModel.isSessionFinished = true;

            return  View("GetQuestions",
            triviaQuestionsviewModel);
        }
    }
}