using System.Collections.Generic;

namespace ItLabs.MyRecipes.Data
{
    public class Ingredient
    {
        public Ingredient()
        {
           
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Measurement { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
