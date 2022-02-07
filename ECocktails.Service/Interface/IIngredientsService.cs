using ECocktails.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECocktails.Service.Interface
{
    public interface IIngredientsService
    {
        List<Ingredient> GetAllIngredients();
        Ingredient GetDetailsForIngredient(int id);
        void CreateNewIngredient(Ingredient ingredient);
        void UpdateExistingIngredient(Ingredient ingredient);
        void DeleteIngredient(int id);
    }
}
