using ItLabs.MyRecipes.Domain;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PagedList;



namespace ItLabs.MyRecipes.UI.Controllers
{
   
    public class HomeController : Controller
    {

        public const int pageSize = 5;
        //public const int pageNumber = (page ?? 1);
        public IRecipeManager _recipeManager { get; set; }

        public HomeController(IRecipeManager recipeManager)
        {
            _recipeManager = recipeManager;
        }

        public ActionResult Index(int? page)
        {
           
            int pageNumber = (page ?? 1);

            return View(_recipeManager.GetRecipes().ToPagedList(pageNumber,pageSize));
        }
        [HttpPost]
        public ActionResult Search(string Name,bool isDone,bool IsFavourite)
        {

            //int pageNumber = (page ?? 1);
            //var recipes = _recipeManager.GetRecipes().Where(r => r.Name.Contains(Name)).ToList().ToPagedList(pageNumber, pageSize);
            //return View(recipes);
            var recipes = _recipeManager.GetRecipes().Where(r =>
                    r.Name.Contains(Name.ToLower()) ||
                    r.Done ||
                    r.Favorites)
                    .ToList();

            return View(recipes);


        }
        public ActionResult Done(int? page)
        {
           
            int pageNumber = (page ?? 1);
            var recipes = _recipeManager.GetRecipes().Where(r => r.Done).ToPagedList(pageNumber, pageSize);
            return View(recipes);
        }
        public ActionResult Favorites(int? page)
        {
           
            int pageNumber = (page ?? 1);
            var recipes = _recipeManager.GetRecipes().Where(r => r.Favorites).ToPagedList(pageNumber, pageSize);
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

        [HttpPost]
        public JsonResult Save(Recipe recipe)
        {
            bool status = false;
            //if (ModelState.IsValid)
            var isValidModel = TryUpdateModel(recipe);
            if (isValidModel)
            {
                _recipeManager.Save(recipe);
            }
            else
            {
                status = false;
            }
            return new JsonResult { Data = new { status = status } };
        }


        //public JsonResult GetIngredients(string term)
        //{
        //    _recipeManager.GetIngredients(Ingredient ingredient);

        //    //List<string> ingredients;
        //    //ingredients = db.Ingredients.Where(x => x.Name.StartsWith(term))
        //    //    .Select(e => e.Name).Distinct().ToList();

        //    return Json(ingredients, JsonRequestBehavior.AllowGet);
        //}
    }
}