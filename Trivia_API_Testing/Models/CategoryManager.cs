using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Trivia_API_Testing.Models
{
    public class CategoryManager
    {
        [JsonProperty("trivia_categories")]
        [Display(Name ="Categories")]
        public List<Catgeory> CategoriesList { get; set; }
    }
}