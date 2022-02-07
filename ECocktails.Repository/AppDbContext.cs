using ECocktails.Domain.DomainModels;
using ECocktails.Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECocktails.Repository
{
    public class AppDbContext : IdentityDbContext<CocktailShopApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingredients_Cocktails>()
                .HasKey(ic => new
            {
                ic.IngredientId,
                ic.CocktailId
            });

            modelBuilder.Entity<Ingredients_Cocktails>()
                .HasOne(c => c.Cocktail)
                .WithMany(ic => ic.Ingredients_Cocktails)
                .HasForeignKey(c => c.CocktailId);

            modelBuilder.Entity<Ingredients_Cocktails>()
                .HasOne(c => c.Ingredient)
                .WithMany(ic => ic.Ingredients_Cocktails)
                .HasForeignKey(c => c.IngredientId);

            modelBuilder.Entity<ShoppingCart>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<CocktailInShoppingCart>()
                .HasOne(z => z.ShoppingCart)
                .WithMany(z => z.CocktailInShoppingCarts)
                .HasForeignKey(z => z.CocktailId);

            modelBuilder.Entity<CocktailInShoppingCart>()
                .HasOne(z => z.Cocktail)
                .WithMany(z => z.CocktailInShoppingCarts)
                .HasForeignKey(z => z.ShoppingCartId);

            modelBuilder.Entity<ShoppingCart>()
                .HasOne<CocktailShopApplicationUser>(z => z.Owner)
                .WithOne(z => z.UserCart)
                .HasForeignKey<ShoppingCart>(z => z.UserId);

            modelBuilder.Entity<CocktailInOrder>()
                .HasOne(z => z.OrderedCocktail)
                .WithMany(z => z.CocktailInOrders)
                .HasForeignKey(z => z.OrderId);

            modelBuilder.Entity<CocktailInOrder>()
                .HasOne(z => z.UserOrder)
                .WithMany(z => z.CocktailInOrder)
                .HasForeignKey(z => z.CocktailId);


            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<Cocktail> Cocktails { get; set; }
        public virtual DbSet<Ingredients_Cocktails> Ingredients_Cocktails { get; set; }
        public virtual DbSet<Bar> Bars { get; set; }
        public virtual DbSet<Barman> Barmans { get; set; }

        public virtual DbSet<Glass> Glass { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<CocktailInShoppingCart> CocktailInShoppingCarts { get; set; }
        public virtual DbSet<CocktailInOrder> CocktailInOrders { get; set; }
    }
}
