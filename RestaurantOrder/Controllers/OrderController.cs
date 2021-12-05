using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using RestaurantOrder.Domain.Core.Entities;
using RestaurantOrder.Services.Contracts;
using RestaurantOrder.Services.Interfaces;

namespace RestaurantOrder.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        private readonly IDishService _dishService;
        private readonly INeededDishService _neededDishService;
        

        
        public OrderController(IOrderService orderService, IMapper mapper, IDishService dishService, INeededDishService neededDishService)
        {
            _orderService = orderService;
            _mapper = mapper;
            _dishService = dishService;
            _neededDishService = neededDishService;
        }


        // TODO: сделать заказ (вписать номер стола и заметки)
        [HttpPost]
        public IActionResult CreateOrder(int tableNumber, string notes)
        {
            try
            {
                var order = new OrderDto { TableNumber = tableNumber, Notes = notes };
                var createdOrder = _orderService.CreateOrder(_mapper.Map<Order>(order));
                return RedirectToAction("GetAll", "Dish", new { orderId = createdOrder.OrderId });
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        
        //TODO: все заказы отобразить
        [HttpGet]
        public ActionResult<Order> GetAll()
        {
            //ViewBag.OrderId = id;
            var orders = _mapper.Map<IEnumerable<OrderDto>>(_orderService.GetAll());

            return View(orders);
        }

        //TODO: отобразить форму с созданием заказа
        [HttpGet]
        public IActionResult CreateOrder()
        {

            return View();
        }
        //todo: отобразить меню (все блюда)
        [HttpGet]
        public ActionResult<Dish> Menu(int id)
        {
            ViewBag.OrderId = id;
            
            return View(_dishService.GetAll());
        }

        public ActionResult<Order> DeleteOrder(int id)
        {
            try
            {
                _orderService.DeleteOrder(id);
                
                return RedirectToAction("GetAll", "Order");
            }
            catch
            {
                return BadRequest("Index that you entered doesn't exist");
            }
            
        }
    }
}
