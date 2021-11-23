using System;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient.DataClassification;
using RestaurantOrder.Domain.Core.Entities;
using RestaurantOrder.Services.Contracts;
using RestaurantOrder.Services.Interfaces;

namespace RestaurantOrder.Controllers
{
    public class ProductController : Controller
    {
        
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        private readonly INeededProductService _neededProductService;
        private readonly IDishService _dishService;

        public ProductController(IMapper mapper, IProductService productService, INeededProductService neededProductService, IDishService dishService)
        {
            _mapper = mapper;
            _productService = productService;
            _neededProductService = neededProductService;
            _dishService = dishService;
            _productService = _productService ?? throw new ArgumentNullException(nameof(_productService));

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
        public ActionResult<Product> GetAll(int id)
        {
            ViewBag.DishId = id;
            
            return View(_productService.GetAll());
        }
        [HttpGet]
        public IActionResult DeleteProduct()
        {

            return View();
        }

        [HttpPost]
        public ActionResult<Product> DeleteProduct(int id)
        {
            _productService.DeleteProduct(id);
            return RedirectToAction("DeleteProduct", "Product");
            
        }

        public IActionResult AddProductToList(int productId, int dishId, int quantity)
        {
            var product = _productService.GetProductById(productId);
            var dish = _dishService.GetDishById(dishId);

            var neededProduct = new NeededProduct
            {
                Product = product,
                ProductQuantity = quantity,
            };
            dish.NeededProducts.Add(neededProduct);
            _neededProductService.Create(neededProduct);

            _dishService.Update(dish);
            return RedirectToAction("GetAll", new {id=dishId});
        }
        //[HttpPost]
        //public IActionResult GetAll(int productId, int quantity)
        //{

        //    var neededProduct = new NeededProduct {Product = productId, ProductQuantity = quantity };

        //    List<int> lst = new List<int>();

        //    return RedirectToAction("GetAll", "Product");

        //}
        



    }
}
