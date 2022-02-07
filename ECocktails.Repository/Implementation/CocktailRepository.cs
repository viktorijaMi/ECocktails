using ECocktails.Domain.DomainModels;
using ECocktails.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECocktails.Repository.Implementation
{
    public class CocktailRepository : ICocktailRepository
    {
        private readonly AppDbContext _context;

        public CocktailRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Cocktail entity)
        {
            _context.Cocktails.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Cocktail entity)
        {
            _context.Cocktails.Remove(entity);
            _context.SaveChanges();
        }

        public Cocktail Get(int id)
        {
            return _context.Cocktails
                            .Include("Bar")
                            .Include("Barman")
                            .Include("Glass")
                            .Include("Ingredients_Cocktails")
                            .Include("Ingredients_Cocktails.Ingredient")
                            .FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Cocktail> GetAll()
        {
            return _context.Cocktails
                            .Include("Bar")
                            .Include("Barman")
                            .Include("Glass")
                            .ToList();
        }

        public void Update(Cocktail entity)
        {
            _context.Cocktails.Update(entity);
            _context.SaveChanges();
        }
    }
}
