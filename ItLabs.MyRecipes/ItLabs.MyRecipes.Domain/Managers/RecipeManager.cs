using System.Collections.Generic;
using ItLabs.MyRecipes.Data.Repository;
using AutoMapper;
using System;

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

        public void Save(Recipe recipe)
        {
            //var result = Mapper.Map<Recipe>(recipe);
            //_recipeRepository.Save(Mapper.Map<Recipe>(recipe));

          // _recipeRepository.Save(recipe);
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
        //public  GetIngredients(Ingredient ingredient)
        //{
        //    _recipeRepository.GetIngredients(ingredients);
        //}

    }
}
