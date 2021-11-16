using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RestaurantOrder.Domain.Core.Entities;
using RestaurantOrder.Infrastructure.Business;
using RestaurantOrder.Services.Contracts;
using RestaurantOrder.Services.Interfaces;

namespace RestaurantOrder.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public ProductController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }
        
        
        
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            _productService.CreateProduct(product);
            var model = _mapper.Map<ProductDto>(product);
            return RedirectToAction("CreateProduct", "Product");
        }



        //[HttpPost]
        //public IActionResult CreateProduct(string name, int quantity)
        //{
        //    var product = new Product{Name = name, Quantity = quantity};
        //    productService.CreateProduct(product);
        //    return RedirectToAction("Index", "Home");
        //}
        [HttpGet]
        public IActionResult CreateProduct()
        {

            return View();
        }

        public ActionResult<Product> Index(int id)
        {
            return View(_productService.GetProductById(id));
        }
        [HttpGet]
        public ActionResult<Product> GetAll()
        {
            return View(_productService.GetAll());
        }
    }
}
