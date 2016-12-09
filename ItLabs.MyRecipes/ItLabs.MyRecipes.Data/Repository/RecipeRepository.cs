using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItLabs.MyRecipes.Data.Repository
{
   public class RecipeRepository : IRecipeRepository
    {
        RecipeDBContext db = new RecipeDBContext();
        public Recipe FindById(int Id)
        {
            var result = (from recipe in db.Recipes where recipe.Id == Id select recipe).FirstOrDefault();
            return result;
        }

        public IEnumerable<Recipe> GetRecipes()
        {
            return db.Recipes.ToList();
        }

        public void Remove(int Id)
        {
            Recipe recipe = db.Recipes.Find(Id);
            db.Recipes.Remove(recipe);
            db.SaveChanges();
        }

        public void Save(Recipe recipe)
        {
            if (recipe.Id == 0)
            {
                db.Recipes.Add(recipe);
            }
            else
            {
                db.Entry(recipe).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();

        }
    }
}
