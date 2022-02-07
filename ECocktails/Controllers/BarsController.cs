using ECocktails.Domain.DomainModels;
using ECocktails.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECocktails.Web.Controllers
{
    public class BarsController : Controller
    {
        private readonly IBarsService _service;

        public BarsController(IBarsService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            var allBars = _service.GetAllBars();
            return View(allBars);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Logo, Name, Address")] Bar bar)
        {
            if (!ModelState.IsValid)
            {
                return View(bar);
            }
            _service.CreateNewBar(bar);
            return RedirectToAction("Index");
        }


        public IActionResult Edit(int id)
        {
            var barDetails = _service.GetDetailsForBar(id);
            if (barDetails == null) return View("NotFound");
            return View(barDetails);
        }

        [HttpPost]
        public IActionResult Edit([Bind("Id, Logo, Name, Address")] Bar bar)
        {
            if (!ModelState.IsValid)
            {
                return View(bar);
            }
            _service.UpdateExistingBar(bar);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var barDetails = _service.GetDetailsForBar(id);
            if (barDetails == null) return View("NotFound");
            return View(barDetails);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var barDetails = _service.GetDetailsForBar(id);
            if (barDetails == null) return View("NotFound");

            _service.DeleteBar(id);
            return RedirectToAction("Index");
        }
    }
}
