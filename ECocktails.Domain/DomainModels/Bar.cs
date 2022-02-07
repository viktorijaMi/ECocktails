using ECocktails.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECocktails.Domain.DomainModels
{
    public class Bar: BaseEntity
    {
        [Display(Name="Bar Logo")]
        public string Logo { get; set; }
        [Display(Name="Bar Name")]
        public string Name { get; set; }
        [Display(Name = "Bar Address")]
        public string Address { get; set; }

        //Relationship
        public List<Cocktail> Cocktails { get; set; }
    }
}
