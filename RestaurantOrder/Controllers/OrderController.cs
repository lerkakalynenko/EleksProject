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
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly IMapper _mapper;



        public OrderController(IOrderService orderService, IMapper mapper)
        {
            this.orderService = orderService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateOrder(int tableNumber, string notes)
        {
            var order = new Order { TableNumber = tableNumber, Notes = notes};
            var createdOrder = orderService.CreateOrder(order); 

            var model = _mapper.Map<OrderDto>(order);
            

            return RedirectToAction("GetAll", "Dish", new{id= createdOrder.OrderId});
        }

        [HttpGet]
        public IActionResult CreateOrder()
        {

            return View();
        }
      

        [HttpGet]
        public IActionResult DeleteOrder()
        {

            return View();
        }
        [HttpPost]
        public ActionResult<Order> DeleteOrder(int id)
        {
            orderService.DeleteOrder(id);
            return RedirectToAction("DeleteOrder", "Order");
        }
    }
}
