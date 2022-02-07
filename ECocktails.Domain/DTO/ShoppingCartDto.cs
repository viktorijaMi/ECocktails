using ECocktails.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECocktails.Domain.DTO
{
    public class ShoppingCartDto
    {
        public List<CocktailInShoppingCart> Cocktails { get; set; }
        public double TotalPrice { get; set; }
    }
}
