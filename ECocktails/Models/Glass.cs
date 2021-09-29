using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECocktails.Models
{
    public class Glass
    {
        [Key]
        public int Id { get; set; }

        public string PictureUrl { get; set; }

        public List<Cocktail> Cocktails { get; set; }
    }
}
