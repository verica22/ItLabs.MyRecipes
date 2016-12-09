using System.Collections.Generic;
using ItLabs.MyRecipes.Data.Repository;

namespace ItLabs.MyRecipes.Domain.Managers
{
    public class RecipeManager : IRecipeManager
    {
        public IRecipeRepository _recipeRepository { get; set; }


        public RecipeManager(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public IEnumerable<Recipe> GetRecipes()
        {
            //use automapper for this
            return new List<Recipe>();// _recipeRepository.GetRecipes();
        }
    }
}
