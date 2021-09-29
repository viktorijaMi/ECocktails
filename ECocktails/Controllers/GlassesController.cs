using ECocktails.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECocktails.Controllers
{
    public class GlassesController : Controller
    {
        private readonly AppDbContext _context;

        public GlassesController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var allGlasses = _context.Glass.ToList();
            return View();
        }
    }
}
