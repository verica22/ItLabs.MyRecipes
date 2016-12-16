using ItLabs.MyRecipes.Data;
using System.Collections.Generic;

namespace ItLabs.MyRecipes.Domain
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Measurement { get; set; }

        //public virtual ICollection<Recipe> Recipes { get; set; }
        public virtual ICollection<RecipeIngredients> RecipeIngredients { get; set; }
    }
}
