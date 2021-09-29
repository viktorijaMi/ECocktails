using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECocktails.Models
{
    public class Bar
    {
        [Key]
        public int Id { get; set; }
        public string Logo { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        //Relationship
        public List<Cocktail> Cocktails { get; set; }
    }
}
