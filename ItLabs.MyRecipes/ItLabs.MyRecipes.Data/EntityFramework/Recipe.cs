using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItLabs.MyRecipes.Data
{
    public class Recipe
    {
        public Recipe()
        {

        }
        public int RecipeId { get; set; }
        [Required]
        public string RecipeName { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }
        public bool Favorites { get; set; }

        public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}
