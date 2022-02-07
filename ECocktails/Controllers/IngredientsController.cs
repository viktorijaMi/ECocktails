using ECocktails.Domain.DomainModels;
using ECocktails.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECocktails.Web.Controllers
{
    public class IngredientsController : Controller
    {
        private readonly IIngredientsService _service;       

        public IngredientsController(IIngredientsService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            var data = _service.GetAllIngredients();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("PictureUrl, Name, IngredientType, Bio")]Ingredient ingredient)
        {
            if(!ModelState.IsValid)
            {
                return View(ingredient);
            }
            _service.CreateNewIngredient(ingredient);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var ingredientDetails =_service.GetDetailsForIngredient(id);
            if (ingredientDetails == null) return View("NotFound");
            return View(ingredientDetails);
        }

        public IActionResult Edit(int id)
        {
            var ingredientDetails = _service.GetDetailsForIngredient(id);
            if (ingredientDetails == null) return View("NotFound");
            return View(ingredientDetails);
        }

        [HttpPost]
        public IActionResult Edit([Bind("Id, PictureUrl, Name, IngredientType, Bio")] Ingredient ingredient)
        {
            if (!ModelState.IsValid)
            {
                return View(ingredient);
            }
            _service.UpdateExistingIngredient(ingredient);
            return RedirectToAction("Index");
        }
        
        public IActionResult Delete(int id)
        {
            var ingredientDetails = _service.GetDetailsForIngredient(id);
            if (ingredientDetails == null) return View("NotFound");
            return View(ingredientDetails);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var ingredientDetails = _service.GetDetailsForIngredient(id);
            if (ingredientDetails == null) return View("NotFound");

            _service.DeleteIngredient(id);
            return RedirectToAction("Index");
        }
    }
}
