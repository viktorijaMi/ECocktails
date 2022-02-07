using ECocktails.Domain.Base;
using ECocktails.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECocktails.Domain.DomainModels
{
    public class Order : BaseEntity
    {
        public string UserId { get; set; }
        public CocktailShopApplicationUser User { get; set; }
        public IEnumerable<CocktailInOrder> CocktailInOrder { get; set; }
    }
}
