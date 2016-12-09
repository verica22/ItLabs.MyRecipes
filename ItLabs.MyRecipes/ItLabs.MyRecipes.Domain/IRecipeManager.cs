using System.Collections.Generic;

namespace ItLabs.MyRecipes.Domain
{
    public interface IRecipeManager
    {
        IEnumerable<Recipe> GetRecipes();
    }
}
