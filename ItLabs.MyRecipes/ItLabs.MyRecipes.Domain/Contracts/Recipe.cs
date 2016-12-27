using ItLabs.MyRecipes.Domain.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ItLabs.MyRecipes.Domain
{
    public class Recipe
    {
        public Recipe()
        {
            RecipeIngredients = new List<RecipeIngredients>();
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }
        public bool Favorites { get; set; }

        public virtual List<RecipeIngredients> RecipeIngredients { get; set; }

        //public virtual List<Ingredient> Ingredient { get; set; }

        //public IngredientsMeasurements Measurements { get; set; }
    }
}
