using ECocktails.Domain.Identity;
using ECocktails.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECocktails.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext context;
        private DbSet<CocktailShopApplicationUser> entities;
        string errorMessage = string.Empty;

        public UserRepository(AppDbContext context)
        {
            this.context = context;
            entities = context.Set<CocktailShopApplicationUser>();

        }
        public void Delete(CocktailShopApplicationUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        public CocktailShopApplicationUser Get(string id)
        {
            return entities
                .Include(z => z.UserCart)
               .Include("UserCart.CocktailInShoppingCarts")
               .Include("UserCart.CocktailInShoppingCarts.Cocktail")
               .SingleOrDefault(s => s.Id == id);
        }

        public IEnumerable<CocktailShopApplicationUser> GetAll()
        {
            return entities.AsEnumerable();
        }

        public void Insert(CocktailShopApplicationUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(CocktailShopApplicationUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }
    }
}
