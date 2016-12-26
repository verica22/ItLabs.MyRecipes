using ItLabs.MyRecipes.Domain;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PagedList;
using System.Collections.Generic;

namespace ItLabs.MyRecipes.UI.Controllers
{

    public class RecipesController : Controller
    {

        public const int pageSize = 8;

        public IRecipeManager _recipeManager { get; set; }

        public RecipesController(IRecipeManager recipeManager)
        {
            _recipeManager = recipeManager;
        }

        public ActionResult Index(int? page)
        {

            int pageNumber = (page ?? 1);

            return View(_recipeManager.GetRecipes().ToPagedList(pageNumber, pageSize));
        }
        [HttpPost]
        public ActionResult Search(string Name, bool IsDone, bool IsFavourite, int? page)
        {

            int pageNumber = (page ?? 1);
            var recipes = (dynamic)null;

            if (IsDone != false && IsFavourite != false)
            {
                recipes = _recipeManager.GetRecipes().Where(r =>
               r.Done &&
               r.Favorites &&
               r.Name.ToLower().Contains(Name))
              .ToPagedList(pageNumber, pageSize);

            }
            else if (IsDone != false)
            {
                recipes = _recipeManager.GetRecipes().Where(r =>
                r.Done &&
                r.Name.ToLower().Contains(Name))
                .ToPagedList(pageNumber, pageSize);

            }
            else if (IsFavourite != false)
            {
                recipes = _recipeManager.GetRecipes().Where(r =>
               r.Favorites &&
               r.Name.ToLower().Contains(Name))
               .ToPagedList(pageNumber, pageSize);

            }
            else
            {
                recipes = _recipeManager.GetRecipes().Where(r =>
                r.Name.ToLower().Contains(Name))
                .ToList().ToPagedList(pageNumber, pageSize);

            }
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
        //GET: Remove
        //public ActionResult Remove(int? Id)
        //{
        //    if (Id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Recipe recipe = _recipeManager.FindById(Convert.ToInt32(Id));
        //    if (recipe == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    //return View(recipe);
        //    return View(_recipeManager.FindById(Convert.ToInt32(Id)));
        //}
        //POST: Remove
        //[HttpPost, ActionName("Remove")]
        [HttpPost]
        //  [ValidateAntiForgeryToken]
        public ActionResult Remove(int Id)
        {

            _recipeManager.Remove(Id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult Save(Recipe recipe)
        {
            bool status = false;

            if (ModelState.IsValid)
            {
                _recipeManager.Save(recipe);
                status = true;
                
            }
            else
            {
                status = false;
            }
            return new JsonResult { Data = new { status = status } };
           
        }
        //GET: Edit
        public ActionResult Edit(int id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Recipe recipe = _recipeManager.FindById(id);
            if (recipe == null)
                return HttpNotFound();
            return View(recipe);
        }
        //POST: Edit
        [HttpPost]
        public ActionResult Edit(Recipe recipe)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _recipeManager.Edit(recipe);
                    return RedirectToAction("Index");
                }
                return View(recipe);
            }
            catch
            {
                return View();
            }

        }

        public JsonResult GetIngredients(string term)
        {

            List<string> ingredients;
            ingredients = _recipeManager.GetIngredients().Where(x => x.Name.ToLower().StartsWith(term))
                .Select(e => e.Name).Distinct().ToList();

            return Json(ingredients, JsonRequestBehavior.AllowGet);
        }
    }
}