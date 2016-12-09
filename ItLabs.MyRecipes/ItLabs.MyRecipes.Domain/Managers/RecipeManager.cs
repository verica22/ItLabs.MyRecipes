using System.Collections.Generic;
using ItLabs.MyRecipes.Data.Repository;
using AutoMapper;

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
            var recipes = _recipeRepository.GetRecipes();
            return Mapper.Map<IEnumerable<Recipe>>(recipes);
        }
    }
}
