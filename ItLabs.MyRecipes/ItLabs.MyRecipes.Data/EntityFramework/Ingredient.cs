using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItLabs.MyRecipes.Data
{
    class Ingredient
    {
        public Ingredient()
        {
           
        }
        public int IngredientsId { get; set; }
        public string IngredientsName { get; set; }
        public string Measurement { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
