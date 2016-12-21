﻿using System.Collections.Generic;

namespace ItLabs.MyRecipes.Domain
{
    public class Recipe
    {
        public Recipe()
        {
            RecipeIngredients = new List<RecipeIngredients>();
        }

        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }
        public bool Favorites { get; set; }

        //public virtual ICollection<Ingredient> Ingredients { get; set; }
        public virtual List<RecipeIngredients> RecipeIngredients { get; set; }

        public enum IngredientsMeasurements
        {
           
            Spoon = 1,
            Teaspoon = 2,
            Dessertspoon = 3,
            Cup = 4,
            Gallon = 5,
            Litre = 6,
            Kg = 7,
            ML = 8,
            Number = 9

        }
        public IngredientsMeasurements Measurements { get; set; }
    }
}
