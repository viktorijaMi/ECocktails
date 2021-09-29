using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECocktails.Models
{
    public class Ingredients_Cocktails
    {
        public int CocktailId { get; set; }

        public Cocktail Cocktail { get; set; }

        public double Quantity { get; set; }

        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
