using Microsoft.AspNetCore.Mvc;
using Murach_Guitar.Models;
using System.Collections.Generic;
using System.Linq;

namespace Murach_Guitar.Controllers
{
    public class ProductController : Controller
    {
        private ShopContext context;

        public ProductController(ShopContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return RedirectToAction("List", "Product");
        }

        [Route("[controller]s/{id?}")]
        public IActionResult List(string id = "All")
        {
            List<Product> products;

            var categories = context.Categories.OrderBy(c => c.CategoryID).ToList();

            if (id == "All")
                products = context.Products.OrderBy(p => p.ProductID).ToList();
            else
                products = context.Products.Where(p => p.Category.Name == id).OrderBy(p => p.ProductID).ToList();

            ViewBag.Categories = categories;
            ViewBag.SelectedCategoryName = id;

            return View(products);
        }

        public IActionResult Details(int id)
        {
            var categories = context.Categories.OrderBy(c => c.CategoryID).ToList();

            Product product = context.Products.Find(id);

            string imageFilename = product.Code + "_m.png";


            ViewBag.Categories = categories;
            ViewBag.ImageFilename = imageFilename;


            return View(product);
        }
    }
}
