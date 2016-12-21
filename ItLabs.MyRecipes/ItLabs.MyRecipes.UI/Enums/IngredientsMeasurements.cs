using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItLabs.MyRecipes.UI.Enums
{
    public class DropDownModel
    {
        public IngredientsMeasurements Measurements { get; set; }
    }
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
}