using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECocktails.Domain.ViewModels
{
    public class NewCocktailVM
    {
        public int Id { get; set; }
        [Display(Name = "Cocktail name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Display(Name = "Cocktail description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }
        [Display(Name = "Cocktail image URL")]
        [Required(ErrorMessage = "Cocktail image URL is required")]
        public string ImageURL { get; set; }
        [Display(Name = "Cocktail created date")]
        [Required(ErrorMessage = "Cocktail created is required")]
        public DateTime DateCreated { get; set; }
        [Display(Name = "Select ingredient(s)")]
        [Required(ErrorMessage = "Cocktail ingredient(s) is required")]
        public List<int> IngredientIds { get; set; }
        [Display(Name = "Select a bar")]
        [Required(ErrorMessage = "Cocktail bar is required")]
        public int BarId { get; set; }
        [Display(Name = "Select a barman")]
        [Required(ErrorMessage = "Cocktail barman is required")]
        public int BarmanId { get; set; }
        [Display(Name = "Select a glass")]
        [Required(ErrorMessage = "Cocktail glass is required")]
        public int GlassId { get; set; }

    }
}
