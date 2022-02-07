using ECocktails.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ECocktails.Domain.DomainModels
{
    public class Cocktail: BaseEntity
    {
        [Display(Name="Cocktail name")]
        public string Name { get; set; }
        [Display(Name="Cocktail description")]
        public string Description { get; set; }
        [Display(Name="Price")]
        public double Price { get; set; }
        [Display(Name="Cocktail picture")]
        public string PictureUrl { get; set; }

        public DateTime DateCreated { get; set; }

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

        public virtual ICollection<CocktailInShoppingCart> CocktailInShoppingCarts { get; set; }
        public IEnumerable<CocktailInOrder> CocktailInOrders { get; set; }
    }
}
