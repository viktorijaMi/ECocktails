using ECocktails.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECocktails.Repository.Interface
{
    public interface IUserRepository
    {
        IEnumerable<CocktailShopApplicationUser> GetAll();
        CocktailShopApplicationUser Get(string id);
        void Insert(CocktailShopApplicationUser entity);
        void Update(CocktailShopApplicationUser entity);
        void Delete(CocktailShopApplicationUser entity);
    }
}
