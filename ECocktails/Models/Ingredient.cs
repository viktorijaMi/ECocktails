using ECocktails.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECocktails.Models
{
    public class Ingredient
    {  
        [Key]
        public int Id { get; set; }
        public string PictureUrl { get; set; }

        public string Name { get; set; }

        public IngredientType Type { get; set; }

        public string Bio { get; set; }
        
        //Relationships
        public List<Ingredients_Cocktails> Ingredients_Cocktails { get; set; }
    }
}
