using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItLabs.MyRecipes.Domain.Contracts
{
    class RecipeIngredients
    {
       
        public int RecipeId { get; set; }
       
        public int IngredientsId { get; set; }

        public virtual Recipe Recipe { get; set; }
        public virtual Ingredient Ingredient { get; set; }


        public int Quantity { get; set; }
    }
}
