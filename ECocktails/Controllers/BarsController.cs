using ECocktails.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECocktails.Controllers
{
    public class BarsController : Controller
    {
        private readonly AppDbContext _context;

        public BarsController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var allBars = _context.Bars.ToList();
            return View();
        }
    }
}
