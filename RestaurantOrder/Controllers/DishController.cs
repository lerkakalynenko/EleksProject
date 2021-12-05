using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RestaurantOrder.Domain.Core.Entities;
using RestaurantOrder.Services.Contracts;
using RestaurantOrder.Services.Interfaces;

namespace RestaurantOrder.Controllers
{
    public class DishController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IDishService _dishService;
        private readonly IOrderService _orderService;
        public DishController(IDishService dishService, IMapper mapper, IOrderService orderService)
        {
            _dishService = dishService;
            _mapper = mapper;
            _orderService = orderService;
        }
        //Todo: создаем блюдо
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
        public ActionResult<Dish> DeleteDish()
        {

            return View(_dishService.GetAll());
        }

        //Todo: удаляем блюдо
        [HttpPost]
        public ActionResult<Dish> DeleteDish(int id)
        {
            try
            {
                _dishService.DeleteDish(id);
                

                return RedirectToAction("DeleteDish", "Dish");

            }
            catch
            {
                 return BadRequest("Index that you entered doesn't exist!!!");
            }
               


        }

        [HttpGet]
        public ActionResult<Dish> GetAll(int orderId)
        {
            var order = _mapper.Map<OrderDto>(_orderService.GetOrderById(orderId));

            ViewBag.OrderId = orderId;
            ViewBag.CountOfDishes = order.NeededDishes.Count;
            
            var dishes = _mapper.Map<IEnumerable<DishDto>>(_dishService.GetAll());
            var connectionDishOrder = new ConnectionDishOrder(order, dishes);

            return View(connectionDishOrder);
        }

        //Todo: добавление блюд к заказу
        [HttpPost]
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
                
                order.NeededDishes.Add(neededDish);
                _orderService.Update(order);

                return RedirectToAction("AddedDishes", new {orderId});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult AddedDishes(int orderId)
        {
            var order = _orderService.GetOrderById(orderId);
            
            return View(order);
        }

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
    }
}
