using ECocktails.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECocktails.Domain.DomainModels
{
    public class Ingredients_Cocktails : BaseEntity
    {
        public int CocktailId { get; set; }

        public Cocktail Cocktail { get; set; }

        public double Quantity { get; set; }

        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
