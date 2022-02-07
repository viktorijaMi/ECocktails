using ECocktails.Domain.DomainModels;
using ECocktails.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECocktails.Web.Controllers
{
    public class GlassesController : Controller
    {
        private readonly IGlassesService _service;

        public GlassesController(IGlassesService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            var allGlasses = _service.GetAllGlasses();
            return View(allGlasses);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("PictureUrl")] Glass glass)
        {
            if (!ModelState.IsValid)
            {
                return View(glass);
            }
            _service.CreateNewGlass(glass);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var glassDetails = _service.GetDetailsForGlass(id);
            if (glassDetails == null) return View("NotFound");
            return View(glassDetails);
        }

        [HttpPost]
        public IActionResult Edit([Bind("Id, PictureUrl")] Glass glass)
        {
            if (!ModelState.IsValid)
            {
                return View(glass);
            }
            _service.UpdateExistingGlass(glass);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var glassDetails = _service.GetDetailsForGlass(id);
            if (glassDetails == null) return View("NotFound");
            return View(glassDetails);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var glassDetails = _service.GetDetailsForGlass(id);
            if (glassDetails == null) return View("NotFound");

            _service.DeleteGlass(id);
            return RedirectToAction("Index");
        }
    }
}
