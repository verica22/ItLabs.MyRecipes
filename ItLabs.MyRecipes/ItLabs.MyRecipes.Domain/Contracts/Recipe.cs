using System.Collections.Generic;

namespace ItLabs.MyRecipes.Domain
{
    public class Recipe
    {
        public Recipe()
        {
            RecipeIngredients = new List<RecipeIngredients>();
        }

        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }
        public bool Favorites { get; set; }

        //public virtual ICollection<Ingredient> Ingredients { get; set; }
        public virtual List<RecipeIngredients> RecipeIngredients { get; set; }
    }
}
