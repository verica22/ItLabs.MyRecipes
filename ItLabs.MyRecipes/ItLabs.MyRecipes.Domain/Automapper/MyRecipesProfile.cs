using AutoMapper;

namespace ItLabs.MyRecipes.Domain.Automapper
{
    public class MyRecipesProfile : Profile
    {
        public MyRecipesProfile()
        {
            CreateMap<Data.Recipe, Recipe>()
                  .ForMember(d => d.RecipeIngredients, o => o.Ignore());

            CreateMap<Data.Ingredient, Ingredient>();


        }
    }
}
