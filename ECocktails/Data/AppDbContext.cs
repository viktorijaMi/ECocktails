using ECocktails.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECocktails.Data
{
    public class AppDbContext : DbContext
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


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Cocktail> Cocktails { get; set; }
        public DbSet<Ingredients_Cocktails> Ingredients_Cocktails { get; set; }
        public DbSet<Bar> Bars { get; set; }
        public DbSet<Barman> Barmans { get; set; }

        public DbSet<Glass> Glass { get; set; }

    }
}
