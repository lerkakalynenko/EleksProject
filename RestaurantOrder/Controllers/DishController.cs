using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RestaurantOrder.Domain.Core.Entities;
using RestaurantOrder.Services.Contracts;
using RestaurantOrder.Services.Interfaces;

namespace RestaurantOrder.Controllers
{
    public class DishController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IDishService dishService;
       // private readonly INeededProductService neededProductService;

        public DishController(IDishService dishService, IMapper mapper)
        {
            this.dishService = dishService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateDish(Dish dish)
        {
            dishService.CreateDish(dish);
            var model = _mapper.Map<DishDto>(dish);
            return RedirectToAction("CreateDish", "Dish");

        }

        [HttpGet]
        public IActionResult CreateDish()
        {
            
            return View();
        }
        


    }
}
