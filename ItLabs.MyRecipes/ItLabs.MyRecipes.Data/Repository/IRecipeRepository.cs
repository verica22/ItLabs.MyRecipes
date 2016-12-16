using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItLabs.MyRecipes.Data.Repository
{
   public interface IRecipeRepository
    {
        void Save(Recipe recipe);
        void Remove(int Id);
        IEnumerable<Recipe> GetRecipes();
        Recipe FindById(int Id);
        
      }
}
