using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItLabs.MyRecipes.Domain.Automapper
{
    public class SaveRecipes : Profile
    {
        public SaveRecipes()
        {
            CreateMap<Recipe, Data.Recipe>()
             .ForMember(d => d.RecipeIngredients, o => o.Ignore());

            //CreateMap<RecipeIngredients, Data.RecipeIngredients>();
        }
            
    }
}
