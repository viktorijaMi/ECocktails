using ECocktails.Domain.DomainModels;
using ECocktails.Domain.DTO;
using ECocktails.Repository.Interface;
using ECocktails.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECocktails.Service.Implementation
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IRepository<ShoppingCart> _shoppingCartRepositorty;
        private readonly IRepository<Order> _orderRepositorty;
        private readonly IRepository<CocktailInOrder> _cocktailInOrderRepositorty;
        private readonly IUserRepository _userRepository;

        public ShoppingCartService(IRepository<ShoppingCart> shoppingCartRepository, IRepository<CocktailInOrder> cocktailInOrderRepositorty, IRepository<Order> orderRepositorty, IUserRepository userRepository)
        {
            this._shoppingCartRepositorty = shoppingCartRepository;
            this._cocktailInOrderRepositorty = cocktailInOrderRepositorty;
            this._orderRepositorty = orderRepositorty;
            this._userRepository = userRepository;
        }


        public bool deleteCocktailFromShoppingCart(string userId, int id)
        {
            if (!string.IsNullOrEmpty(userId) && id != null)
            {
                //Select * from Users Where Id LIKE userId

                var loggedInUser = this._userRepository.Get(userId);

                var userShoppingCart = loggedInUser.UserCart;

                var itemToDelete = userShoppingCart.CocktailInShoppingCarts.Where(z => z.CocktailId.Equals(id)).FirstOrDefault();

                userShoppingCart.CocktailInShoppingCarts.Remove(itemToDelete);

                this._shoppingCartRepositorty.Update(userShoppingCart);

                return true;
            }

            return false;
        }

        public ShoppingCartDto getShoppingCartInfo(string userId)
        {
            var loggedInUser = this._userRepository.Get(userId);

            var userShoppingCart = loggedInUser.UserCart;

            var AllCocktails = userShoppingCart.CocktailInShoppingCarts.ToList();

            var allCocktailsPrice = AllCocktails.Select(z => new
            {
                CocktailPrice = z.Cocktail.Price,
                Quanitity = z.Quantity
            }).ToList();

            var totalPrice = 0.0;


            foreach (var item in allCocktailsPrice)
            {
                totalPrice += item.Quanitity * item.CocktailPrice;
            }


            ShoppingCartDto scDto = new ShoppingCartDto
            {
                Cocktails = AllCocktails,
                TotalPrice = totalPrice
            };


            return scDto;
        }

        public bool orderNow(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                //Select * from Users Where Id LIKE userId

                var loggedInUser = this._userRepository.Get(userId);

                var userShoppingCart = loggedInUser.UserCart;

                Random rand = new Random();
                Order order = new Order
                {
                    User = loggedInUser,
                    UserId = userId
                };

                this._orderRepositorty.Insert(order);

                List<CocktailInOrder> productInOrders = new List<CocktailInOrder>();

                var result = userShoppingCart.CocktailInShoppingCarts.Select(z => new CocktailInOrder
                {
                    CocktailId = z.Cocktail.Id,
                    OrderedCocktail = z.Cocktail,
                    OrderId = order.Id,
                    UserOrder = order
                }).ToList();


                var totalPrice = 0.0;


                for (int i = 1; i <= result.Count(); i++)
                {
                    var item = result[i - 1];

                    totalPrice += item.Quantity * item.OrderedCocktail.Price;

                }


                productInOrders.AddRange(result);

                foreach (var item in productInOrders)
                {
                    this._cocktailInOrderRepositorty.Insert(item);
                }

                loggedInUser.UserCart.CocktailInShoppingCarts.Clear();

                this._userRepository.Update(loggedInUser);

                return true;
            }
            return false;
        }
    }
    }
