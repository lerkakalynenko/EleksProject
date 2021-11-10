using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantOrder.Domain.Core.Entities;
using RestaurantOrder.Services.Interfaces;

namespace RestaurantOrder.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpPost]
        public IActionResult CreateOrder(int tablenumber, string notes)
        {
            var order = new Order { TableNumber = tablenumber, Notes = notes};
            orderService.CreateOrder(order);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult CreateOrder()
        {

            return View();
        }
    }
}
