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
    public class ProductController : Controller
    {
        private readonly ECommerceW8DbContext _dbContext;

        public ProductController(ECommerceW8DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> productList = _dbContext.Product
                .Include(prod => prod.Category)
                .Include(prod => prod.Images).ToList();
            return View(productList);
        }


        [HttpPost]
        public IActionResult SearchByCategory(string searchQuery)
        {
            IEnumerable<Product> productList = _dbContext.Product
               .Include(prod => prod.Category)
               .Include(prod => prod.Images).ToList();

            List<Product> productsByCategory = new List<Product>();
            if (string.IsNullOrEmpty(searchQuery))
            {
                return NotFound();
            }
            foreach (var item in productList)
            {
                if(item.Category.Name == searchQuery)
                {
                    productsByCategory.Add(item);
                }
            }
            return View(productsByCategory);
        }
        public IActionResult ProductDetail(string id)
        {
            Product product = _dbContext.Product.Include(prod => prod.Category)
                .Include(prod => prod.Images).FirstOrDefault(prod => prod.Id == id);
            return View(product);
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
