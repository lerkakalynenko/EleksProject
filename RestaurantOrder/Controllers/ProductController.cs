using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantOrder.Domain.Core.Entities;
using RestaurantOrder.Infrastructure.Business;
using RestaurantOrder.Services.Interfaces;

namespace RestaurantOrder.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpPost]
        public IActionResult CreateProduct(string name, int quantity)
        {
            var product = new Product{Name = name, Quantity = quantity};
            productService.CreateProduct(product);
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult CreateProduct()
        {

            return View();
        }

        public ActionResult<Product> Index(int id)
        {
            return View(productService.GetProductById(id));
        }
    }
}
