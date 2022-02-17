using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using RestaurantOrder.Domain.Core.Entities;
using RestaurantOrder.Services.Contracts;
using RestaurantOrder.Services.Interfaces;

namespace RestaurantOrder.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DishController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IDishService _dishService;
        private readonly IOrderService _orderService;
        private readonly INeededProductService _neededProductService;
        public DishController(IDishService dishService, IMapper mapper, IOrderService orderService, INeededProductService neededProductService)
        {
            _dishService = dishService;
            _mapper = mapper;
            _orderService = orderService;
            _neededProductService = neededProductService;
        }
       
        [HttpPost]
        public IActionResult CreateDish(DishDto dish)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var createdDish = _dishService.CreateDish(_mapper.Map<Dish>(dish));

            return RedirectToAction("GetAll", "Product", new {id = createdDish.Id});

        }

        [HttpGet]
        public IActionResult CreateDish()
        {
            return View();
        }
        
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<Dish> GetAll(int orderId)
        {
            var order = _mapper.Map<OrderDto>(_orderService.GetOrderById(orderId));

            ViewBag.OrderId = orderId;
            ViewBag.CountOfDishes = order.NeededDishes.Count;
            
            var dishes = _mapper.Map<IEnumerable<DishDto>>(_dishService.GetAll());
            var connectionDishOrder = new ConnectionDishOrder(order, dishes);

            return View(connectionDishOrder);
        }

        
        [HttpPost]
        [AllowAnonymous]
        public IActionResult AddDishToList(int dishId, int orderId, int quantity)
        {
            try
            {
                var dish = _dishService.GetDishById(dishId);
                var neededDish = new NeededDish()
                {
                    Dish = dish,
                    DishQuantity = quantity,
                };

                var order = _orderService.GetOrderById(orderId);
                if (neededDish.DishQuantity != 0)
                {
                

                    order.NeededDishes.Add(neededDish);
                    _orderService.Update(order);
                    return RedirectToAction("AddedDishes", new {orderId});
                }

                return RedirectToAction("GetAll", "Dish", new {orderId});

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AddedDishes(int orderId)
        {
            var order = _orderService.GetOrderById(orderId);
            
            return View(order);
        }
        [AllowAnonymous]
        public IActionResult DeleteDishFromOrder(int orderId, int neededDishId)
        {
            var order = _orderService.GetOrderById(orderId);
            var findDish = order.NeededDishes.FirstOrDefault(nDish => nDish.Id == neededDishId);

            if (findDish != null)
            {
                order.NeededDishes.Remove(findDish);
            }
            _orderService.Update(order);

            return RedirectToAction("AddedDishes", new { orderId });
        }

        [HttpGet]
        public IActionResult DeleteDish()
        {

            return View(_dishService.GetAll());

        }

        [HttpPost]
        public ActionResult<Product> DeleteDish(int id)
        {
            try
            {
                _dishService.DeleteDish(id);
                
                
                return RedirectToAction("DeleteDish", "Dish");
            }
            catch 
            {
                return BadRequest("You can't to delete dish, which contains in not completed order. Wait a little and repeat attempt.");
            }

        }
    }
}
