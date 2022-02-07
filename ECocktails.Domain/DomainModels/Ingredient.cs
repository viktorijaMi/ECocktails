using ECocktails.Domain;
using ECocktails.Domain.Base;
using ECocktails.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECocktails.Domain.DomainModels
{
    public class Ingredient: BaseEntity
    {  
        [Display(Name = "Picture")]
        [Required(ErrorMessage = "Picture url is required!")]
        public string PictureUrl { get; set; }
        [Display(Name = "Name of ingredient")]
        [Required(ErrorMessage = "Name is required!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 chars")]
        public string Name { get; set; }
        [Display(Name = "Ingredient type")]
        [Required(ErrorMessage = "Type is required!")]
        public IngredientType IngredientType { get; set; }
        [Display(Name = "Biography")]

        public string Bio { get; set; }
        
        //Relationships
        public List<Ingredients_Cocktails> Ingredients_Cocktails { get; set; }
    }
}
