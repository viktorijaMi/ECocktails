using ECocktails.Domain.DomainModels;
using ECocktails.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECocktails.Web.Controllers
{
    public class BarmansController : Controller
    {
        private readonly IBarmansService _service;

        public BarmansController(IBarmansService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            var allBarmans = _service.GetAllBarman();
            return View(allBarmans);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("PictureUrl, FullName, Bio")] Barman barman)
        {
            if (!ModelState.IsValid)
            {
                return View(barman);
            }
            _service.CreateNewBarman(barman);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var barmanDetails = _service.GetDetailsForBarman(id);
            if (barmanDetails == null) return View("NotFound");
            return View(barmanDetails);
        }

        public IActionResult Edit(int id)
        {
            var barmanDetails = _service.GetDetailsForBarman(id);
            if (barmanDetails == null) return View("NotFound");
            return View(barmanDetails);
        }

        [HttpPost]
        public IActionResult Edit([Bind("Id, PictureUrl, FullName, Bio")] Barman barman)
        {
            if (!ModelState.IsValid)
            {
                return View(barman);
            }
            _service.UpdateExistingBarman(barman);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var barmanDetails = _service.GetDetailsForBarman(id);
            if (barmanDetails == null) return View("NotFound");
            return View(barmanDetails);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var barmanDetails = _service.GetDetailsForBarman(id);
            if (barmanDetails == null) return View("NotFound");

            _service.DeleteBarman(id);
            return RedirectToAction("Index");
        }
    }
}
