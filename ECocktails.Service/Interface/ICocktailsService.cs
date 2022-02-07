using ECocktails.Domain.DomainModels;
using ECocktails.Domain.DTO;
using ECocktails.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECocktails.Service.Interface
{
    public interface ICocktailsService
    {
        List<Cocktail> GetAllCocktails();
        Cocktail GetDetailsForCocktail(int id);
        void CreateNewCocktail(NewCocktailVM cocktail);
        void UpdateExistingCocktail(NewCocktailVM cocktail);
        void DeleteCocktail(int id);

        NewCocktailDropDownsVM GetNewCocktailDropdownsValues();

        AddToShoppingCartDto GetShoppingCartInfo(int id);

        bool AddToShoppingCart(AddToShoppingCartDto item, string userID);
    }
}
