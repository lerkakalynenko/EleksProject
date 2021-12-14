using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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



        public OrderController(IOrderService orderService, IMapper mapper, IDishService dishService)
        {
            _orderService = orderService;
            _mapper = mapper;
            _dishService = dishService;
        }

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

        
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult<Order> GetAll()
        {
            var orders = _mapper.Map<IEnumerable<OrderDto>>(_orderService.GetAll());

            return View(orders);
        }

        [HttpGet]
        public IActionResult CreateOrder()
        {

            return View();
        }

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
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
    }
}
