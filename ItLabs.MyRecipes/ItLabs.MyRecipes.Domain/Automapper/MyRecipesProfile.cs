using AutoMapper;

namespace ItLabs.MyRecipes.Domain.Automapper
{
    public class MyRecipesProfile : Profile
    {
        public MyRecipesProfile()
        {
            CreateMap<Data.Recipe, Recipe>()
                  .ForMember(d => d.Ingredients, o => o.Ignore());

            CreateMap<Data.Ingredient, Ingredient>();
        }
    }
}
