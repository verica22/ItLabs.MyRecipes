using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItLabs.MyRecipes.Data
{
    class RecipeDBContext : DbContext
    {
        public RecipeDBContext() : base("RecipeDB-DataAnnotations")
        {


        }
        public virtual ICollection<Recipe> Recipes { get; set; }
        public virtual ICollection<Ingredient> Ingredients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
