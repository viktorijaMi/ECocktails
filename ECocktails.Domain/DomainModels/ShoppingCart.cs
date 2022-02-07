using ECocktails.Domain.Base;
using ECocktails.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECocktails.Domain.DomainModels
{
    public class ShoppingCart : BaseEntity
    {
        public string UserId { get; set; }
        public CocktailShopApplicationUser Owner { get; set; }
        public virtual ICollection<CocktailInShoppingCart> CocktailInShoppingCarts { get; set; }
    }
}
