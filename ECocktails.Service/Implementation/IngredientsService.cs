using ECocktails.Domain.DomainModels;
using ECocktails.Repository.Interface;
using ECocktails.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECocktails.Service.Implementation
{
    public class IngredientsService : IIngredientsService
    {
        private readonly IRepository<Ingredient> _ingredientRepository;
        public IngredientsService(IRepository<Ingredient> ingredientRepository)
        {
            this._ingredientRepository = ingredientRepository;
        }

        public void CreateNewIngredient(Ingredient ingredient)
        {
            this._ingredientRepository.Insert(ingredient);
        }

        public void DeleteIngredient(int id)
        {
            var ingredient = this.GetDetailsForIngredient(id);
            this._ingredientRepository.Delete(ingredient);
        }

        public List<Ingredient> GetAllIngredients()
        {
            return this._ingredientRepository.GetAll().ToList();
        }

        public Ingredient GetDetailsForIngredient(int id)
        {
            return this._ingredientRepository.Get(id);
        }

        public void UpdateExistingIngredient(Ingredient ingredient)
        {
            this._ingredientRepository.Update(ingredient);
        }
    }
}
