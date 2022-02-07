using ECocktails.Domain.Base;
using ECocktails.Domain.DomainModels;
using ECocktails.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECocktails.Repository.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext context;
        private DbSet<Order> entities;
        string errorMessage = string.Empty;

        public OrderRepository(AppDbContext context)
        {
            this.context = context;
            entities = context.Set<Order>();
        }
        public List<Order> GetAllOrders()
        {
            return entities
                       .Include(z => z.User)
                       .Include(z => z.CocktailInOrder)
                       .Include("CocktailInOrder.OrderedCocktail")
                       .ToListAsync().Result;
        }

        public Order GetOrderDetails(BaseEntity model)
        {
            return entities
               .Include(z => z.User)
               .Include(z => z.CocktailInOrder)
               .Include("CocktailInOrder.OrderedCocktail")
               .SingleOrDefaultAsync(z => z.Id == model.Id).Result;
        }
    }
}
