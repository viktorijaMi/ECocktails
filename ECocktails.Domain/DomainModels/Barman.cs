using ECocktails.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECocktails.Domain.DomainModels
{
    public class Barman: BaseEntity
    {
        [Display(Name = "Picture")]
        public string PictureUrl { get; set; }
        [Display(Name = "Full name")]

        public string FullName { get; set; }
        [Display(Name = "Biography")]

        public string Bio { get; set; }

        //Relationship
        public List<Cocktail> Cocktails { get; set; }
    }
}
