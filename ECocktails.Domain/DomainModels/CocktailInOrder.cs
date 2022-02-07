using ECocktails.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECocktails.Domain.DomainModels
{
    public class CocktailInOrder : BaseEntity
    {
        public int CocktailId { get; set; }
        public Cocktail OrderedCocktail { get; set; }
        public int OrderId { get; set; }
        public Order UserOrder { get; set; }
        public int Quantity { get; set; }
    }
}
