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
            //use automapper for this


            //Mapper.CreateMap<IEnumerable<Recipe>, IEnumerable<Recipe>>();
             //Mapper.CreateMap<Recipe, Recipe>();


           Mapper.Initialize(cfg => cfg.CreateMap<Recipe, Recipe>());
            return new List<Recipe>();// _recipeRepository.GetRecipes();

            

        }
    }
}
