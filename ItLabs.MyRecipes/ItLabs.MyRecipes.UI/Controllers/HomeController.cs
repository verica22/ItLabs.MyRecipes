using ItLabs.MyRecipes.Domain;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ItLabs.MyRecipes.UI.Controllers
{
    public class HomeController : Controller
    {
        public IRecipeManager _recipeManager { get; set; }

        public HomeController(IRecipeManager recipeManager)
        {
            _recipeManager = recipeManager;
        }

        public ActionResult Index()
        {
            return View(_recipeManager.GetRecipes());
        }
        public ActionResult Done()
        {
            var recipes = _recipeManager.GetRecipes().Where(r => r.Done);
            return View(recipes);
        }
        public ActionResult Favorites()
        {
            var recipes = _recipeManager.GetRecipes().Where(r => r.Favorites);
            return View(recipes);
        }
        ////GET: Detail
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
             Recipe recipe = _recipeManager.FindById(Convert.ToInt32(id));
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
         }

        //GET: Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        ////POST: Create
        [HttpPost]
        public ActionResult Create(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                _recipeManager.Save(recipe);
                 return RedirectToAction("Index");
            }
            return View(recipe);
        }
        ////GET: Edit
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    Recipe recipe = db.Recipes.Find(id);
        //    if (recipe == null)
        //        return HttpNotFound();
        //    return View(recipe);
        //}
        ////POST: Edit
        //[HttpPost]
        //public ActionResult Edit(Recipe recipe)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            db.Entry(recipe).State = System.Data.Entity.EntityState.Modified;
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //        return View(recipe);
        //    }
        //    catch
        //    {
        //        return View();
        //    }

        //}

        //GET: Remove
        public ActionResult Remove(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = _recipeManager.FindById(Convert.ToInt32(Id));
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }
        ////POST: Remove
        [HttpPost, ActionName("Remove")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int Id)
        {
            //Recipe recipe = FindById(Convert.ToInt32(Id));
            _recipeManager.Remove(Id);
            return RedirectToAction("Index");
        }

        //public JsonResult GetIngredients(string term)
        //{
        //    RecipesEntities2 db = new RecipesEntities2();
        //    List<string> ingredients;
        //    ingredients = db.Ingredients.Where(x => x.IngredientsName.StartsWith(term))
        //        .Select(e => e.IngredientsName).Distinct().ToList();
        //    return Json(ingredients, JsonRequestBehavior.AllowGet);
        //}
    }
}