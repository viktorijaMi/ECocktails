using ECocktails.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECocktails.Repository.Interface
{
    public interface ICocktailRepository
    {
        IEnumerable<Cocktail> GetAll();
        Cocktail Get(int id);
        void Add(Cocktail entity);
        void Update(Cocktail entity);
        void Delete(Cocktail entity);
    }
}
