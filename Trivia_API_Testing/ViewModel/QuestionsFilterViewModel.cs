using System.Collections.Generic;
using Trivia_API_Testing.Models;

namespace Trivia_API_Testing.ViewModel
{
    public class QuestionsFilterViewModel
    {
        public QuestionsFilterViewModel()
        {
            Catagories = new CategoryManager();
            Catagories.CategoriesList = new List<Catgeory>();
        }

        public CategoryManager Catagories { get; set; }

        public QuestionsFilter QuestionFilter { get; set; }

        public int CategoryId { get; set; }
    }
}