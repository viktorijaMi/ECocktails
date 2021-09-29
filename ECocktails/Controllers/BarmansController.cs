using ECocktails.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECocktails.Controllers
{
    public class BarmansController : Controller
    {
        private readonly AppDbContext _context;

        public BarmansController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var allBarmans = _context.Barmans.ToList();
            return View();
        }
    }
}
