using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantOrder.Domain.Core.Entities;
using RestaurantOrder.Services.Interfaces;

namespace RestaurantOrder.Controllers
{
    public class DishController : Controller
    {
        private readonly IDishService dishService;

        public DishController(IDishService dishService)
        {
            this.dishService = dishService;
        }

        [HttpPost]
        public IActionResult CreateDish(string name, string description, decimal price)
        {
            var dish = new Dish { Name = name, Description = description, Price = price};
            
            dishService.CreateDish(dish);
            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        public IActionResult CreateDish()
        {

            return View();
        }


    }
}
