using ECocktails.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECocktails.Controllers
{
    public class CocktailsController : Controller
    {
        private readonly AppDbContext _context;

        public CocktailsController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var allCocktails = _context.Cocktails.ToList();
            return View();
        }
    }
}
