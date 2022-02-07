using ECocktails.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECocktails.Domain.ViewModels
{
    public class NewCocktailDropDownsVM
    {
        public List<Bar> Bars { get; set; }
        public List<Barman> Barmen { get; set; }
        public List<Glass> Glasses { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public NewCocktailDropDownsVM()
        {
            Bars = new List<Bar>();
            Barmen = new List<Barman>();
            Glasses = new List<Glass>();
            Ingredients = new List<Ingredient>();
        }
    }
}
