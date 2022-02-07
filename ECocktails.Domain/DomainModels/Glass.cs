using ECocktails.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECocktails.Domain.DomainModels
{
    public class Glass: BaseEntity
    {
        [Display(Name = "Glass Picture")]
        public string PictureUrl { get; set; }

        public List<Cocktail> Cocktails { get; set; }
    }
}
