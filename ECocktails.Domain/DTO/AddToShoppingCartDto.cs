using ECocktails.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECocktails.Domain.DTO
{
    public class AddToShoppingCartDto
    {
        public Cocktail SelectedCocktail { get; set; }
        public int CocktailId { get; set; }
        public int Quantity { get; set; }
    }
}
