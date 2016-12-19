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
            var dbRecipes = _recipeRepository.GetRecipes();
            var recipes = Mapper.Map<IEnumerable<Recipe>>(dbRecipes);
            return recipes;
        }

        public void Save(Recipe recipe)
        {
            var dbRecipe = Mapper.Map<Data.Recipe>(recipe);

            _recipeRepository.Save(dbRecipe);
        }

        public void Remove(int Id)
        {
            _recipeRepository.Remove(Id);
        }

        public Recipe FindById(int Id)
        {
            var result = _recipeRepository.FindById(Id);
            return Mapper.Map<Recipe>(result);
           
        }
        //public Recipe Search(string Name)
        //{
        //    var result = _recipeRepository.Search(Name);
        //    return Mapper.Map<Recipe>(result);
            

        //}
        //public  GetIngredients(Ingredient ingredient)
        //{
        //    _recipeRepository.GetIngredients(ingredients);
        //}

    }
}
