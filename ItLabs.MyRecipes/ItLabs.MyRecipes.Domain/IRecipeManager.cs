using System.Collections.Generic;

namespace ItLabs.MyRecipes.Domain
{
    public interface IRecipeManager
    {
        IEnumerable<Recipe> GetRecipes();
        void Save(Recipe recipe);
        void Remove(int Id);
        Recipe FindById(int Id);
        void Edit(Recipe recipe);

    }
    public abstract class EntityBase
    {
        public int Id { get; protected set; }
    }
}
