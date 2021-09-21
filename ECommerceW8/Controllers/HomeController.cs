using ECommerceW8.Data;
using ECommerceW8.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceW8.Controllers
{
    public class HomeController : Controller
    {
            private readonly ECommerceW8DbContext _dbContext;

            public HomeController(ECommerceW8DbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public IActionResult Index()
            {
                IEnumerable<Category> categoryList = _dbContext.Category
                .Include(cat => cat.Products)
                .Include(cat => cat.Products)
                .ThenInclude(cat => cat.Images).ToList();
                return View(categoryList);
            }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
