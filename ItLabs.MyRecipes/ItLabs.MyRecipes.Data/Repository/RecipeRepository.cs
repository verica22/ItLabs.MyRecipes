using System.Collections.Generic;
using System.Linq;

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
        //public IEnumerable<Recipe> Search(string Name)
        //{
        //    //var result = (from recipe in db.Recipes where recipe.Name == Name select recipe).FirstOrDefault();
        //    //return result;
        //    var result = from c in db.Recipes select c;
        //    result=result.Where(s => s.Name.Contains(Name));
        //    return result;
        //}
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


        //public void Save(Recipe recipe)
        //{
        //    Recipe reci = new Recipe { Name = recipe.Name, Description = recipe.Description, Done = recipe.Done, Favorites = recipe.Favorites };

        //    foreach (var i in recipe.RecipeIngredients)
        //    {
        //        recipe.RecipeIngredients.Add(i);
        //    }

        //    db.Recipes.Add(reci);
        //    db.SaveChanges();

        //}

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


    //public void Save(Recipe recipe)
    //{
    //    if (recipe.Id == 0)
    //    {
    //        db.Recipes.Add(recipe);
    //    }
    //    else
    //    {
    //        db.Entry(recipe).State = System.Data.Entity.EntityState.Modified;
    //    }
    //    db.SaveChanges();

    //}
    //public  GetIngredients(Ingredient ingredient)
    //{

    //    List<string> ingredients;
    //    ingredients = db.Ingredients.Where(x => x.Name.StartsWith(term))
    //        .Select(e => e.Name).Distinct().ToList();
    //    return Json(ingredients, JsonRequestBehavior.AllowGet);
    //}
}
