using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ItLabs.MyRecipes.UI.Controllers
{
    public class HomeController : Controller
    {
        RecipeRepository repository = new RecipeRepository();
        public ActionResult Index()
        {
            return View(repository.GetRecipes());
        }
        public ActionResult Done()
        {
            var recipes = repository.GetRecipes().Where(r => r.Done);
            return View(recipes);
        }
        public ActionResult Favorites()
        {
            var recipes = repository.GetRecipes().Where(r => r.Favorites);
            return View(recipes);
        }
        //GET: Detail
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = repository.FindById(Convert.ToInt32(id));
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);

        }
        //GET: Create
        //[HttpGet]
        //public ActionResult Create()
        //{
        //    return View();
        //}
        ////POST: Create
        //[HttpPost]
        //public ActionResult Create(Recipe recipe)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Recipes.Add(recipe);

        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(recipe);
        //}
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

        //GET: Delete
        public ActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = repository.FindById(Convert.ToInt32(Id));
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }
        //POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int Id)
        {
            //Recipe recipe = FindById(Convert.ToInt32(Id));
            repository.Remove(Id);
            return RedirectToAction("Index");
        }
    }
}