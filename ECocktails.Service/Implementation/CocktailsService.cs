using ECocktails.Domain.DomainModels;
using ECocktails.Domain.DTO;
using ECocktails.Domain.ViewModels;
using ECocktails.Repository.Interface;
using ECocktails.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECocktails.Service.Implementation
{
    public class CocktailsService : ICocktailsService
    {
        private readonly ICocktailRepository _cocktailRepository;
        private readonly IRepository<Ingredients_Cocktails> _ingredientsCocktailsRepository;
        private readonly IRepository<CocktailInShoppingCart> _cocktailInShoppingCartRepository;
        private readonly IUserRepository _userRepository;
        private readonly IBarmansService _barmenService;
        private readonly IBarsService _barsService;
        private readonly IGlassesService _glassesService;
        private readonly IIngredientsService _ingredientsService;

        public CocktailsService(ICocktailRepository cocktailRepository, 
                                IBarmansService barmenService,
                                IBarsService barsService,
                                IGlassesService glassesService,
                                IIngredientsService ingredientsService,
                                IRepository<Ingredients_Cocktails> ingredientsCocktailsRepository,
                                IRepository<CocktailInShoppingCart> cocktailInShoppingCartRepository,
                                IUserRepository userRepository)
        {
            this._cocktailRepository = cocktailRepository;
            this._barmenService = barmenService;
            this._barsService = barsService;
            this._glassesService = glassesService;
            this._ingredientsService = ingredientsService;
            this._ingredientsCocktailsRepository = ingredientsCocktailsRepository;
            this._cocktailInShoppingCartRepository = cocktailInShoppingCartRepository;
            this._userRepository = userRepository;
        }

        public bool AddToShoppingCart(AddToShoppingCartDto item, string userID)
        {
            var user = this._userRepository.Get(userID);

            var userShoppingCard = user.UserCart;

            if (item.CocktailId != null && userShoppingCard != null)
            {
                var cocktail = this.GetDetailsForCocktail(item.CocktailId);
                Random rand = new Random();
                if (cocktail != null)
                {
                    CocktailInShoppingCart itemToAdd = new CocktailInShoppingCart
                    {
                        Cocktail = cocktail,
                        CocktailId = cocktail.Id,
                        ShoppingCart = userShoppingCard,
                        ShoppingCartId = userShoppingCard.Id,
                        Quantity = item.Quantity
                    };

                    this._cocktailInShoppingCartRepository.Insert(itemToAdd);
                    return true;
                }
                return false;
            }
            return false;
        }

        public void CreateNewCocktail(NewCocktailVM data)
        {
            var cocktail = new Cocktail()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                PictureUrl = data.ImageURL,
                BarId = data.BarId,
                BarmanId = data.BarmanId,
                GlassId = data.GlassId,
                DateCreated = data.DateCreated
            };
            this._cocktailRepository.Add(cocktail);
            foreach (var ingredientId in data.IngredientIds)
            {
                var newIngredientCocktail = new Ingredients_Cocktails()
                {
                    IngredientId = ingredientId,
                    CocktailId = cocktail.Id
                };
                this._ingredientsCocktailsRepository.Insert(newIngredientCocktail);
            }
        }

        public void DeleteCocktail(int id)
        {
            var cocktail = this.GetDetailsForCocktail(id);
            this._cocktailRepository.Delete(cocktail);
        }

        public List<Cocktail> GetAllCocktails()
        {
            return this._cocktailRepository.GetAll().ToList();
        }

        public Cocktail GetDetailsForCocktail(int id)
        {
            return this._cocktailRepository.Get(id);
        }

        public NewCocktailDropDownsVM GetNewCocktailDropdownsValues()
        {
            return new NewCocktailDropDownsVM()
            {
                Barmen = this._barmenService.GetAllBarman(),
                Bars = this._barsService.GetAllBars(),
                Glasses = this._glassesService.GetAllGlasses(),
                Ingredients = this._ingredientsService.GetAllIngredients()
            };
        }

        public AddToShoppingCartDto GetShoppingCartInfo(int id)
        {
            var cocktail = this.GetDetailsForCocktail(id);
            AddToShoppingCartDto model = new AddToShoppingCartDto
            {
                SelectedCocktail = cocktail,
                CocktailId = cocktail.Id,
                Quantity = 1
            };

            return model;
        }

        public void UpdateExistingCocktail(NewCocktailVM cocktail)
        {
            var dbCocktail = this.GetDetailsForCocktail(cocktail.Id);

            if(dbCocktail != null)
            {
                dbCocktail.Name = cocktail.Name;
                dbCocktail.Description = cocktail.Description;
                dbCocktail.Price = cocktail.Price;
                dbCocktail.PictureUrl = cocktail.ImageURL;
                dbCocktail.GlassId = cocktail.GlassId;
                dbCocktail.BarId = cocktail.BarId;
                dbCocktail.BarmanId = cocktail.BarmanId;

                this._cocktailRepository.Update(dbCocktail);
            }

            var existingIngredientsDb = _ingredientsCocktailsRepository.GetAll().Where(n => n.CocktailId == cocktail.Id).ToList();
            foreach (var ing in existingIngredientsDb)
            {
                _ingredientsCocktailsRepository.Delete(ing);
            }
            foreach (var ingId in cocktail.IngredientIds)
            {
                var newIngredientCocktail = new Ingredients_Cocktails()
                {
                    CocktailId = cocktail.Id,
                    IngredientId = ingId
                };
                _ingredientsCocktailsRepository.Insert(newIngredientCocktail);
            }
        }
    }
}
