using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ECocktails.Models
{
    public class Cocktail
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string PictureUrl { get; set; }

        //Relationship

        public List<Ingredients_Cocktails> Ingredients_Cocktails { get; set; }

        //Glass
        public int GlassId { get; set; }
        [ForeignKey("GlassId")]
        public Glass Glass{ get; set; }

        //Bar
        public int BarId { get; set; }
        [ForeignKey("BarId")]
        public Bar Bar { get; set; }

        //Barman
        public int BarmanId { get; set; }
        [ForeignKey("BarmanId")]
        public Barman Barman { get; set; }

    }
}
