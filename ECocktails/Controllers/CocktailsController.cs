using ECocktails.Domain.DomainModels;
using ECocktails.Domain.DTO;
using ECocktails.Domain.ViewModels;
using ECocktails.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ECocktails.Wen.Controllers
{
    public class CocktailsController : Controller
    {
        private readonly ICocktailsService _service;

        public CocktailsController(ICocktailsService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {

            var allCocktails = _service.GetAllCocktails();
            return View(allCocktails);
        }

        public IActionResult Details(int id)
        {
            var cocktailDetail = _service.GetDetailsForCocktail(id);
            return View(cocktailDetail);
        }

        public IActionResult Filter(string searchString)
        {
            var allCocktails = _service.GetAllCocktails();

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allCocktails.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();
                return View("Index", filteredResult);
            }

            return View("Index", allCocktails);
        }

        public IActionResult AddCocktailToCart(int id)
        {
            var model = this._service.GetShoppingCartInfo(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCocktailToCart([Bind("CocktailId", "Quantity")] AddToShoppingCartDto item)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = this._service.AddToShoppingCart(item, userId);

            if (result)
            {
                return RedirectToAction("Index", "Cocktails");
            }

            return View(item);
        }

        public IActionResult Create()
        {
            var cocktailDropdownsData = _service.GetNewCocktailDropdownsValues();

            ViewBag.Bars = new SelectList(cocktailDropdownsData.Bars, "Id", "Name");
            ViewBag.Barmen = new SelectList(cocktailDropdownsData.Barmen, "Id", "FullName");
            ViewBag.Glasses = new SelectList(cocktailDropdownsData.Glasses, "Id", "PictureUrl");
            ViewBag.Ingredients = new SelectList(cocktailDropdownsData.Ingredients, "Id", "Name");

            return View();
        }

        [HttpPost]
        public IActionResult Create(NewCocktailVM cocktail)
        {
            if (!ModelState.IsValid)
            {
                var cocktailDropdownsData = _service.GetNewCocktailDropdownsValues();

                ViewBag.Bars = new SelectList(cocktailDropdownsData.Bars, "Id", "Name");
                ViewBag.Barmen = new SelectList(cocktailDropdownsData.Barmen, "Id", "FullName");
                ViewBag.Glasses = new SelectList(cocktailDropdownsData.Glasses, "Id", "PictureUrl");
                ViewBag.Ingredients = new SelectList(cocktailDropdownsData.Ingredients, "Id", "Name");

                return View(cocktail);
            }

            _service.CreateNewCocktail(cocktail);
            return RedirectToAction("Index");
        }
    }
}
