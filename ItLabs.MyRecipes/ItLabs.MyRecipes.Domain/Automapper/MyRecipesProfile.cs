using AutoMapper;
using System.Linq;

namespace ItLabs.MyRecipes.Domain.Automapper
{
    public class MyRecipesProfile : Profile
    {
        public MyRecipesProfile()
        {
            CreateMap<Data.RecipeIngredients, RecipeIngredients>()
               .ForMember(d => d.RecipeName, o => o.MapFrom(x => x.Recipe.Name))
               .ForMember(d => d.IngredientName, o => o.MapFrom(x => x.Ingredient.Name))
               .ForMember(d => d.IngredientMeasurement, o => o.MapFrom(x => x.Ingredient.Measurement));

            CreateMap<Data.Recipe, Recipe>()
                  .ForMember(d => d.RecipeIngredients, o => o.MapFrom(x => x.RecipeIngredients));

            CreateMap<Data.Ingredient, Ingredient>()
                 .ForMember(d => d.RecipeIngredients, o => o.MapFrom(x => x.RecipeIngredients));

           
        }
    }
}
