﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ItLabs.MyRecipes.Data
{
    public class Ingredient
    {
        public Ingredient()
        {
            this.RecipeIngredients = new HashSet<RecipeIngredients>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Measurement { get; set; }

       // public virtual ICollection<Recipe> Recipes { get; set; }
        public virtual ICollection<RecipeIngredients> RecipeIngredients { get; set; }

    }
}
